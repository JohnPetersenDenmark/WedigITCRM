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
using WedigITCRM.DineroAPI;
using WedigITCRM.EntitityModels;
using WedigITCRM.Migrations;
using WedigITCRM.StorageInterfaces;
using WedigITCRM.Utilities;
using WedigITCRM.ViewModels;
using X.PagedList;
using static WedigITCRM.DineroAPI.DineroInvoice;

namespace WedigITCRM.Controllers
{
    public class PurchaseOrderController : Controller
    {
        public IVendorRepository _vendorRepository;
        private IPurchaseOrderRepository _purchaseOrderRepository;
        private IPurchaseOrderLineRepository _purchaseOrderLineRepository;
        private readonly PurchaseOrderToHTML _purchaseOrderToHTML;
        private readonly IStockItemCategory1Repository _stockItemCategory1Repository;
        private readonly IStockItemCategory2Repository _stockItemCategory2Repository;
        private readonly IStockItemCategory3Repository _stockItemCategory3Repository;
        private readonly IPurchaseBudgetPeriodLineRepository _purchaseBudgetPeriodLineRepository;
        private readonly IPurchaseBudgetLineRepository _purchaseBudgetLinesRepository;
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

        public PurchaseOrderController(IStockItemCategory1Repository stockItemCategory1Repository, IStockItemCategory2Repository stockItemCategory2Repository, IStockItemCategory3Repository stockItemCategory3Repository, IPurchaseBudgetPeriodLineRepository purchaseBudgetPeriodLineRepository, IPurchaseBudgetLineRepository purchaseBudgetLinesRepository, IPurchaseBudgetRepository purchaseBudgetRepository, UserManager<IdentityUser> userManager, PurchaseOrderAddAttachment purchaseOrderAddAttachment, EmailUtility emailUtility, PurchaseOrderToPDF purchaseOrderToPDF, PurchaseOrderToHTML purchaseOrderToHTML, IWebHostEnvironment hostingEnvironment, IAttachmentRepository attachmentRepository, IStockItemRepository stockItemRepository, IDeliveryConditionRepository deliveryConditionRepository, IPaymentConditionRepository paymentConditionRepository, ICurrencyCodeRepository currencyCodeRepository, IVendorRepository vendorRepository, IPurchaseOrderRepository purchaseOrderRepository, IPurchaseOrderLineRepository purchaseOrderLineRepository)
        {
            _stockItemCategory1Repository = stockItemCategory1Repository;
            _stockItemCategory2Repository = stockItemCategory2Repository;
            _stockItemCategory3Repository = stockItemCategory3Repository;
            _purchaseBudgetPeriodLineRepository = purchaseBudgetPeriodLineRepository;
            _purchaseBudgetLinesRepository = purchaseBudgetLinesRepository;
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
        public IActionResult IndexBudget(int? page, CompanyAccount companyAccount)
        {
            var pageNumber = page ?? 1;
            int pageSize = 10;

            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            List<PurchaseBudgetViewModel> purchaseBudgetListModel = new List<PurchaseBudgetViewModel>();

            List<PurchaseBudget> purchaseBudgetList = _purchaseBudgetRepository.GetAllPurchaseBudgets().Where(budget => budget.companyAccountId == companyAccount.companyAccountId).OrderByDescending(budget => budget.StartDateOfPeriod).ToList();

            foreach (var purchaseBudget in purchaseBudgetList)
            {
                PurchaseBudgetViewModel purchaseBudgetViewModel = new PurchaseBudgetViewModel();

                purchaseBudgetViewModel.Id = purchaseBudget.Id.ToString(); ;
                purchaseBudgetViewModel.Description = purchaseBudget.Description;
                purchaseBudgetViewModel.PeriodFromDate = purchaseBudget.StartDateOfPeriod.ToString(danishDateTimeformat.ShortDatePattern);
                purchaseBudgetViewModel.PeriodToDate = purchaseBudget.EndDateOfPeriod.ToString(danishDateTimeformat.ShortDatePattern);

                SelectListItem selItem = purchaseBudgetViewModel.SelectPeriod.Find(element => element.Value.Equals(purchaseBudget.Period));
                purchaseBudgetViewModel.Period = selItem.Text;

                purchaseBudgetListModel.Add(purchaseBudgetViewModel);
            }

            IPagedList<PurchaseBudgetViewModel> model = purchaseBudgetListModel.ToPagedList(pageNumber, pageSize);

            return View(model);
        }

        [HttpGet]
        public IActionResult CreatePurchaseBudget()
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            PurchaseBudgetViewModel model = new PurchaseBudgetViewModel();
            DateTime myNow = DateTime.Now;
            model.PeriodFromDate = myNow.ToString(danishDateTimeformat.ShortDatePattern);
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

            if (string.IsNullOrEmpty(model.Description))
            {
                ModelState.AddModelError("Description", "Der skal angives en beskrivelse");
                return View(model);
            }

            if (!string.IsNullOrEmpty(model.PeriodFromDate))
            {
                if (DateTime.TryParse(model.PeriodFromDate, out testdate))
                {
                    periodFromDate = DateTime.Parse(model.PeriodFromDate, danishDateTimeformat);
                }
                else
                {
                    ModelState.AddModelError("PeriodFromDate", "Ikke en gyldig dato");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("PeriodFromDate", "Der skal vælges en startdato");
                return View(model);
            }

            if (model.Period.Equals("6"))
            {
                if (!string.IsNullOrEmpty(model.PeriodToDate))
                {
                    if (DateTime.TryParse(model.PeriodToDate, out testdate))
                    {
                        periodToDate = DateTime.Parse(model.PeriodToDate, danishDateTimeformat);

                        TimeSpan difference = periodToDate - periodFromDate;
                        var days = difference.TotalDays;
                        if (difference.TotalDays > 6)
                        {
                            ModelState.AddModelError("PeriodToDate", "Der er mere end 6 dage mellem startdato og slutdato");
                            return View(model);
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("PeriodToDate", "Ikke en gyldig dato");
                        return View(model);
                    }
                }

                else
                {
                    ModelState.AddModelError("PeriodToDate", "Der skal vælges en slutdato");
                    return View(model);
                }
            }
            else
            {

            }

            PurchaseBudget purchaseBudget = new PurchaseBudget();

            purchaseBudget.Period = model.Period;

            purchaseBudget.Description = model.Description;
                      
            purchaseBudget.companyAccountId = companyAccount.companyAccountId;
            purchaseBudget.CreatedDate = DateTime.Now;
            purchaseBudget.LastEditedDate = DateTime.Now;

            PurchaseBudget purchaseBudgetNew = _purchaseBudgetRepository.Add(purchaseBudget);

            int numberOfPeriodLines = 0;
            int PeriodLineUnit = 0;
            DateTime periodStartDateTime = DateTime.MinValue;
            DateTime periodEndDateTime = DateTime.MinValue;
            int weekNo;



            switch (model.Period)
            {
                case "1":                       // 1 year
                    numberOfPeriodLines = 12;
                    PeriodLineUnit = 1;
                    periodStartDateTime = new DateTime(periodFromDate.Year, periodFromDate.Month, 1);
                    periodFromDate = periodStartDateTime;
                    periodToDate = periodStartDateTime.AddMonths(12).AddDays(-1);
                    break;
                case "2":                       // 1/2 year
                    numberOfPeriodLines = 6;
                    PeriodLineUnit = 1;
                    periodStartDateTime = new DateTime(periodFromDate.Year, periodFromDate.Month, 1);
                    periodFromDate = periodStartDateTime;
                    periodToDate = periodStartDateTime.AddMonths(6).AddDays(-1);
                    break;
                case "3":                       // A Quarter
                    numberOfPeriodLines = 3;
                    PeriodLineUnit = 1;
                    periodStartDateTime = new DateTime(periodFromDate.Year, periodFromDate.Month, 1);
                    periodFromDate = periodStartDateTime;
                    periodToDate = periodStartDateTime.AddMonths(3).AddDays(-1);
                    break;
                case "4":                       // 1 Month as weeks
                    numberOfPeriodLines = 6;
                    PeriodLineUnit = 2;                   
                    periodStartDateTime = periodFromDate;
                    periodEndDateTime = periodFromDate.AddMonths(1);
                    periodToDate = periodStartDateTime.AddMonths(1).AddDays(-1);
                    break;
                case "5":                       // 1 week as days
                    numberOfPeriodLines = 7;
                    PeriodLineUnit = 3;
                    periodStartDateTime = periodFromDate;
                    periodToDate = periodStartDateTime.AddDays(7);
                    break;
                case "6":                      // 1 to 6 days 
                    TimeSpan difference = periodToDate - periodFromDate;
                    numberOfPeriodLines = (int)difference.TotalDays;
                    PeriodLineUnit = 3;
                    periodStartDateTime = periodFromDate;
                    break;

            }

            purchaseBudget.StartDateOfPeriod = periodFromDate;
            purchaseBudget.EndDateOfPeriod = periodToDate;

            for (var i = 0; i < numberOfPeriodLines; i++)
            {
                PurchaseBudgetPeriodLine purchaseBudgetPeriodLine = new PurchaseBudgetPeriodLine();

                purchaseBudgetPeriodLine.PurchaseBudgetId = purchaseBudget.Id;

                switch (PeriodLineUnit)
                {
                    case 1:

                        purchaseBudgetPeriodLine.PeriodStartDate = periodStartDateTime.AddMonths(i);

                        purchaseBudgetPeriodLine.displayPeriodStartText = danishDateTimeformat.GetMonthName(purchaseBudgetPeriodLine.PeriodStartDate.Month) + " " + purchaseBudgetPeriodLine.PeriodStartDate.Year.ToString();
                        DateTime tmpPeriodEndDate = periodStartDateTime.AddMonths(i + 1);
                        tmpPeriodEndDate = tmpPeriodEndDate.AddDays(-1);
                        purchaseBudgetPeriodLine.PeriodEndDate = tmpPeriodEndDate;
                        _purchaseBudgetPeriodLineRepository.Add(purchaseBudgetPeriodLine);
                        break;

                    case 2:
                        if (periodStartDateTime < periodEndDateTime)
                        {


                            int currentWeekDay = (int)periodStartDateTime.DayOfWeek;
                            int numberOfDaysToNextSunday = 0;

                            switch (currentWeekDay)
                            {
                                case 0:
                                    numberOfDaysToNextSunday = 0;
                                    break;
                                case 1:
                                    numberOfDaysToNextSunday = 6;
                                    break;
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                    numberOfDaysToNextSunday = 7 - currentWeekDay;
                                    break;
                            }


                            purchaseBudgetPeriodLine.PeriodStartDate = periodStartDateTime;
                            if (periodStartDateTime.AddDays(numberOfDaysToNextSunday) < periodEndDateTime)
                            {
                                purchaseBudgetPeriodLine.PeriodEndDate = periodStartDateTime.AddDays(numberOfDaysToNextSunday);
                            }
                            else
                            {
                                purchaseBudgetPeriodLine.PeriodEndDate = periodEndDateTime;
                            }



                            int periodweekNo = WeekCalculation.getWeekNumberBydate(purchaseBudgetPeriodLine.PeriodStartDate);
                            purchaseBudgetPeriodLine.displayWeekNumber = "Uge: " + periodweekNo.ToString();
                            purchaseBudgetPeriodLine.displayPeriodStartText = "Fra: " + purchaseBudgetPeriodLine.PeriodStartDate.ToString(danishDateTimeformat.ShortDatePattern);
                            purchaseBudgetPeriodLine.displayPeriodEndText = "Til: " + purchaseBudgetPeriodLine.PeriodEndDate.ToString(danishDateTimeformat.ShortDatePattern);

                            periodStartDateTime = purchaseBudgetPeriodLine.PeriodEndDate.AddDays(1);

                            _purchaseBudgetPeriodLineRepository.Add(purchaseBudgetPeriodLine);
                        }
                        break;
                    case 3:

                        purchaseBudgetPeriodLine.PeriodStartDate = periodStartDateTime.AddDays(i);
                        purchaseBudgetPeriodLine.PeriodEndDate = periodStartDateTime.AddDays(i);

                        weekNo = WeekCalculation.getWeekNumberBydate(purchaseBudgetPeriodLine.PeriodStartDate);
                        purchaseBudgetPeriodLine.displayWeekNumber = "Uge: " + weekNo.ToString();
                        purchaseBudgetPeriodLine.displayPeriodStartText = "Fra: " + purchaseBudgetPeriodLine.PeriodStartDate.ToString(danishDateTimeformat.ShortDatePattern);
                        purchaseBudgetPeriodLine.displayPeriodEndText = "Til: " + purchaseBudgetPeriodLine.PeriodEndDate.ToString(danishDateTimeformat.ShortDatePattern);


                        _purchaseBudgetPeriodLineRepository.Add(purchaseBudgetPeriodLine);
                        break;
                }
            }

            return RedirectToAction("EditPurchaseBudget", "PurchaseOrder", new { purchaseBudgetId = purchaseBudgetNew.Id });


        }

        [HttpGet]
        public IActionResult EditPurchaseBudget(int purchaseBudgetId, string searchByStockItemName, string searchByStockItemNumber, string vendorId, string purchaseDocumentNumber, string category1Id, string category2Id, string category3Id, CompanyAccount companyAccount)
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

            List<StockItem> Allstocktems = _stockItemRepository.GetAllstockItems().Where(companyAccount => companyAccount.companyAccountId == companyAccount.companyAccountId).ToList();

            if (!string.IsNullOrEmpty(searchByStockItemName))
            {
                Allstocktems = Allstocktems.Where(stockItem => stockItem.ItemName.ToLower().Contains(searchByStockItemName.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(searchByStockItemNumber))
            {
                Allstocktems = Allstocktems.Where(stockItem => stockItem.ItemNumber.ToLower().Contains(searchByStockItemNumber.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(vendorId) && !vendorId.Equals("0"))
            {
                Allstocktems = Allstocktems.Where(stockItem => stockItem.VendorId.ToString().Equals(vendorId)).ToList();
            }

            if (!string.IsNullOrEmpty(category1Id) && !category1Id.Equals("0"))
            {
                Allstocktems = Allstocktems.Where(stockItem => stockItem.category1Id.ToString().Equals(category1Id)).ToList();
            }

            if (!string.IsNullOrEmpty(category2Id) && !category2Id.Equals("0"))
            {
                Allstocktems = Allstocktems.Where(stockItem => stockItem.category2Id.ToString().Equals(category2Id)).ToList();
            }

            if (!string.IsNullOrEmpty(category1Id) && !category1Id.Equals("0"))
            {
                Allstocktems = Allstocktems.Where(stockItem => stockItem.category1Id.ToString().Equals(category1Id)).ToList();
            }

            if (!string.IsNullOrEmpty(category3Id) && !category3Id.Equals("0"))
            {
                Allstocktems = Allstocktems.Where(stockItem => stockItem.category3Id.ToString().Equals(category3Id)).ToList();
            }



            List<StockItem> stockItems = new List<StockItem>();
            PurchaseBudget purchaseBudget = _purchaseBudgetRepository.GetPurchaseBudget(purchaseBudgetId);
            List<PurchaseBudgetLineModel> purchaseBudgetLineModelList = new List<PurchaseBudgetLineModel>();

            List<PurchaseBudgetLine> budgetLines = _purchaseBudgetLinesRepository.GetAllPurchaseBudgetLines().Where(budgetLine => budgetLine.PurchaseBudgetId == purchaseBudget.Id).ToList();
            foreach (var budgetLine in budgetLines)
            {
                stockItems = Allstocktems.Where(stockItem => stockItem.Id == budgetLine.StockItemId).ToList();
                if (stockItems.Count > 0)
                {
                    StockItem stockItemTmp = stockItems.First();
                    Allstocktems.Remove(stockItemTmp);
                }

                PurchaseBudgetLineModel purchaseBudgetLineModel = new PurchaseBudgetLineModel();

                StockItem stockItem = _stockItemRepository.getStockItem(budgetLine.StockItemId);
                if (stockItem != null)
                {
                    purchaseBudgetLineModel.Id = budgetLine.Id.ToString();
                    purchaseBudgetLineModel.PeriodLineId = budgetLine.PeriodLineId;
                    purchaseBudgetLineModel.QuantityToOrder = budgetLine.QuantityToOrder.ToString();
                    purchaseBudgetLineModel.OurItemName = stockItem.ItemName;
                    purchaseBudgetLineModel.OurItemNumber = stockItem.ItemNumber;
                    purchaseBudgetLineModel.OurItemUnit = stockItem.Unit;
                    purchaseBudgetLineModel.OurCostPrice = stockItem.CostPrice.ToString();
                    purchaseBudgetLineModel.LineTotalAmount = (budgetLine.QuantityToOrder * stockItem.CostPrice).ToString();
                    purchaseBudgetLineModel.StockItemId = stockItem.Id.ToString();


                    if (companyAccount.IntegrationDinero)
                    {
                        PurchaseBudgetPeriodLine periodLine = _purchaseBudgetPeriodLineRepository.GetPurchaseBudgetPeriodLine(Int32.Parse(budgetLine.PeriodLineId));

                        if (periodLine != null)
                        {
                            DateTime periodLastYearStartDate = periodLine.PeriodStartDate;
                            periodLastYearStartDate = periodLastYearStartDate.AddYears(-1);
                            purchaseBudgetLineModel.QuantitySoldPeriodStartDate = periodLastYearStartDate.ToString(danishDateTimeformat.ShortDatePattern);

                            DateTime periodLastYearEndDate = periodLine.PeriodEndDate;
                            periodLastYearEndDate = periodLastYearEndDate.AddYears(-1);
                            purchaseBudgetLineModel.QuantitySoldPeriodEndDate = periodLastYearEndDate.ToString(danishDateTimeformat.ShortDatePattern);

                            purchaseBudgetLineModel.QuantitySold = getTotalSoldAmountForStockItem(periodLastYearStartDate, periodLastYearEndDate, stockItem.DineroGuiD, companyAccount).ToString();
                        }
                    }

                    purchaseBudgetLineModelList.Add(purchaseBudgetLineModel);
                }
            }



            PurchaseBudgetEditViewModel model = new PurchaseBudgetEditViewModel();

            if (purchaseBudget != null)
            {
                List<Vendor> vendorList = _vendorRepository.GetAllVendors().Where(vendor => vendor.companyAccountId == companyAccount.companyAccountId).ToList();
                foreach (var vendor in vendorList)
                {
                    model.SearchByVendor.Add(new SelectListItem { Value = vendor.Id.ToString(), Text = vendor.Name });
                }


                List<StockItemCategory1> category1List = _stockItemCategory1Repository.GetAllStockItemCategory1s().Where(vendor => vendor.companyAccountId == companyAccount.companyAccountId).ToList();
                foreach (var category1 in category1List)
                {
                    model.SearchByCategory1.Add(new SelectListItem { Value = category1.Id.ToString(), Text = category1.Name });
                }

                List<StockItemCategory2> category2List = _stockItemCategory2Repository.GetAllStockItemCategory2s().Where(vendor => vendor.companyAccountId == companyAccount.companyAccountId).ToList();
                foreach (var category2 in category2List)
                {
                    model.SearchByCategory2.Add(new SelectListItem { Value = category2.Id.ToString(), Text = category2.Name });
                }

                List<StockItemCategory3> category3List = _stockItemCategory3Repository.GetAllStockItemCategory3s().Where(vendor => vendor.companyAccountId == companyAccount.companyAccountId).ToList();
                foreach (var category3 in category3List)
                {
                    model.SearchByCategory3.Add(new SelectListItem { Value = category3.Id.ToString(), Text = category3.Name });
                }


                model.PurchaseBudgetId = purchaseBudget.Id.ToString();
                model.Description = purchaseBudget.Description;
                model.StockItems = Allstocktems;
                model.BudgetLines = purchaseBudgetLineModelList;
                model.PeriodLines = _purchaseBudgetPeriodLineRepository.GetAllPurchaseBudgetPeriodLines().Where(periodLine => periodLine.PurchaseBudgetId == purchaseBudgetId).ToList();
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult DeletePurchaseBudget(int purchaseBudgetId, CompanyAccount companyAccount)
        {
            PurchaseBudget purchaseBudget = _purchaseBudgetRepository.GetPurchaseBudget(purchaseBudgetId);

            if (purchaseBudget != null)
            {
                _purchaseBudgetRepository.Delete(purchaseBudget.Id);

                List<PurchaseBudgetLine> budgetLines = _purchaseBudgetLinesRepository.GetAllPurchaseBudgetLines().Where(budgetLine => budgetLine.PurchaseBudgetId == purchaseBudget.Id).ToList();
                foreach (var budgetLine in budgetLines)
                {
                    _purchaseBudgetLinesRepository.Delete(budgetLine.Id);
                }


                List<PurchaseBudgetPeriodLine> budgetPeriodLines = _purchaseBudgetPeriodLineRepository.GetAllPurchaseBudgetPeriodLines().Where(periodLine => periodLine.PurchaseBudgetId == purchaseBudget.Id).ToList();
                foreach (var budgetPeriodLine in budgetPeriodLines)
                {
                    _purchaseBudgetPeriodLineRepository.Delete(budgetPeriodLine.Id);
                }
            }

            return RedirectToAction("IndexBudget", "PurchaseOrder");
        }

        [HttpPost]
        public IActionResult createBudgetLineFromItemLine(PurchaseBudgetLineModel model, CompanyAccount companyAccount)
        {
            if (!string.IsNullOrEmpty(model.PurchaseBudgetId))
            {
                DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
                PurchaseBudget purchaseBudget = _purchaseBudgetRepository.GetPurchaseBudget(Int32.Parse(model.PurchaseBudgetId));
                if (purchaseBudget != null)
                {
                    PurchaseBudgetLine budgetLine = new PurchaseBudgetLine();

                    budgetLine.PurchaseBudgetId = purchaseBudget.Id;
                    budgetLine.StockItemId = Int32.Parse(model.StockItemId);
                    budgetLine.PeriodLineId = model.PeriodLineId;


                    budgetLine.LastEditedDate = DateTime.Now;
                    budgetLine.CreatedDate = DateTime.Now;

                    PurchaseBudgetLine budgetLineNew = _purchaseBudgetLinesRepository.Add(budgetLine);

                    model.Id = budgetLineNew.Id.ToString();

                    if (!string.IsNullOrEmpty(model.StockItemId))
                    {
                        StockItem stockItem = _stockItemRepository.getStockItem(budgetLineNew.StockItemId);
                        if (stockItem != null)
                        {
                            model.OurItemName = stockItem.ItemName;
                            model.OurItemNumber = stockItem.ItemNumber;
                            model.OurItemUnit = stockItem.Unit;
                            model.OurCostPrice = stockItem.CostPrice.ToString();
                            model.StockItemId = stockItem.Id.ToString();
                        }

                        model.QuantityToOrder = "0";
                        model.LineTotalAmount = "0";


                        if (companyAccount.IntegrationDinero)
                        {
                            PurchaseBudgetPeriodLine periodLine = _purchaseBudgetPeriodLineRepository.GetPurchaseBudgetPeriodLine(Int32.Parse(budgetLine.PeriodLineId));

                            if (periodLine != null)
                            {
                                DateTime periodLastYearStartDate = periodLine.PeriodStartDate;
                                periodLastYearStartDate = periodLastYearStartDate.AddYears(-1);
                                model.QuantitySoldPeriodStartDate = periodLastYearStartDate.ToString(danishDateTimeformat.ShortDatePattern);

                                DateTime periodLastYearEndDate = periodLine.PeriodEndDate;
                                periodLastYearEndDate = periodLastYearEndDate.AddYears(-1);
                                model.QuantitySoldPeriodEndDate = periodLastYearEndDate.ToString(danishDateTimeformat.ShortDatePattern);

                                model.QuantitySold = getTotalSoldAmountForStockItem(periodLastYearStartDate, periodLastYearEndDate, stockItem.DineroGuiD, companyAccount).ToString();
                            }
                        }
                    }
                }
            }

            return Json(model);
        }

        public Decimal getTotalSoldAmountForStockItem(DateTime fromDate, DateTime toDate, Guid DineroStockitemId, CompanyAccount companyAccount)
        {
            Decimal totalSoldAmount = 0;

            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
            if (dineroAPIConnect.connectToDinero(companyAccount.DineroAPIOrganizationKey) == null)
            {
                return totalSoldAmount;
            }

            DineroInvoice dineroInvoice = new DineroInvoice(dineroAPIConnect);
            READDineroAPIInvoicecollection rEADDineroAPIInvoicecollection = dineroInvoice.getInvoicesByIntervalFromDinero(fromDate, toDate);

            foreach (var invoice in rEADDineroAPIInvoicecollection.Collection)
            {
                READDineroAPIInvoiceProductLines rEADDineroAPIInvoiceProductLines = dineroInvoice.getInvoiceLinesFromDinero(invoice.Guid.ToString());
                foreach (var invoiceProductLine in rEADDineroAPIInvoiceProductLines.ProductLines)
                {
                    if (invoiceProductLine.ProductGuid == DineroStockitemId.ToString())
                    {
                        totalSoldAmount = totalSoldAmount + invoiceProductLine.Quantity;
                    }
                }
            }
            return totalSoldAmount;
        }

        [HttpPost]
        public IActionResult CreateBudgetLineFromBudgetLine(PurchaseBudgetLineModel model, CompanyAccount companyAccount)
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            if (!string.IsNullOrEmpty(model.PurchaseBudgetId))
            {
                PurchaseBudget purchaseBudget = _purchaseBudgetRepository.GetPurchaseBudget(Int32.Parse(model.PurchaseBudgetId));
                if (purchaseBudget != null)
                {
                    if (!string.IsNullOrEmpty(model.Id))
                    {
                        PurchaseBudgetLine budgetLineToCopyFrom = _purchaseBudgetLinesRepository.GetPurchaseBudgetLine(Int32.Parse(model.Id));
                        if (budgetLineToCopyFrom != null)
                        {
                            PurchaseBudgetLine budgetLineToCopyTo = new PurchaseBudgetLine();

                            budgetLineToCopyTo.PurchaseBudgetId = budgetLineToCopyFrom.PurchaseBudgetId;
                            budgetLineToCopyTo.QuantityToOrder = budgetLineToCopyFrom.QuantityToOrder;

                            budgetLineToCopyTo.StockItemId = budgetLineToCopyFrom.StockItemId;
                            budgetLineToCopyTo.PeriodLineId = model.PeriodLineId;

                            PurchaseBudgetLine budgetLineToCopyToNew = _purchaseBudgetLinesRepository.Add(budgetLineToCopyTo);

                            StockItem stockItem = _stockItemRepository.getStockItem(budgetLineToCopyTo.StockItemId);
                            if (stockItem != null)
                            {
                                model.OurItemName = stockItem.ItemName;
                                model.OurItemNumber = stockItem.ItemNumber;
                                model.OurItemUnit = stockItem.Unit;
                                model.OurCostPrice = stockItem.CostPrice.ToString();
                                model.LineTotalAmount = (budgetLineToCopyFrom.QuantityToOrder * stockItem.CostPrice).ToString();
                            }

                            model.Id = budgetLineToCopyToNew.Id.ToString();
                            model.QuantityToOrder = budgetLineToCopyTo.QuantityToOrder.ToString();

                            if (companyAccount.IntegrationDinero)
                            {
                                PurchaseBudgetPeriodLine periodLine = _purchaseBudgetPeriodLineRepository.GetPurchaseBudgetPeriodLine(Int32.Parse(budgetLineToCopyToNew.PeriodLineId));

                                if (periodLine != null)
                                {
                                    DateTime periodLastYearStartDate = periodLine.PeriodStartDate;
                                    periodLastYearStartDate = periodLastYearStartDate.AddYears(-1);
                                    model.QuantitySoldPeriodStartDate = periodLastYearStartDate.ToString(danishDateTimeformat.ShortDatePattern);

                                    DateTime periodLastYearEndDate = periodLine.PeriodEndDate;
                                    periodLastYearEndDate = periodLastYearEndDate.AddYears(-1);
                                    model.QuantitySoldPeriodEndDate = periodLastYearEndDate.ToString(danishDateTimeformat.ShortDatePattern);

                                    model.QuantitySold = getTotalSoldAmountForStockItem(periodLastYearStartDate, periodLastYearEndDate, stockItem.DineroGuiD, companyAccount).ToString();
                                }
                            }

                        }
                    }
                }
            }
            return Json(model);
        }


        [HttpPost]
        public IActionResult updateBudgetLineQuantity(PurchaseBudgetLineModel model, CompanyAccount companyAccount)
        {
            if (!string.IsNullOrEmpty(model.PurchaseBudgetId))
            {
                PurchaseBudget purchaseBudget = _purchaseBudgetRepository.GetPurchaseBudget(Int32.Parse(model.PurchaseBudgetId));
                if (purchaseBudget != null)
                {
                    if (!string.IsNullOrEmpty(model.Id))
                    {
                        PurchaseBudgetLine budgetLine = _purchaseBudgetLinesRepository.GetPurchaseBudgetLine(Int32.Parse(model.Id));
                        if (budgetLine != null)
                        {
                            StockItem stockItem = _stockItemRepository.getStockItem(budgetLine.StockItemId);
                            if (stockItem != null)
                            {
                                if (!string.IsNullOrEmpty(model.QuantityToOrder))
                                {
                                    budgetLine.QuantityToOrder = Decimal.Parse(model.QuantityToOrder);

                                    model.LineTotalAmount = (budgetLine.QuantityToOrder * stockItem.CostPrice).ToString();
                                }
                                else
                                {
                                    model.QuantityToOrder = "0";
                                    model.LineTotalAmount = "0";
                                }
                            }

                            _purchaseBudgetLinesRepository.Update(budgetLine);
                        }
                    }
                }
            }

            return Json(model);
        }


        [HttpPost]
        public IActionResult updateBudgetLinePeriod(PurchaseBudgetLineModel model, CompanyAccount companyAccount)
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            if (!string.IsNullOrEmpty(model.PurchaseBudgetId))
            {
                PurchaseBudget purchaseBudget = _purchaseBudgetRepository.GetPurchaseBudget(Int32.Parse(model.PurchaseBudgetId));
                if (purchaseBudget != null)
                {
                    if (!string.IsNullOrEmpty(model.Id))
                    {
                        PurchaseBudgetLine budgetLine = _purchaseBudgetLinesRepository.GetPurchaseBudgetLine(Int32.Parse(model.Id));
                        if (budgetLine != null)
                        {
                            if (!string.IsNullOrEmpty(model.PeriodLineId))
                            {
                                string OldPeriodLineId = budgetLine.PeriodLineId;

                                budgetLine.PeriodLineId = model.PeriodLineId;
                                _purchaseBudgetLinesRepository.Update(budgetLine);

                                StockItem stockItem = _stockItemRepository.getStockItem(budgetLine.StockItemId);
                                if (stockItem != null)
                                {
                                    model.OurItemName = stockItem.ItemName;
                                    model.OurItemNumber = stockItem.ItemNumber;
                                    model.OurItemUnit = stockItem.Unit;
                                    model.OurCostPrice = stockItem.CostPrice.ToString();
                                    model.LineTotalAmount = (stockItem.CostPrice * budgetLine.QuantityToOrder).ToString();
                                }

                                model.oldPeriodLineId = OldPeriodLineId.ToString();
                                model.QuantityToOrder = budgetLine.QuantityToOrder.ToString();

                                if (companyAccount.IntegrationDinero)
                                {
                                    PurchaseBudgetPeriodLine periodLine = _purchaseBudgetPeriodLineRepository.GetPurchaseBudgetPeriodLine(Int32.Parse(budgetLine.PeriodLineId));

                                    if (periodLine != null)
                                    {
                                        DateTime periodLastYearStartDate = periodLine.PeriodStartDate;
                                        periodLastYearStartDate = periodLastYearStartDate.AddYears(-1);
                                        model.QuantitySoldPeriodStartDate = periodLastYearStartDate.ToString(danishDateTimeformat.ShortDatePattern);

                                        DateTime periodLastYearEndDate = periodLine.PeriodEndDate;
                                        periodLastYearEndDate = periodLastYearEndDate.AddYears(-1);
                                        model.QuantitySoldPeriodEndDate = periodLastYearEndDate.ToString(danishDateTimeformat.ShortDatePattern);

                                        model.QuantitySold = getTotalSoldAmountForStockItem(periodLastYearStartDate, periodLastYearEndDate, stockItem.DineroGuiD, companyAccount).ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return Json(model);
        }

        [HttpPost]
        public IActionResult deleteBudgetLine(PurchaseBudgetLineModel model, CompanyAccount companyAccount)
        {
            if (!string.IsNullOrEmpty(model.PurchaseBudgetId))
            {
                PurchaseBudget purchaseBudget = _purchaseBudgetRepository.GetPurchaseBudget(Int32.Parse(model.PurchaseBudgetId));
                if (purchaseBudget != null)
                {
                    if (!string.IsNullOrEmpty(model.Id))
                    {
                        PurchaseBudgetLine budgetLine = _purchaseBudgetLinesRepository.GetPurchaseBudgetLine(Int32.Parse(model.Id));
                        if (budgetLine != null)
                        {
                            _purchaseBudgetLinesRepository.Delete(budgetLine.Id);
                        }
                    }
                }
            }

            return Json(model);
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

        public IActionResult getAllbudgets(CompanyAccount companyAccount)
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            List<PurchaseBudgetViewModel> purchaseBudgetListModel = new List<PurchaseBudgetViewModel>();

            List<PurchaseBudget> purchaseBudgetList = _purchaseBudgetRepository.GetAllPurchaseBudgets().Where(budget => budget.companyAccountId == companyAccount.companyAccountId).OrderByDescending(budget => budget.StartDateOfPeriod).ToList();

            foreach (var purchaseBudget in purchaseBudgetList)
            {
                PurchaseBudgetViewModel purchaseBudgetViewModel = new PurchaseBudgetViewModel();

                purchaseBudgetViewModel.Id = purchaseBudget.Id.ToString(); ;
                purchaseBudgetViewModel.Description = purchaseBudget.Description;
                purchaseBudgetViewModel.PeriodFromDate = purchaseBudget.StartDateOfPeriod.ToString(danishDateTimeformat.ShortDatePattern);
                purchaseBudgetViewModel.PeriodToDate = purchaseBudget.EndDateOfPeriod.ToString(danishDateTimeformat.ShortDatePattern);

                SelectListItem selItem = purchaseBudgetViewModel.SelectPeriod.Find(element => element.Value.Equals(purchaseBudget.Period));
                purchaseBudgetViewModel.Period = selItem.Text;

                purchaseBudgetListModel.Add(purchaseBudgetViewModel);
            }

            return Json(purchaseBudgetListModel);
        }


        public IActionResult getBudgetPeriods(string purchaseBudgetId, CompanyAccount companyAccount)
        {
            List<PurchaseBudgetPeriodLine> purchasePeriodLineList = new List<PurchaseBudgetPeriodLine>();


            if (!string.IsNullOrEmpty(purchaseBudgetId))
            {
                PurchaseBudget purchaseBudget = _purchaseBudgetRepository.GetPurchaseBudget(Int32.Parse(purchaseBudgetId));
                if (purchaseBudget != null)
                {
                    purchasePeriodLineList = _purchaseBudgetPeriodLineRepository.GetAllPurchaseBudgetPeriodLines().Where(periodLine => periodLine.PurchaseBudgetId == purchaseBudget.Id).ToList();
                }
            }

            return Json(purchasePeriodLineList);
        }

        public IActionResult getBudgetPeriodItemLines(string purchaseBudgetId, string purchasePeriodId, CompanyAccount companyAccount)
        {
            List<PurchaseBudgetLine> purchaseBudgetItemLineList = new List<PurchaseBudgetLine>();
            List<PurchaseBudgetLineModel> PurchaseBudgetLineModelList = new List<PurchaseBudgetLineModel>();

            if (!string.IsNullOrEmpty(purchaseBudgetId))
            {
                PurchaseBudget purchaseBudget = _purchaseBudgetRepository.GetPurchaseBudget(Int32.Parse(purchaseBudgetId));
                if (purchaseBudget != null)
                {
                    if (!string.IsNullOrEmpty(purchasePeriodId))
                    {
                        purchaseBudgetItemLineList = _purchaseBudgetLinesRepository.GetAllPurchaseBudgetLines().Where(budgetItemLine => budgetItemLine.PurchaseBudgetId == purchaseBudget.Id && budgetItemLine.PeriodLineId.Equals(purchasePeriodId)).ToList();

                        foreach (var purchaseBudgetItemLine in purchaseBudgetItemLineList)
                        {
                            PurchaseBudgetLineModel purchaseBudgetLineModel = new PurchaseBudgetLineModel();

                            purchaseBudgetLineModel.Id = purchaseBudgetItemLine.Id.ToString();
                            purchaseBudgetLineModel.QuantityToOrder = purchaseBudgetItemLine.QuantityToOrder.ToString();

                            StockItem stockItem = _stockItemRepository.getStockItem(purchaseBudgetItemLine.StockItemId);
                            if (stockItem != null)
                            {
                                purchaseBudgetLineModel.OurItemName = stockItem.ItemName;
                                purchaseBudgetLineModel.OurItemNumber = stockItem.ItemNumber;
                                purchaseBudgetLineModel.OurCostPrice = stockItem.CostPrice.ToString();
                                purchaseBudgetLineModel.StockItemId = stockItem.Id.ToString();
                            }

                            PurchaseBudgetLineModelList.Add(purchaseBudgetLineModel);
                        }
                    }

                }
            }

            return Json(PurchaseBudgetLineModelList);
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
        public IActionResult createPurchaseOrderLineFromPurchaseBudgetLine(PurchaseBudgetLineToOrderLineModel model, CompanyAccount companyAccount)
        {

            if (!string.IsNullOrEmpty(model.Id))
            {
                PurchaseBudgetLine purchaseBudgetLine = _purchaseBudgetLinesRepository.GetPurchaseBudgetLine(Int32.Parse(model.Id));
                if (purchaseBudgetLine != null)
                {
                    PurchaseOrderLine orderLine = new PurchaseOrderLine();

                    StockItem stockItem = _stockItemRepository.getStockItem(purchaseBudgetLine.StockItemId);
                    if (stockItem != null)
                    {
                        orderLine.StockItemId = stockItem.Id;
                        orderLine.OurItemName = stockItem.ItemName;
                        orderLine.OurItemNumber = stockItem.ItemNumber;
                        orderLine.OurLocation = stockItem.Location;
                        orderLine.OurUnit = stockItem.Unit;
                        orderLine.OurUnitCostPrice = stockItem.CostPrice;
                        orderLine.VendorItemNumber = stockItem.VendorItemNumber;
                        orderLine.VendorItemName = stockItem.VendorItemName;
                    }

                    orderLine.PurchaseOrderId = Int32.Parse(model.PurchaseOrderId);
                    orderLine.QuantityToOrder = purchaseBudgetLine.QuantityToOrder;
                    orderLine.companyAccountId = companyAccount.companyAccountId;

                    PurchaseOrderLine orderLineNew = _purchaseOrderLineRepository.Add(orderLine);
                    //model.Id = orderLineNew.Id.ToString();

                    //model.OurItemName = stockItem.ItemName;
                    //model.OurItemNumber = stockItem.ItemNumber;
                    //model.OurLocation = stockItem.Location;
                    //model.OurItemUnit = stockItem.Unit;
                    //model.OurCostPrice = stockItem.CostPrice.ToString();
                    //model.VendorItemNumber = model.VendorItemNumber;
                    //model.VendorItemName = model.VendorItemName;



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
        public string oldPeriodLineId { get; set; }
        public string PurchaseBudgetId { get; set; }
        public string LocationId { get; set; }
        public string Location { get; set; }
        public string OurItemName { get; set; }
        public string OurItemUnit { get; set; }
        public string OurItemNumber { get; set; }
        public string OurCostPrice { get; set; }
        public string QuantityToOrder { get; set; }
        public string LineTotalAmount { get; set; }
        public string QuantitySold { get; set; }
        public string QuantitySoldPeriodStartDate { get; set; }
        public string QuantitySoldPeriodEndDate { get; set; }
        public int companyAccountId { get; set; }

    }

    public class PurchaseBudgetLineToOrderLineModel
    {
        public string Id { get; set; }              
        public string PurchaseOrderId { get; set; }      

    }



}






