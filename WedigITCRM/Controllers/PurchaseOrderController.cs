using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;
using WedigITCRM.Utilities;
using WedigITCRM.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WedigITCRM.Controllers
{
    public class PurchaseOrderController : Controller
    {
        public IVendorRepository _vendorRepository;
        private IPurchaseOrderRepository _purchaseOrderRepository;

        public ICurrencyCodeRepository _currencyCodeRepository;

        public PurchaseOrderController(ICurrencyCodeRepository currencyCodeRepository, IVendorRepository vendorRepository, IPurchaseOrderRepository purchaseOrderRepository)
        {
            _currencyCodeRepository = currencyCodeRepository;
            _vendorRepository = vendorRepository;
            _purchaseOrderRepository = purchaseOrderRepository;
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
                PurchaseOrder purchaseOrder = new PurchaseOrder();
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

                purchaseOrder.companyAccountId = companyAccount.companyAccountId;
              
                if (!string.IsNullOrEmpty(model.VendorPaymentConditionId))
                {
                    int paymentConditionId  = int.Parse(model.VendorPaymentConditionId);                  
                    Type enumType = typeof(EnumPaymentConditions);
                    MemberInfo[] x = enumType.GetMember(Enum.GetName(enumType, paymentConditionId));
                    MemberInfo y = x.First();
                    DisplayAttribute z = y.GetCustomAttribute<DisplayAttribute>();
                    purchaseOrder.VendorPaymentConditionsId = model.VendorPaymentConditionId;

                    purchaseOrder.VendorPaymentConditions = z.Name;
                }


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
        public IActionResult getAllVendors( CompanyAccount companyAccount)
        {
            List<Vendor> vendorList = new List<Vendor>();
            List<VendorSelectionModel> vendorOutputList = new List<VendorSelectionModel>();

            vendorList = _vendorRepository.GetAllVendors().Where(vendor => vendor.companyAccountId == companyAccount.companyAccountId).ToList();

            foreach(var vendor in vendorList)
            {
                VendorSelectionModel model  = new VendorSelectionModel();
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
                }
            }
            return Json(model);
        }

        private  string getNextPurchaseOrderNumber(int companyAccountId)
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
     
    }
    public enum PurchaseOrderReceivedStatus
    {
        FullyReceived = 1,
        PartlyReceived = 2,
        NotReceived = 3,        
    }
}
