using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Google.Apis.Util;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;
using WedigITCRM.Utilities;
using WedigITCRM.ViewModels;
using X.PagedList;

namespace WedigITCRM.Controllers
{
    public class PurchaseOrderController : Controller
    {
        public IVendorRepository _vendorRepository;
        private IPurchaseOrderRepository _purchaseOrderRepository;
        private IPurchaseOrderLineRepository _purchaseOrderLineRepository;
        private readonly PurchaseOrderToHTML _purchaseOrderToHTML;
        private readonly IPurchaseBudgetRepository _purchaseBudgetRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly PurchaseOrderAddAttachment _purchaseOrderAddAttachment;
        private readonly EmailUtility _emailUtility;
        private readonly PurchaseOrderToPDF _purchaseOrderToPDF;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IStockItemRepository _stockItemRepository;
        private readonly IDeliveryConditionRepository _deliveryConditionRepository;
        private readonly IPaymentConditionRepository _paymentConditionRepository;
        public ICurrencyCodeRepository _currencyCodeRepository;

        public PurchaseOrderController(IPurchaseBudgetRepository purchaseBudgetRepository, UserManager<IdentityUser> userManager, PurchaseOrderAddAttachment purchaseOrderAddAttachment, EmailUtility emailUtility, PurchaseOrderToPDF purchaseOrderToPDF, PurchaseOrderToHTML purchaseOrderToHTML, IWebHostEnvironment hostingEnvironment, IAttachmentRepository attachmentRepository, IStockItemRepository stockItemRepository, IDeliveryConditionRepository deliveryConditionRepository, IPaymentConditionRepository paymentConditionRepository, ICurrencyCodeRepository currencyCodeRepository, IVendorRepository vendorRepository, IPurchaseOrderRepository purchaseOrderRepository, IPurchaseOrderLineRepository purchaseOrderLineRepository)
        {
           _purchaseBudgetRepository = purchaseBudgetRepository;
            _userManager = userManager;
            _purchaseOrderAddAttachment = purchaseOrderAddAttachment;
            _emailUtility = emailUtility;
            _purchaseOrderToPDF = purchaseOrderToPDF;
            _purchaseOrderToHTML = purchaseOrderToHTML;
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

        public IActionResult Index(int? page, string receivedStatus, string vendorId, string purchaseDocumentNumber, string searchFromDate, string searchToDate, CompanyAccount companyAccount)
        {
            DateTime testdate;
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            var pageNumber = page ?? 1;
            int pageSize = 3;

            SearchPurchaseOrderViewModel model = new SearchPurchaseOrderViewModel();
            List<PurchaseOrder> allPurchaseOrderList = _purchaseOrderRepository.GetAllPurchaseOrders().ToList();
            foreach (var purchaseOrder in allPurchaseOrderList)
            {
                model.SearchByPurchaseDocumentNumber.Add(new SelectListItem { Value = purchaseOrder.PurchaseOrderDocumentNumber, Text = purchaseOrder.PurchaseOrderDocumentNumber });
            }

            //model.PurchaseOrders = allPurchaseOrderList.ToPagedList(pageNumber, pageSize);

            List<Vendor> vendorList = _vendorRepository.GetAllVendors().Where(vendor => vendor.companyAccountId == companyAccount.companyAccountId).ToList();
            foreach (var vendor in vendorList)
            {
                model.SearchByVendor.Add(new SelectListItem { Value = vendor.Id.ToString(), Text = vendor.Name });
            }


            if (!string.IsNullOrEmpty(receivedStatus) && !receivedStatus.Equals("0"))
            {
                allPurchaseOrderList = allPurchaseOrderList.Where(purchaseOrder => purchaseOrder.ReceivedStatus.ToString().Equals(receivedStatus)).ToList();
            }
            if (!string.IsNullOrEmpty(vendorId) && !vendorId.Equals("0"))
            {
                allPurchaseOrderList = allPurchaseOrderList.Where(purchaseOrder => purchaseOrder.VendorId.ToString().Equals(vendorId)).ToList();
            }
            if (!string.IsNullOrEmpty(purchaseDocumentNumber) && !purchaseDocumentNumber.Equals("0"))
            {
                allPurchaseOrderList = allPurchaseOrderList.Where(purchaseOrder => purchaseOrder.PurchaseOrderDocumentNumber.Equals(purchaseDocumentNumber)).ToList();
            }
            if (!string.IsNullOrEmpty(searchFromDate))
            {
                if (DateTime.TryParse(searchFromDate, out testdate))
                {
                    DateTime dateTimeFromDate = DateTime.Parse(searchFromDate, danishDateTimeformat);
                    allPurchaseOrderList = allPurchaseOrderList.Where(purchaseOrder => purchaseOrder.OurOrderingDate > dateTimeFromDate).ToList();
                }
            }
            if (!string.IsNullOrEmpty(searchToDate))
            {
                if (DateTime.TryParse(searchToDate, out testdate))
                {
                    DateTime dateTimeToDate = DateTime.Parse(searchToDate, danishDateTimeformat);
                    allPurchaseOrderList = allPurchaseOrderList.Where(purchaseOrder => purchaseOrder.OurOrderingDate < dateTimeToDate).ToList();
                }
            }

            List<PurchaseOrderViewLineModel> PurchaseOrderViewLines = new List<PurchaseOrderViewLineModel>();
            foreach (var purchaseOrder in allPurchaseOrderList)
            {
                PurchaseOrderViewLineModel purchaseOrderViewLineModel = new PurchaseOrderViewLineModel();
                purchaseOrderViewLineModel.Id = purchaseOrder.Id.ToString();
                purchaseOrderViewLineModel.PurchaseOrderDocumentNumber = purchaseOrder.PurchaseOrderDocumentNumber;
                purchaseOrderViewLineModel.VendorName = purchaseOrder.VendorName;
                if (purchaseOrder.OurOrderingDate == DateTime.MinValue)
                {
                    purchaseOrderViewLineModel.OurOrderingDate = "";
                }
                else
                {
                    purchaseOrderViewLineModel.OurOrderingDate = purchaseOrder.OurOrderingDate.ToString(danishDateTimeformat.ShortDatePattern);
                }

                if (purchaseOrder.SendToVendorDate == DateTime.MinValue)
                {
                    purchaseOrderViewLineModel.SendToVendorDate = "";
                }
                else
                {
                    purchaseOrderViewLineModel.SendToVendorDate = purchaseOrder.SendToVendorDate.ToString(danishDateTimeformat.ShortDatePattern);
                }

                SelectListItem selItem = model.SearchByReceivedStatus.Find(element => element.Value.Equals(purchaseOrder.ReceivedStatus));
                purchaseOrderViewLineModel.ReceivedStatus = selItem.Text;

                PurchaseOrderViewLines.Add(purchaseOrderViewLineModel);
            }

            model.PurchaseOrdersViewLines = PurchaseOrderViewLines.ToPagedList(pageNumber, pageSize);
            return View(model);
        }



        [HttpGet]
        public IActionResult CreatePO()
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            DateTime myNow = DateTime.Now;

            PurchaseOrderViewModel model = new PurchaseOrderViewModel();
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = _userManager.FindByIdAsync(currentUserId).Result;
            if (currentUser != null)
            {
                model.OurReference = currentUser.UserName;
            }

            model.OurOrderingDate = myNow.ToString(danishDateTimeformat.ShortDatePattern);
            myNow = myNow.AddDays(14);
            model.OurWantedDeliveryDate = myNow.ToString(danishDateTimeformat.ShortDatePattern);
            return View(model);
        }

