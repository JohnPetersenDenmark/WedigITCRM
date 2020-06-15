using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WedigITCRM.DineroAPI;
using WedigITCRM.EntitityModels;
using WedigITCRM.StorageInterfaces;
using WedigITCRM.Utilities;

namespace WedigITCRM.Controllers
{
    [Authorize]
    public class VendorController : Controller
    {
        private readonly IDeliveryConditionRepository _deliveryConditionRepository;
        private readonly IPaymentConditionRepository _paymentConditionRepository;
        private ILogger<VendorController> _logger;
        private IVendorRepository _vendorRepository;
        private IPostalCodeRepository _postalCodeRepository;
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private ICompanyAccountRepository _companyAccountRepository;
        private IRelateCompanyAccountWithUserRepository _relateCompanyAccountWithUserRepository;




        public VendorController(IDeliveryConditionRepository deliveryConditionRepository, IPaymentConditionRepository paymentConditionRepository, ILogger<VendorController> logger, IVendorRepository vendorRepository, IRelateCompanyAccountWithUserRepository relateCompanyAccountWithUserRepository, ICompanyAccountRepository companyAccountRepository, IPostalCodeRepository postalCodeRepository, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _deliveryConditionRepository = deliveryConditionRepository;
            _paymentConditionRepository = paymentConditionRepository;
            _logger = logger;
            _vendorRepository = vendorRepository;
            _postalCodeRepository = postalCodeRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _companyAccountRepository = companyAccountRepository;
            _relateCompanyAccountWithUserRepository = relateCompanyAccountWithUserRepository;

        }

        public IActionResult AllVendors()
        {
            //throw new Exception("user logged in");
            return View();
        }

        public IActionResult getVendors(CompanyAccount companyAccount)
        {

            var vendorData = _vendorRepository.GetAllVendors().Where(company => company.companyAccountId == companyAccount.companyAccountId).ToList();

            List<ReducedVendor> data = new List<ReducedVendor>();
            foreach (var vendor in vendorData)
            {
                DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

                ReducedVendor reducedVendor = new ReducedVendor();
                reducedVendor.id = vendor.Id.ToString();
                reducedVendor.name = vendor.Name;
                reducedVendor.Email = vendor.Email;
                reducedVendor.street = vendor.Street;
                reducedVendor.city = vendor.City;
                reducedVendor.zip = vendor.Zip;
                reducedVendor.ForeignCity = vendor.ForeignCity;
                reducedVendor.ForeignZip = vendor.ForeignZip;
                reducedVendor.HomePage = vendor.HomePage;
                reducedVendor.LastEditedDate = vendor.LastEditedDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                reducedVendor.CreatedDate = vendor.LastEditedDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                reducedVendor.dineroGuiD = vendor.DineroGuiD;
                reducedVendor.PhoneNumber = vendor.PhoneNumber;
                reducedVendor.postalCodeId = vendor.postalCodeId;
                reducedVendor.CountryCode = vendor.CountryCode;
                reducedVendor.PaymentConditionsId = vendor.PaymentConditionsId.ToString();
                reducedVendor.PaymentConditions = vendor.PaymentConditions;
                reducedVendor.DeliveryConditionsId = vendor.DeliveryConditionsId.ToString();
                reducedVendor.DeliveryConditions = vendor.DeliveryConditions;
                reducedVendor.CurrencyCode = vendor.CurrencyCode;
                reducedVendor.companyAccountId = vendor.companyAccountId;
                data.Add(reducedVendor);
            }

            // throw new Exception("Forced error in Vendor controller");

            return Json(data);

        }

