using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;
using WedigITCRM.Utilities;
using WedigITCRM.ViewModels;


namespace WedigITCRM.Controllers
{
    public class PurchaseOrderController : Controller
    {
        public IVendorRepository _vendorRepository;
        private IPurchaseOrderRepository _purchaseOrderRepository;
        private IPurchaseOrderLineRepository _purchaseOrderLineRepository;
        private readonly IStockItemRepository _stockItemRepository;
        private readonly IDeliveryConditionRepository _deliveryConditionRepository;
        private readonly IPaymentConditionRepository _paymentConditionRepository;
        public ICurrencyCodeRepository _currencyCodeRepository;

        public PurchaseOrderController(IStockItemRepository stockItemRepository, IDeliveryConditionRepository deliveryConditionRepository, IPaymentConditionRepository paymentConditionRepository, ICurrencyCodeRepository currencyCodeRepository, IVendorRepository vendorRepository, IPurchaseOrderRepository purchaseOrderRepository, IPurchaseOrderLineRepository purchaseOrderLineRepository)
        {
            _stockItemRepository = stockItemRepository;
            _deliveryConditionRepository = deliveryConditionRepository;
            _paymentConditionRepository = paymentConditionRepository;
            _currencyCodeRepository = currencyCodeRepository;
            _vendorRepository = vendorRepository;
            _purchaseOrderRepository = purchaseOrderRepository;
            _purchaseOrderLineRepository = purchaseOrderLineRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreatePO()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePO(PurchaseOrderViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                DateTime testdate;
                DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
                PurchaseOrder purchaseOrder = new PurchaseOrder();

                if (!string.IsNullOrEmpty(model.OurWantedDeliveryDate))
                {
                    if (DateTime.TryParse(model.OurWantedDeliveryDate, out testdate))
                    {
                        purchaseOrder.WantedDeliveryDate = DateTime.Parse(model.OurWantedDeliveryDate, danishDateTimeformat);
                    }
                }

                if (!string.IsNullOrEmpty(model.OurOrderingDate))
                {
                    if (DateTime.TryParse(model.OurOrderingDate, out testdate))
                    {
                        purchaseOrder.OurOrderingDate = DateTime.Parse(model.OurOrderingDate, danishDateTimeformat);
                    }
                }

                purchaseOrder.VendorId = Int32.Parse(model.VendorId);
                purchaseOrder.VendorName = model.VendorName;
                purchaseOrder.VendorStreet = model.VendorStreet;
                purchaseOrder.VendorCity = model.VendorCity;
                purchaseOrder.VendorEmail = model.VendorEmail;
                purchaseOrder.VendorZip = model.VendorZip;
                purchaseOrder.VendorCountryCode = model.VendorCountryCode;
                purchaseOrder.VendorCurrencyCode = model.VendorCurrencyCode;
                purchaseOrder.VendorPhoneNumber = model.VendorPhoneNumber;
                purchaseOrder.VendorHomePage = model.VendorHomePage;
                purchaseOrder.VendorReference = model.VendorReference;
                purchaseOrder.OurReference = model.OurReference;

                purchaseOrder.companyAccountId = companyAccount.companyAccountId;

                purchaseOrder.VendorPaymentConditionsId = model.VendorPaymentConditionId;

                if (!string.IsNullOrEmpty(model.VendorPaymentConditionId))
                {
                    PaymentCondition paymentCondition = _paymentConditionRepository.GetPaymentCondition(Int32.Parse(model.VendorPaymentConditionId));
                    if (paymentCondition != null)
                    {
                        purchaseOrder.VendorPaymentConditions = paymentCondition.Description;
                    }
                }

                purchaseOrder.VendorDeliveryConditionId = model.VendorDeliveryConditionId;
                if (!string.IsNullOrEmpty(model.VendorDeliveryConditionId))
                {
                    DeliveryCondition deliveryCondition = _deliveryConditionRepository.GetDeliveryCondition(Int32.Parse(model.VendorDeliveryConditionId));
                    if (deliveryCondition != null)
                    {
                        purchaseOrder.VendorDeliveryConditions = deliveryCondition.Description;
                    }
                }

                purchaseOrder.CreatedDate = DateTime.Now;
                purchaseOrder.LastEditedDate = DateTime.Now;

                string DocumentNumber = getNextPurchaseOrderNumber(companyAccount.companyAccountId);
                purchaseOrder.PurchaseOrderDocumentNumber = DocumentNumber;
                _purchaseOrderRepository.Add(purchaseOrder);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditPO(int purchaseOrderId)
        {
            PurchaseOrder purchaseOrder = _purchaseOrderRepository.GetPurchaseOrder(purchaseOrderId);
            if (purchaseOrder != null)
            {
                PurchaseOrderViewModel model = new PurchaseOrderViewModel();
                model.PurchaseOrderDocumentNumber = purchaseOrder.PurchaseOrderDocumentNumber;
                model.VendorId = purchaseOrder.VendorId.ToString();
                model.VendorName = purchaseOrder.VendorName;
                model.VendorStreet = purchaseOrder.VendorStreet;
                model.VendorCity = purchaseOrder.VendorCity;
                purchaseOrder.VendorEmail = model.VendorEmail;
                model.VendorZip = purchaseOrder.VendorZip;
                model.VendorCountryCode = purchaseOrder.VendorCountryCode;
                model.VendorCurrencyCode = purchaseOrder.VendorCurrencyCode;
                model.VendorPhoneNumber = purchaseOrder.VendorPhoneNumber;
                model.VendorHomePage = purchaseOrder.VendorHomePage;
                purchaseOrder.LastEditedDate = DateTime.Now;
                return View(model);
            }


            return View();
        }
        public IActionResult getCurrencies()
        {
            List<CurrencyCode> currencyList = _currencyCodeRepository.getAllCurrencyCodes().ToList();
            List<CurrencySelectionModel> currencies = new List<CurrencySelectionModel>();


            foreach (var currencyCode in currencyList)
            {
                CurrencySelectionModel currencySelectionModel = new CurrencySelectionModel();
                currencySelectionModel.Id = currencyCode.Id;
                currencySelectionModel.Description = currencyCode.Description;
                currencies.Add(currencySelectionModel);
            }


            return Json(currencies);
        }

        [HttpPost]
        public IActionResult getAllVendors(CompanyAccount companyAccount)
        {
            List<Vendor> vendorList = new List<Vendor>();
            List<VendorSelectionModel> vendorOutputList = new List<VendorSelectionModel>();

            vendorList = _vendorRepository.GetAllVendors().Where(vendor => vendor.companyAccountId == companyAccount.companyAccountId).ToList();

            foreach (var vendor in vendorList)
            {
                VendorSelectionModel model = new VendorSelectionModel();
                model.Id = vendor.Id.ToString();
                model.VendorName = vendor.Name;

                vendorOutputList.Add(model);
            }

            return Json(vendorOutputList);
        }

        [HttpPost]
        public IActionResult getVendorById(VendorDetailModel model, CompanyAccount companyAccount)
        {
            if (!string.IsNullOrEmpty(model.Id))
            {
                Vendor vendor = _vendorRepository.GetVendor(Int32.Parse(model.Id));
                if (vendor != null)
                {
                    model.VendorName = vendor.Name;
                    model.Street = vendor.Street;
                    if (vendor.Zip.Length == 0)
                    {
                        model.Zip = vendor.ForeignZip;
                        model.City = vendor.ForeignCity;
                    }
                    else
                    {
                        model.Zip = vendor.Zip;
                        model.City = vendor.City;
                    }

                    model.CountryCode = vendor.CountryCode;
                    model.CurrencyCode = vendor.CurrencyCode;
                    model.PhoneNumber = vendor.PhoneNumber;
                    model.VendorEmail = vendor.Email;
                    model.VendorPaymentConditionsId = vendor.PaymentConditionsId.ToString();
                    model.VendorPaymentConditions = vendor.PaymentConditions;

                    model.VendorDeliveryConditionsId = vendor.DeliveryConditionsId.ToString();
                    model.VendorDeliveryConditions = vendor.DeliveryConditions;
                }
            }
            return Json(model);
        }

        [HttpPost]
        public IActionResult getStockItemById(StockItemDetailModel model, CompanyAccount companyAccount)
        {
            if (!string.IsNullOrEmpty(model.Id))
            {
                StockItem stockItem = _stockItemRepository.getStockItem(Int32.Parse(model.Id));
                if (stockItem != null)
                {
                    model.OurSalesPrice = stockItem.SalesPrice.ToString();
                    model.OurLocation = stockItem.Location;
                    model.OurItemNumber = stockItem.ItemNumber;
                    model.OurItemUnit = stockItem.Unit;
                    model.OurNumberInStock = stockItem.NumberInStock.ToString();
                    model.VendorItemNumber = stockItem.VendorItemNumber;
                    model.VendorItemName = stockItem.VendorItemName;
                }
            }
            return Json(model);
        }

        [HttpPost]
        public IActionResult saveOrderLine(PurchaseOrderLineModel model, CompanyAccount companyAccount)
        {
            if (!string.IsNullOrEmpty(model.Id))
            {
                // PurchaseOrderLine orderLine = _purchaseOrderLineRepository.GetPurchaseOrderLine(Int32.Parse(model.Id));
                PurchaseOrderLine orderLine = new PurchaseOrderLine();
                if (orderLine != null)
                {
                    orderLine.OurUnitSalesPrice = Decimal.Parse(model.OurSalesPrice);
                    orderLine.OurItemNumber = model.OurItemNumber;
                    orderLine.OurItemName = model.OurItemName;
                    orderLine.OurLocation = model.OurLocation;
                    orderLine.OurUnit = model.OurItemUnit;
                    orderLine.QuantityToOrder = Decimal.Parse(model.QuantityToOrder);
                    orderLine.VendorItemNumber = model.VendorItemNumber;
                    orderLine.VendorItemName = model.VendorItemName;

                    if (!string.IsNullOrEmpty(model.PurchaseOrderId))
                    {
                        orderLine.PurchaseOrderId = Int32.Parse(model.PurchaseOrderId);
                    }

                    orderLine.companyAccountId = companyAccount.companyAccountId;
                    _purchaseOrderLineRepository.Add(orderLine);
                }
            }
            return Json(model);
        }

        private string getNextPurchaseOrderNumber(int companyAccountId)
        {
            List<PurchaseOrder> purchaseOrderList = _purchaseOrderRepository.GetAllPurchaseOrders().Where(purchaseOrder => purchaseOrder.companyAccountId == companyAccountId).ToList();
            int purchaseOrderNumber = purchaseOrderList.Count + 1;
            return (purchaseOrderNumber.ToString());
        }
    }


    public class VendorSelectionModel
    {
        public string Id { get; set; }
        public string VendorName { get; set; }

    }

    public class CurrencySelectionModel
    {
        public string Id { get; set; }
        public string Description { get; set; }

    }

    public class VendorDetailModel
    {
        public string Id { get; set; }
        public string VendorName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyCode { get; set; }
        public string PhoneNumber { get; set; }
        public string HomePage { get; set; }
        public string VendorEmail { get; set; }

        public string VendorPaymentConditionsId { get; set; }

        public string VendorPaymentConditions { get; set; }
        public string VendorDeliveryConditionsId { get; set; }

        public string VendorDeliveryConditions { get; set; }

    }

    public class StockItemDetailModel
    {
        public string Id { get; set; }
        public string OurItemName { get; set; }
        public string OurItemUnit { get; set; }
        public string OurItemNumber { get; set; }

        public string OurCategory1 { get; set; }
        public string OurCategory2 { get; set; }
        public string OurCategory3 { get; set; }
        public string Ourcategory1Id { get; set; }
        public string Ourcategory2Id { get; set; }
        public string Ourcategory3Id { get; set; }
        public string OurNumberInStock { get; set; }

        public string OurReorderNumberInStock { get; set; }
        public string OurLocation { get; set; }

        public string OurCategory { get; set; }
        public string VendorId { get; set; }

        public string PurchaseOrderId { get; set; }
        public string VendorName { get; set; }

        public string VendorItemNumber { get; set; }
        public string VendorItemName { get; set; }
        public string OurExpirationdate { get; set; }
        public string OurInStockAgainDate { get; set; }

        public string OurCostPrice { get; set; }

        public string OurStockValue { get; set; }

        public string OurSalesPrice { get; set; }

        public int companyAccountId { get; set; }

        public string LastEditedDate { get; set; }

        public string CreatedDate { get; set; }
    }

    public class PurchaseOrderLineModel
    {
        public string Id { get; set; }
        public string OurItemName { get; set; }
        public string OurItemUnit { get; set; }
        public string OurItemNumber { get; set; }

        public string OurCategory1 { get; set; }
        public string OurCategory2 { get; set; }
        public string OurCategory3 { get; set; }
        public string Ourcategory1Id { get; set; }
        public string Ourcategory2Id { get; set; }
        public string Ourcategory3Id { get; set; }
        public string OurNumberInStock { get; set; }

        public string OurReorderNumberInStock { get; set; }
        public string OurLocation { get; set; }
        public string QuantityToOrder { get; set; }
        public string OurCategory { get; set; }
        public string VendorId { get; set; }

        public string PurchaseOrderId { get; set; }
        public string VendorName { get; set; }

        public string VendorItemNumber { get; set; }
        public string VendorItemName { get; set; }
        public string OurExpirationdate { get; set; }
        public string OurInStockAgainDate { get; set; }

        public string OurCostPrice { get; set; }

        public string OurStockValue { get; set; }

        public string OurSalesPrice { get; set; }

        public int companyAccountId { get; set; }

        public string LastEditedDate { get; set; }

        public string CreatedDate { get; set; }
    }
    public enum PurchaseOrderReceivedStatus
    {
        FullyReceived = 1,
        PartlyReceived = 2,
        NotReceived = 3,
    }
}