        [HttpPost]
        public IActionResult CreatePO(PurchaseOrderViewModel model, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.VendorId))
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
                    purchaseOrder.ReceivedStatus = "1";

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


        [HttpGet]
        public IActionResult ReorderPO(int purchaseOrderId, CompanyAccount companyAccount)
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

            PurchaseOrder purchaseOrder = _purchaseOrderRepository.GetPurchaseOrder(purchaseOrderId);
            if (purchaseOrder != null)
            {

                PurchaseOrder reorderPurchaseOrder = new PurchaseOrder();

                reorderPurchaseOrder.VendorId = purchaseOrder.VendorId;
                reorderPurchaseOrder.VendorName = purchaseOrder.VendorName;
                reorderPurchaseOrder.VendorStreet = purchaseOrder.VendorStreet;
                reorderPurchaseOrder.VendorCity = purchaseOrder.VendorCity;
                reorderPurchaseOrder.VendorEmail = purchaseOrder.VendorEmail;
                reorderPurchaseOrder.VendorZip = purchaseOrder.VendorZip;
                reorderPurchaseOrder.VendorCountryCode = purchaseOrder.VendorCountryCode;
                reorderPurchaseOrder.VendorCurrencyCode = purchaseOrder.VendorCurrencyCode;
                reorderPurchaseOrder.VendorPhoneNumber = purchaseOrder.VendorPhoneNumber;
                reorderPurchaseOrder.VendorHomePage = purchaseOrder.VendorHomePage;
                reorderPurchaseOrder.VendorPaymentConditionsId = purchaseOrder.VendorPaymentConditionsId;
                reorderPurchaseOrder.VendorDeliveryConditionId = purchaseOrder.VendorDeliveryConditionId;
                reorderPurchaseOrder.VendorCountryCode = purchaseOrder.VendorCountryCode;
                reorderPurchaseOrder.VendorCurrencyCode = purchaseOrder.VendorCurrencyCode;
                reorderPurchaseOrder.VendorReference = purchaseOrder.VendorReference;

                var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var currentUser = _userManager.FindByIdAsync(currentUserId).Result;
                if (currentUser != null)
                {
                    reorderPurchaseOrder.OurReference = currentUser.UserName;
                }

                reorderPurchaseOrder.Note = purchaseOrder.Note;

                DateTime myNow = DateTime.Now;

                reorderPurchaseOrder.OurOrderingDate = myNow;
                myNow = myNow.AddDays(14);
                reorderPurchaseOrder.WantedDeliveryDate = myNow;

                reorderPurchaseOrder.ReceivedStatus = "1";
                reorderPurchaseOrder.companyAccountId = companyAccount.companyAccountId;

                reorderPurchaseOrder.CreatedDate = DateTime.Now;
                reorderPurchaseOrder.LastEditedDate = DateTime.Now;

                string DocumentNumber = getNextPurchaseOrderNumber(companyAccount.companyAccountId);
                reorderPurchaseOrder.PurchaseOrderDocumentNumber = DocumentNumber;
                PurchaseOrder purchaseOrderNew = _purchaseOrderRepository.Add(reorderPurchaseOrder);


                List<PurchaseOrderLine> orderLines = _purchaseOrderLineRepository.GetAllpurchaseOrderLines().Where(orderLine => orderLine.PurchaseOrderId == purchaseOrder.Id).ToList();
                foreach (var orderLine in orderLines)
                {
                    PurchaseOrderLine newOrderLine = new PurchaseOrderLine();

                    newOrderLine.PurchaseOrderId = reorderPurchaseOrder.Id;
                    newOrderLine.OurUnitCostPrice = orderLine.OurUnitCostPrice;
                    newOrderLine.OurItemName = orderLine.OurItemName;
                    newOrderLine.OurItemNumber = orderLine.OurItemNumber;
                    newOrderLine.StockItemId = orderLine.StockItemId;
                    newOrderLine.OurLocation = orderLine.OurLocation;
                    newOrderLine.OurUnit = orderLine.OurUnit;
                    newOrderLine.QuantityToOrder = orderLine.QuantityToOrder;
                    newOrderLine.VendorItemNumber = orderLine.VendorItemNumber;
                    newOrderLine.VendorItemName = orderLine.VendorItemName;

                    newOrderLine.companyAccountId = orderLine.companyAccountId;
                    _purchaseOrderLineRepository.Add(newOrderLine);

                }

                return RedirectToAction("EditPO", "PurchaseOrder", new { purchaseOrderId = purchaseOrderNew.Id });
            }