        public IActionResult EditVendor([FromBody] VendorInputModel datamodelInput, CompanyAccount companyAccount)
        {

            if (ModelState.IsValid)
            {
                if (datamodelInput.action.Equals("edit"))
                {



                    Vendor vendor = _vendorRepository.GetVendor(int.Parse(datamodelInput.id));
                    if (vendor != null)
                    {
                        vendor.Name = datamodelInput.name;
                        if (!string.IsNullOrEmpty(datamodelInput.cvrNumber))
                        {
                            vendor.CVRNumber = datamodelInput.cvrNumber;
                        }

                        vendor.Email = datamodelInput.Email;
                        vendor.PaymentConditionsId = Int32.Parse(datamodelInput.PaymentConditionsId);
                        if (!string.IsNullOrEmpty(datamodelInput.PaymentConditionsId))
                        {
                            PaymentCondition paymentCondition = _paymentConditionRepository.GetPaymentCondition(Int32.Parse(datamodelInput.PaymentConditionsId));
                            if (paymentCondition != null)
                            {
                                vendor.PaymentConditions = paymentCondition.Description;
                            }                                                     
                        }

                        vendor.DeliveryConditionsId= Int32.Parse(datamodelInput.DeliveryConditionsId);
                        if (!string.IsNullOrEmpty(datamodelInput.DeliveryConditionsId))
                        {
                            DeliveryCondition deliveryCondition = _deliveryConditionRepository.GetDeliveryCondition(Int32.Parse(datamodelInput.DeliveryConditionsId));
                            if (deliveryCondition != null)
                            {
                                vendor.PaymentConditions = deliveryCondition.Description;
                            }
                        }


                        vendor.Street = datamodelInput.street;
                        vendor.Zip = datamodelInput.zip;
                        vendor.City = datamodelInput.city;
                        vendor.ForeignZip = datamodelInput.ForeignZip;
                        vendor.ForeignCity = datamodelInput.ForeignCity;
                        vendor.Name = datamodelInput.name;
                        vendor.CountryCode = datamodelInput.CountryCode;
                        vendor.CurrencyCode = datamodelInput.CurrencyCode;
                        vendor.PhoneNumber = datamodelInput.PhoneNumber;
                        vendor.postalCodeId = datamodelInput.postalCodeId;
                        vendor.HomePage = datamodelInput.HomePage;
                        vendor.LastEditedDate = DateTime.Now;
                        Vendor newVendor = _vendorRepository.Update(vendor);

                        if (companyAccount.IntegrationDinero && companyAccount.synchronizeCustomerFromNyxiumToDinero)
                        {
                            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
                            if (dineroAPIConnect.connectToDinero(companyAccount) != null)
                            {
                                DineroContacts dineroContacts = new DineroContacts(dineroAPIConnect);
                                string status = dineroContacts.UpdateVendorInDinero(newVendor, newVendor.DineroGuiD);
                            }
                        }
                    }
                }

                if (datamodelInput.action.Equals("create"))
                {
                    Vendor vendor = new Vendor();

                    vendor.Name = datamodelInput.name;
                    if (!string.IsNullOrEmpty(datamodelInput.cvrNumber))
                    {
                        vendor.CVRNumber = datamodelInput.cvrNumber;
                    }

                    vendor.Email = datamodelInput.Email;
                    vendor.PaymentConditionsId = Int32.Parse(datamodelInput.PaymentConditionsId);

                    if (!string.IsNullOrEmpty(datamodelInput.PaymentConditionsId))
                    {
                        PaymentCondition paymentCondition = _paymentConditionRepository.GetPaymentCondition(Int32.Parse(datamodelInput.PaymentConditionsId));
                        if (paymentCondition != null)
                        {
                            vendor.PaymentConditions = paymentCondition.Description;
                        }
                    }

                    vendor.DeliveryConditionsId = Int32.Parse(datamodelInput.DeliveryConditionsId);
                    if (!string.IsNullOrEmpty(datamodelInput.DeliveryConditionsId))
                    {
                        DeliveryCondition deliveryCondition = _deliveryConditionRepository.GetDeliveryCondition(Int32.Parse(datamodelInput.DeliveryConditionsId));
                        if (deliveryCondition != null)
                        {
                            vendor.PaymentConditions = deliveryCondition.Description;
                        }
                    }


                    vendor.Street = datamodelInput.street;
                    vendor.Zip = datamodelInput.zip;
                    vendor.City = datamodelInput.city;
                    vendor.ForeignZip = datamodelInput.ForeignZip;
                    vendor.ForeignCity = datamodelInput.ForeignCity;
                    vendor.Name = datamodelInput.name;
                    vendor.CountryCode = datamodelInput.CountryCode;
                    vendor.CurrencyCode = datamodelInput.CurrencyCode;
                    vendor.PhoneNumber = datamodelInput.PhoneNumber;
                    vendor.postalCodeId = datamodelInput.postalCodeId;
                    vendor.HomePage = datamodelInput.HomePage;
                    vendor.companyAccountId = companyAccount.companyAccountId;

                    vendor.LastEditedDate = DateTime.Now;
                    vendor.CreatedDate = DateTime.Now;

                    Vendor newVendor = _vendorRepository.Add(vendor);



                    datamodelInput.id = newVendor.Id.ToString();

                    DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
                    string danishdatetime = DateTime.Now.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);

                    datamodelInput.LastEditedDate = danishdatetime;
                    datamodelInput.CreatedDate = danishdatetime;

                    if (companyAccount.IntegrationDinero && companyAccount.synchronizeCustomerFromNyxiumToDinero)
                    {
                        DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
                        if (dineroAPIConnect.connectToDinero(companyAccount) != null)
                        {
                            DineroContacts dineroContacts = new DineroContacts(dineroAPIConnect);
                            string status = dineroContacts.AddVendorToDinero(newVendor).ToString();
                            if (!status.Equals("NotOK"))
                            {
                                Guid DineroGuidId = Guid.Parse(status);
                                newVendor.DineroGuiD = DineroGuidId;
                                _vendorRepository.Update(newVendor);
                            }
                        }
                    }



                }

                if (datamodelInput.action.Equals("remove"))
                {
                    Vendor vendor = _vendorRepository.GetVendor(int.Parse(datamodelInput.id));
                    if (vendor != null)
                    {
                        _vendorRepository.Delete(int.Parse(datamodelInput.id));
                        if (companyAccount.IntegrationDinero && companyAccount.synchronizeCustomerFromNyxiumToDinero)
                        {
                            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
                            if (dineroAPIConnect.connectToDinero(companyAccount) != null)
                            {
                                DineroContacts dineroContacts = new DineroContacts(dineroAPIConnect);
                                dineroContacts.DeleteContactInDinero(vendor.DineroGuiD);
                            }
                        }
                    }
                }
            }


