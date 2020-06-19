using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IStockItemRepository _stockItemRepository;
        private readonly IDeliveryConditionRepository _deliveryConditionRepository;
        private readonly IPaymentConditionRepository _paymentConditionRepository;
        public ICurrencyCodeRepository _currencyCodeRepository;

        public PurchaseOrderController(IWebHostEnvironment hostingEnvironment, IAttachmentRepository attachmentRepository, IStockItemRepository stockItemRepository, IDeliveryConditionRepository deliveryConditionRepository, IPaymentConditionRepository paymentConditionRepository, ICurrencyCodeRepository currencyCodeRepository, IVendorRepository vendorRepository, IPurchaseOrderRepository purchaseOrderRepository, IPurchaseOrderLineRepository purchaseOrderLineRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _attachmentRepository = attachmentRepository;
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
                purchaseOrder.Note = model.Note;

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
                PurchaseOrder purchaseOrderNew = _purchaseOrderRepository.Add(purchaseOrder);

                return RedirectToAction("EditPO", "PurchaseOrder", new { purchaseOrderId = purchaseOrderNew.Id });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult EditPO(int purchaseOrderId)
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

            PurchaseOrder purchaseOrder = _purchaseOrderRepository.GetPurchaseOrder(purchaseOrderId);
            if (purchaseOrder != null)
            {
                PurchaseOrderViewModel model = new PurchaseOrderViewModel();
                model.PurchaseOrderId = purchaseOrder.Id.ToString();
                model.PurchaseOrderDocumentNumber = purchaseOrder.PurchaseOrderDocumentNumber;
                model.VendorId = purchaseOrder.VendorId.ToString();
                model.VendorName = purchaseOrder.VendorName;
                model.VendorStreet = purchaseOrder.VendorStreet;
                model.VendorCity = purchaseOrder.VendorCity;
                model.VendorEmail = purchaseOrder.VendorEmail;
                model.VendorZip = purchaseOrder.VendorZip;
                model.VendorCountryCode = purchaseOrder.VendorCountryCode;
                model.VendorCurrencyCode = purchaseOrder.VendorCurrencyCode;
                model.VendorPhoneNumber = purchaseOrder.VendorPhoneNumber;
                model.VendorHomePage = purchaseOrder.VendorHomePage;
                model.VendorPaymentConditionId = purchaseOrder.VendorPaymentConditionsId;
                model.VendorDeliveryConditionId = purchaseOrder.VendorDeliveryConditionId;
                model.VendorCountryCode = purchaseOrder.VendorCountryCode;
                model.VendorCurrencyCode = purchaseOrder.VendorCurrencyCode;
                model.VendorReference = purchaseOrder.VendorReference;
                model.OurReference = purchaseOrder.OurReference;
                model.Note = purchaseOrder.Note;

                model.AttachedmentIds = purchaseOrder.AttachedmentIds;
                model.AttachedFilesNameAndPath = purchaseOrder.AttachedFilesNameAndPath;
                model.FileNamesOnly = purchaseOrder.FileNamesOnly;
                model.IconsFilePathAndName = purchaseOrder.IconsFilePathAndName;


                model.OurWantedDeliveryDate = purchaseOrder.WantedDeliveryDate.ToString(danishDateTimeformat.ShortDatePattern);
                model.OurOrderingDate = purchaseOrder.OurOrderingDate.ToString(danishDateTimeformat.ShortDatePattern);

                return View(model);
            }


            return View();
        }

        [HttpPost]
        public IActionResult EditPO(PurchaseOrderViewModel model, CompanyAccount companyAccount)
        {
            DateTime testdate;
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

            if (!string.IsNullOrEmpty(model.PurchaseOrderId))
            {
                PurchaseOrder purchaseOrder = _purchaseOrderRepository.GetPurchaseOrder(Int32.Parse(model.PurchaseOrderId));

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
                purchaseOrder.Note = model.Note;
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

                purchaseOrder.LastEditedDate = DateTime.Now;


                _purchaseOrderRepository.Update(purchaseOrder);
            }


            return View(model);
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
                    model.OurCostPrice = stockItem.CostPrice.ToString();
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
            if (string.IsNullOrEmpty(model.Id))
            {
                // PurchaseOrderLine orderLine = _purchaseOrderLineRepository.GetPurchaseOrderLine(Int32.Parse(model.Id));
                PurchaseOrderLine orderLine = new PurchaseOrderLine();
                if (orderLine != null)
                {
                    orderLine.StockItemId = Int32.Parse(model.StockItemId);
                    orderLine.OurUnitCostPrice = Decimal.Parse(model.OurCostPrice);
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
            else
            {
                PurchaseOrderLine orderLine = _purchaseOrderLineRepository.GetPurchaseOrderLine(Int32.Parse(model.Id));
                if (orderLine != null)
                {
                    orderLine.StockItemId = Int32.Parse(model.StockItemId);
                    orderLine.OurUnitCostPrice = Decimal.Parse(model.OurCostPrice);
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

                    _purchaseOrderLineRepository.Update(orderLine);
                }
            }
            return Json(model);
        }

        [HttpPost]
        public IActionResult getOrderLines(string purchaseOrderId, CompanyAccount companyAccount)
        {
            Decimal orderTotal = 0;
            List<PurchaseOrderLineModel> orderLineModels = new List<PurchaseOrderLineModel>();

            if (!string.IsNullOrEmpty(purchaseOrderId))
            {
                List<PurchaseOrderLine> orderLines = _purchaseOrderLineRepository.GetAllpurchaseOrderLines().Where(po => po.PurchaseOrderId == Int32.Parse(purchaseOrderId)).ToList();

                foreach (var orderLine in orderLines)
                {
                    Decimal orderLineTotal = 0;
                    PurchaseOrderLineModel model = new PurchaseOrderLineModel();

                    model.Id = orderLine.Id.ToString();
                    model.OurCostPrice = orderLine.OurUnitCostPrice.ToString();
                    model.OurItemName = orderLine.OurItemName;
                    model.OurItemNumber = orderLine.OurItemNumber;
                    model.StockItemId = orderLine.StockItemId.ToString();
                    model.OurLocation = orderLine.OurLocation;
                    model.OurItemUnit = orderLine.OurUnit;
                    model.QuantityToOrder = orderLine.QuantityToOrder.ToString();
                    model.VendorItemNumber = orderLine.VendorItemNumber;
                    model.VendorItemName = orderLine.VendorItemName;

                    orderLineTotal = orderLine.QuantityToOrder * orderLine.OurUnitCostPrice;
                    orderTotal = orderTotal + orderLineTotal;

                    //model.OrderLineTotalAmount = orderLineTotal.ToString();


                    var danishCulture = CultureInfo.GetCultureInfo("da-DK");
                    model.OrderLineTotalAmount = orderLineTotal.ToString("C", danishCulture);

                    orderLineModels.Add(model);
                }
            }
            return Json(orderLineModels);
        }

        [HttpPost]
        public IActionResult getOrderLineById(string orderLineId, CompanyAccount companyAccount)
        {
            PurchaseOrderLineModel model = new PurchaseOrderLineModel();

            if (!string.IsNullOrEmpty(orderLineId))
            {
                PurchaseOrderLine orderLine = _purchaseOrderLineRepository.GetPurchaseOrderLine(Int32.Parse(orderLineId));

                if (orderLine != null)
                {
                    model.Id = orderLine.Id.ToString();
                    model.OurCostPrice = orderLine.OurUnitCostPrice.ToString();
                    model.OurItemName = orderLine.OurItemName;
                    model.OurItemNumber = orderLine.OurItemNumber;
                    model.StockItemId = orderLine.StockItemId.ToString();
                    model.OurLocation = orderLine.OurLocation;
                    model.OurItemUnit = orderLine.OurUnit;
                    model.QuantityToOrder = orderLine.QuantityToOrder.ToString();
                    model.VendorItemNumber = orderLine.VendorItemNumber;
                    model.VendorItemName = orderLine.VendorItemName;
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

        public IActionResult deleteAttachment(string Id, CompanyAccount companyAccount)
        {

            if (!string.IsNullOrEmpty(Id))
            {
                Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(Id));
                if (attachment != null)
                {
                    string filePathAndFileName = _hostingEnvironment.WebRootPath + "\\" + "CustomerAttachments" + "\\" + attachment.uniqueInternalFileName;
                    if (System.IO.File.Exists(filePathAndFileName))
                    {
                        System.IO.File.Delete(filePathAndFileName);
                    }
                    _attachmentRepository.Delete(attachment.Id);
                }


                List<PurchaseOrder> purchaseOrderNoteList = _purchaseOrderRepository.GetAllPurchaseOrders().Where(purchaseOrder => !string.IsNullOrEmpty(purchaseOrder.AttachedmentIds) && purchaseOrder.AttachedmentIds.Contains(Id)).ToList();
                if (purchaseOrderNoteList.Count == 1)
                {
                    PurchaseOrder purchaseOrder = purchaseOrderNoteList.First();

                    List<string> ExistingAttachedmentIdsList = purchaseOrder.AttachedmentIds.Split(",").ToList();
                    List<string> ExistingFileNamesOnlyList = purchaseOrder.FileNamesOnly.Split(",").ToList();
                    List<string> AttachedFilesNameAndPathList = purchaseOrder.AttachedFilesNameAndPath.Split(",").ToList();
                    List<string> IconsFilePathAndNameList = purchaseOrder.IconsFilePathAndName.Split(",").ToList();

                    int index = ExistingAttachedmentIdsList.IndexOf(Id);

                    ExistingAttachedmentIdsList.RemoveAt(index);
                    ExistingFileNamesOnlyList.RemoveAt(index);
                    AttachedFilesNameAndPathList.RemoveAt(index);
                    IconsFilePathAndNameList.RemoveAt(index);

                    if (ExistingAttachedmentIdsList.Count == 0)
                    {
                        purchaseOrder.AttachedmentIds = null;
                        purchaseOrder.FileNamesOnly = null;
                        purchaseOrder.AttachedFilesNameAndPath = null;
                        purchaseOrder.IconsFilePathAndName = null;
                    }
                    else
                    {
                        purchaseOrder.AttachedmentIds = string.Join(",", ExistingAttachedmentIdsList.ToArray());
                        purchaseOrder.FileNamesOnly = string.Join(",", ExistingFileNamesOnlyList.ToArray());
                        purchaseOrder.AttachedFilesNameAndPath = string.Join(",", AttachedFilesNameAndPathList.ToArray());
                        purchaseOrder.IconsFilePathAndName = string.Join(",", IconsFilePathAndNameList.ToArray());
                    }

                    _purchaseOrderRepository.Update(purchaseOrder);
                }
            }

            return RedirectToAction("Index", "Note");
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
        public string StockItemId { get; set; }

        public string OurStockValue { get; set; }

        public string OurSalesPrice { get; set; }

        public string OrderLineTotalAmount { get; set; }

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