            return View();
        }


        [HttpGet]
        public IActionResult Delete(int purchaseOrderId, CompanyAccount companyAccount)
        {
            PurchaseOrder purchaseOrder = _purchaseOrderRepository.GetPurchaseOrder(purchaseOrderId);
            if (purchaseOrder != null)
            {
                if (!string.IsNullOrEmpty(purchaseOrder.AttachedmentIds))
                {
                    List<string> AttachedmentIdsList = purchaseOrder.AttachedmentIds.Split(",").ToList();

                    foreach (var attachmentId in AttachedmentIdsList)
                    {
                        EntitityModels.Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(attachmentId));
                        if (attachment != null)
                        {
                            string filePathAndFileName = _hostingEnvironment.WebRootPath + "\\" + "CustomerAttachments" + "\\" + attachment.uniqueInternalFileName;
                            if (System.IO.File.Exists(filePathAndFileName))
                            {
                                System.IO.File.Delete(filePathAndFileName);
                            }

                            _attachmentRepository.Delete(attachment.Id);
                        }
                    }
                }


                List<PurchaseOrderLine> orderLines = _purchaseOrderLineRepository.GetAllpurchaseOrderLines().Where(orderLine => orderLine.PurchaseOrderId == purchaseOrder.Id).ToList();
                foreach (var orderLine in orderLines)
                {
                    _purchaseOrderLineRepository.Delete(orderLine.Id);
                }


                _purchaseOrderRepository.Delete(purchaseOrderId);
            }

            return RedirectToAction("index", "PurchaseOrder");
        }



        [HttpGet]
        public IActionResult CreatePurchaseBudget()
        {
            PurchaseBudgetViewModel model = new PurchaseBudgetViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult CreatePurchaseBudget(PurchaseBudgetViewModel model, CompanyAccount companyAccount)
        {
            DateTime periodFromDate = DateTime.MinValue;
            DateTime periodToDate = DateTime.MinValue;
            DateTime testdate;
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

            if (model.Period.Equals("0"))
            {
                ModelState.AddModelError("Period", "Der skal vælges en periode");
                return View(model);
            }

            if (!string.IsNullOrEmpty(model.PeriodFromDate))
            {
                if (DateTime.TryParse(model.PeriodFromDate, out testdate))
                {
                    periodFromDate = DateTime.Parse(model.PeriodFromDate, danishDateTimeformat);
                }
            }
            else
            {
                ModelState.AddModelError("PeriodFromDate", "Der skal vælges en startdato");
                return View(model);
            }

            if (model.Period.Equals("5"))
            {
                if (!string.IsNullOrEmpty(model.PeriodToDate))
                {
                    if (DateTime.TryParse(model.PeriodToDate, out testdate))
                    {
                        periodToDate = DateTime.Parse(model.PeriodToDate, danishDateTimeformat);
                    }
                }

                else
                {
                    ModelState.AddModelError("PeriodFromDate", "Der skal vælges en slutdato");
                    return View(model);
                }
            }

            PurchaseBudget purchaseBudget = new PurchaseBudget();

            purchaseBudget.Period = model.Period;

            purchaseBudget.StartDateOfPeriod = periodFromDate;
            purchaseBudget.EndDateOfPeriod = periodToDate;

            purchaseBudget.companyAccountId = companyAccount.companyAccountId;
            purchaseBudget.CreatedDate = DateTime.Now;
            purchaseBudget.LastEditedDate = DateTime.Now;

            PurchaseBudget purchaseBudgetNew = _purchaseBudgetRepository.Add(purchaseBudget);

            return View(model);
        }

        [HttpGet]
        public IActionResult EditPurchaseBudget(int purchaseOrderId)
        {
            PurchaseBudgetEditViewModel model = new PurchaseBudgetEditViewModel();


            model.StockItems =_stockItemRepository.GetAllstockItems().ToList();
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

        [HttpPost]
        public IActionResult deleteOrderLineById(string orderLineId, string purchaseOrderId, CompanyAccount companyAccount)
        {
            PurchaseOrderLineModel model = new PurchaseOrderLineModel();

            if (!string.IsNullOrEmpty(purchaseOrderId))
            {
                PurchaseOrder purchaseOrder = _purchaseOrderRepository.GetPurchaseOrder(Int32.Parse(purchaseOrderId));
                if (purchaseOrder != null)
                {
                    if (!string.IsNullOrEmpty(orderLineId))
                    {
                        PurchaseOrderLine orderLine = _purchaseOrderLineRepository.GetPurchaseOrderLine(Int32.Parse(orderLineId));

                        if (orderLine != null)
                        {
                            _purchaseOrderLineRepository.Delete(Int32.Parse(orderLineId));
                        }
                    }
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
                EntitityModels.Attachment attachment = _attachmentRepository.GetAttachment(Int32.Parse(Id));
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
                    return RedirectToAction("EditPO", "PurchaseOrder", new { purchaseOrderId = purchaseOrder.Id });
                }
            }

            return RedirectToAction("Index", "Note");
        }


        public IActionResult sendPurchaseOrder(int purchaseOrderId, CompanyAccount companyAccount)
        {

            PurchaseOrder purchaseOrder = _purchaseOrderRepository.GetPurchaseOrder(purchaseOrderId);
            if (purchaseOrder != null)
            {
                string purchaseOrdersFolder = _hostingEnvironment.WebRootPath + "\\" + "CustomerAttachments";

                string uniquePDFFileName = Guid.NewGuid().ToString() + "_" + "purchaseOrder.pdf";
                string uniquePDFFilePathAndName = purchaseOrdersFolder + "\\" + uniquePDFFileName;


                string purchaseOrderHTML = _purchaseOrderToHTML.generateHTML(purchaseOrder, companyAccount);


                if (_purchaseOrderToPDF.generatePurchaseOrderPDF(purchaseOrderHTML, uniquePDFFilePathAndName))
                {
                    WedigITCRM.EntitityModels.Attachment attachment = new WedigITCRM.EntitityModels.Attachment();
                    attachment.ContentType = "application/pdf";
                    FileInfo info = new FileInfo(uniquePDFFilePathAndName);
                    attachment.length = info.Length;
                    attachment.OriginalFileName = "purchaseOrder.pdf";
                    attachment.uniqueInternalFileName = uniquePDFFileName;
                    attachment.companyAccountId = companyAccount.companyAccountId;
                    WedigITCRM.EntitityModels.Attachment newAttachment = _attachmentRepository.Add(attachment);

                    _purchaseOrderAddAttachment.addAttacment(purchaseOrder, uniquePDFFileName, uniquePDFFilePathAndName, attachment);

                    Dictionary<string, string> tokens = new Dictionary<string, string>();
                    tokens.Add("ourcompanyname", companyAccount.CompanyName);
                    tokens.Add("ourcompanystreet", companyAccount.CompanyStreet);
                    tokens.Add("ourcompanyzip", companyAccount.CompanyZip);
                    tokens.Add("ourcompanycity", companyAccount.CompanyCity);

                    tokens.Add("ourreference", purchaseOrder.OurReference);
                    tokens.Add("purchaseordernumber", purchaseOrder.PurchaseOrderDocumentNumber);

                    if (!string.IsNullOrEmpty(purchaseOrder.VendorEmail))
                    {
                        string vendorReceipient = purchaseOrder.VendorEmail;
                        AlternateView htmlView = _emailUtility.getFormattedBodyByMailtemplate(EmailUtility.MailTemplateType.PurchaseOrder, tokens);
                        _emailUtility.send(vendorReceipient, "support@nyxium.dk", "Indkøbsordre nr.: " + purchaseOrder.PurchaseOrderDocumentNumber, htmlView, true, uniquePDFFilePathAndName);
                        purchaseOrder.SendToVendorDate = DateTime.Now;
                        purchaseOrder.LastEditedDate = DateTime.Now;

                        _purchaseOrderRepository.Update(purchaseOrder);
                    }
                }
            }


            return RedirectToAction("EditPO", "PurchaseOrder", new { purchaseOrderId = purchaseOrderId });
        }

        [HttpGet]
        public IActionResult receivePurchaseOrder(int purchaseOrderId, CompanyAccount companyAccount)
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

            PurchaseOrderReceiveViewModel model = new PurchaseOrderReceiveViewModel();

            PurchaseOrder purchaseOrder = _purchaseOrderRepository.GetPurchaseOrder(purchaseOrderId);
            if (purchaseOrder != null)
            {

                model.PurchaseOrderId = purchaseOrder.Id.ToString();
                model.PurchaseOrderDocumentNumber = purchaseOrder.PurchaseOrderDocumentNumber;
                model.VendorId = purchaseOrder.VendorId.ToString();
                model.VendorName = purchaseOrder.VendorName;

                model.VendorPaymentConditionId = purchaseOrder.VendorPaymentConditionsId;

                model.VendorReference = purchaseOrder.VendorReference;
                model.OurReference = purchaseOrder.OurReference;
                model.Note = purchaseOrder.Note;

                model.AttachedmentIds = purchaseOrder.AttachedmentIds;
                model.AttachedFilesNameAndPath = purchaseOrder.AttachedFilesNameAndPath;
                model.FileNamesOnly = purchaseOrder.FileNamesOnly;
                model.IconsFilePathAndName = purchaseOrder.IconsFilePathAndName;


                model.OurWantedDeliveryDate = purchaseOrder.WantedDeliveryDate.ToString(danishDateTimeformat.ShortDatePattern);
                model.OurOrderingDate = purchaseOrder.OurOrderingDate.ToString(danishDateTimeformat.ShortDatePattern);

                List<PurchaseOrderLine> purchaseOrderLines = _purchaseOrderLineRepository.GetAllpurchaseOrderLines().Where(purchaseOrderLine => purchaseOrderLine.PurchaseOrderId == purchaseOrder.Id).ToList();
                List<PurchaseOrderLineReceiveModel> orderLinesToReceive = new List<PurchaseOrderLineReceiveModel>();
                foreach (var orderLine in purchaseOrderLines)
                {
                    PurchaseOrderLineReceiveModel purchaseOrderLineReceiveModel = new PurchaseOrderLineReceiveModel();
                    purchaseOrderLineReceiveModel.Id = orderLine.Id.ToString();
                    purchaseOrderLineReceiveModel.OurCostPrice = orderLine.OurUnitCostPrice.ToString();
                    purchaseOrderLineReceiveModel.QuantityToOrder = orderLine.QuantityToOrder.ToString();

                    purchaseOrderLineReceiveModel.QuantityReceivedUntillNow = orderLine.QuantityReceivedUntillNow.ToString();
                    purchaseOrderLineReceiveModel.QuantityStillToReceive = (orderLine.QuantityToOrder - orderLine.QuantityReceivedUntillNow).ToString();

                    purchaseOrderLineReceiveModel.OurItemName = orderLine.OurItemName;
                    purchaseOrderLineReceiveModel.OurItemNumber = orderLine.OurItemNumber;
                    purchaseOrderLineReceiveModel.VendorItemName = orderLine.VendorItemName;
                    purchaseOrderLineReceiveModel.VendorItemNumber = orderLine.VendorItemNumber;
                    purchaseOrderLineReceiveModel.StockItemId = orderLine.StockItemId.ToString();
                    purchaseOrderLineReceiveModel.IsSelected = false;
                    orderLinesToReceive.Add(purchaseOrderLineReceiveModel);



                }
                model.OrderLinesToReceive = orderLinesToReceive;
                return View(model);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult receivePurchaseOrder(PurchaseOrderReceiveViewModel model, CompanyAccount companyAccount)
        {
            Decimal testDecimal;
            Decimal quantityStillToReceive;
            Decimal orderedQuantity;
            Decimal quantityReceivedUntillNow;
            if (ModelState.IsValid)
            {
                bool orderCompleteReceived = true;

                foreach (var receivedOrderLine in model.OrderLinesToReceive)
                {
                    if (Decimal.TryParse(receivedOrderLine.QuantityStillToReceive, out testDecimal))
                    {
                        quantityStillToReceive = Decimal.Parse(receivedOrderLine.QuantityStillToReceive);
                        if (Decimal.TryParse(receivedOrderLine.QuantityToOrder, out testDecimal))
                        {
                            quantityReceivedUntillNow = Decimal.Parse(receivedOrderLine.QuantityReceivedUntillNow);
                            orderedQuantity = Decimal.Parse(receivedOrderLine.QuantityToOrder);
                            if ((quantityReceivedUntillNow + quantityStillToReceive) != orderedQuantity)
                            {
                                if (!receivedOrderLine.IsSelected)
                                {
                                    orderCompleteReceived = false;
                                }
                            }

                            int stockItemId = Int32.Parse(receivedOrderLine.StockItemId);
                            StockItem stockItem = _stockItemRepository.getStockItem(stockItemId);
                            stockItem.NumberInStock = stockItem.NumberInStock + quantityStillToReceive;
                            _stockItemRepository.Update(stockItem);

                            PurchaseOrderLine purchaseOrderLine = _purchaseOrderLineRepository.GetPurchaseOrderLine(Int32.Parse(receivedOrderLine.Id));
                            if (purchaseOrderLine != null)
                            {
                                purchaseOrderLine.QuantityReceivedUntillNow = purchaseOrderLine.QuantityReceivedUntillNow + quantityStillToReceive;
                                _purchaseOrderLineRepository.Update(purchaseOrderLine);
                            }
                        }
                        else
                        {
                            orderCompleteReceived = false;
                        }
                    }
                    else
                    {
                        orderCompleteReceived = false;
                    }
                }

                if (!string.IsNullOrEmpty(model.PurchaseOrderId))
                {
                    PurchaseOrder purchaseOrder = _purchaseOrderRepository.GetPurchaseOrder(Int32.Parse(model.PurchaseOrderId));
                    if (purchaseOrder != null)
                    {
                        if (orderCompleteReceived)
                        {
                            purchaseOrder.ReceivedStatus = "1";
                        }
                        else
                        {
                            purchaseOrder.ReceivedStatus = "3";
                        }
                        _purchaseOrderRepository.Update(purchaseOrder);
                    }
                }
            }

            return RedirectToAction("receivePurchaseOrder", "PurchaseOrder", new { purchaseOrderId = Int32.Parse(model.PurchaseOrderId) });
        }
    }

    public class PurchaseOrderLineReceiveModel
    {
        public string Id { get; set; }
        public string OurCostPrice { get; set; }
        public string OurUnitCostPrice { get; set; }

        public string OurItemName { get; set; }
        public string OurItemNumber { get; set; }
        public string StockItemId { get; set; }
        public string OurItemUnit { get; set; }
        public string VendorItemName { get; set; }
        public string VendorItemNumber { get; set; }
        public string QuantityToOrder { get; set; }
        public string QuantityReceivedUntillNow { get; set; }
        public string QuantityStillToReceive { get; set; }
        public bool IsSelected { get; set; }
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

    public class PurchaseBudgetLineModel
    {
        public string Id { get; set; }
        public string StockItemId { get; set; }
        public string PeriodLineId { get; set; }
        public string OurItemName { get; set; }
        public string OurItemUnit { get; set; }
        public string OurItemNumber { get; set; }
        public string QuantityToOrder { get; set; }
        public int companyAccountId { get; set; }       
        public string OurCostPrice { get; set; }
    }

}