            VendorOutputDataModel datamodelOutput = new VendorOutputDataModel();
            datamodelInput.DT_RowId = datamodelInput.id;

            datamodelOutput.data.Add(datamodelInput);

            return Json(datamodelOutput);
        }

        [AllowAnonymous]
        [HttpGet]

        public async Task<IActionResult> searchVendorByName(string term, CompanyAccount companyAccount)
        {



            var vendorData = _vendorRepository.GetAllVendors().Where(company => company.companyAccountId == companyAccount.companyAccountId && company.Name.ToLower().Contains(term.ToLower())).ToList();

            List<ReducedVendor> data = new List<ReducedVendor>();
            foreach (var vendor in vendorData)
            {
                DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

                ReducedVendor reducedVendor = new ReducedVendor();
                reducedVendor.id = vendor.Id.ToString();
                reducedVendor.name = vendor.Name;
                data.Add(reducedVendor);
            }

            return Json(data);

        }

        public IActionResult getPaymentConditions(CompanyAccount companyAccount)
        {



            // Type enumType = typeof(EnumPaymentConditions);

            //var numberOfPaymentConditionTypesCount = Enum.GetNames(enumType).Length;

            //for (var i = 0; i < numberOfPaymentConditionTypesCount; i++)
            //{
            //    MemberInfo[] x = enumType.GetMember(Enum.GetName(enumType, i));
            //    MemberInfo y = x.First();
            //    DisplayAttribute z = y.GetCustomAttribute<DisplayAttribute>();

            //    PaymentConditionViewModel PaymentConditionViewModel = new PaymentConditionViewModel();
            //    PaymentConditionViewModel.Label = z.Name;
            //    PaymentConditionViewModel.Value = i.ToString();
            //    paymentConditionList.Add(PaymentConditionViewModel);
            //}

            List<PaymentConditionViewModel> paymentConditionModelList = new List<PaymentConditionViewModel>();
            List<PaymentCondition> paymentConditionList = _paymentConditionRepository.GetAllPaymentConditions().Where(paymentConditionType => paymentConditionType.companyAccountId == companyAccount.companyAccountId).ToList();

            foreach (var paymentConditionType in paymentConditionList)
            {
                PaymentConditionViewModel PaymentConditionViewModel = new PaymentConditionViewModel();
                PaymentConditionViewModel.Label = paymentConditionType.Description;
                PaymentConditionViewModel.Value = paymentConditionType.Id.ToString();
                paymentConditionModelList.Add(PaymentConditionViewModel);
            }

            return Json(paymentConditionModelList);
        }

        public IActionResult getDeliveryConditions(CompanyAccount companyAccount)
        {
            List<DeliveryConditionViewModel> deliveryConditionModelList = new List<DeliveryConditionViewModel>();
            List<DeliveryCondition> deliveryConditionList = _deliveryConditionRepository.GetAllDeliveryConditions().Where(deliveryConditionType => deliveryConditionType.companyAccountId == companyAccount.companyAccountId).ToList();

            foreach (var paymentConditionType in deliveryConditionList)
            {
                DeliveryConditionViewModel deliveryConditionViewModel = new DeliveryConditionViewModel();
                deliveryConditionViewModel.Label = paymentConditionType.Description;
                deliveryConditionViewModel.Value = paymentConditionType.Id.ToString();
                deliveryConditionModelList.Add(deliveryConditionViewModel);
            }

            return Json(deliveryConditionModelList);
        }

        public class PaymentConditionViewModel
        {
            public string Label { get; set; }
            public string Value { get; set; }
        }

        public class DeliveryConditionViewModel
        {
            public string Label { get; set; }
            public string Value { get; set; }
        }

        public class ReducedVendor
        {

            public string id { get; set; }
            public string name { get; set; }
            public string cvrNumber { get; set; }

            public string city { get; set; }
            public string street { get; set; }
            public string ForeignZip { get; set; }
            public string ForeignCity { get; set; }
            public string zip { get; set; }
            public string CountryCode { get; set; }
            public string CurrencyCode { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }

            public string PaymentConditionsId { get; set; }
            public string PaymentConditions { get; set; }
            public string DeliveryConditionsId { get; set; }

            public string DeliveryConditions { get; set; }
            public string HomePage { get; set; }
            public string postalCodeId { get; set; }

            public Guid dineroGuiD { get; set; }

            public int companyAccountId { get; set; }
            public string LastEditedDate { get; set; }

            public string CreatedDate { get; set; }
        }

        public class VendorInputModel
        {
            public string DT_RowId { get; set; }
            public string name { get; set; }
            public string cvrNumber { get; set; }
            public string id { get; set; }

            public string city { get; set; }
            public string street { get; set; }
            public string ForeignZip { get; set; }
            public string ForeignCity { get; set; }
            public string zip { get; set; }
            public string CountryCode { get; set; }
            public string CurrencyCode { get; set; }
            public string PaymentConditionsId { get; set; }
            public string PaymentConditions { get; set; }
            public string DeliveryConditionsId { get; set; }

            public string DeliveryConditions { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }

            public string HomePage { get; set; }
            public string postalCodeId { get; set; }

            public string action { get; set; }

            public string companyAccountId { get; set; }
            public Guid dineroGuiD { get; set; }
            public string LastEditedDate { get; set; }

            public string CreatedDate { get; set; }
        }

        public class VendorOutputDataModel
        {
            public VendorOutputDataModel()
            {
                this.data = new List<VendorInputModel>();
            }
            public List<VendorInputModel> data { get; set; }

        }
    }
}
