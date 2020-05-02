using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.DineroAPI;

namespace WedigITCRM.Controllers
{
    [Authorize]
    public class VendorController : Controller
    {
        private ILogger<VendorController> _logger;
        private IVendorRepository _vendorRepository;
        private IPostalCodeRepository _postalCodeRepository;
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private ICompanyAccountRepository _companyAccountRepository;
        private IRelateCompanyAccountWithUserRepository _relateCompanyAccountWithUserRepository;
       
        


        public VendorController(ILogger<VendorController> logger, IVendorRepository vendorRepository, IRelateCompanyAccountWithUserRepository relateCompanyAccountWithUserRepository, ICompanyAccountRepository companyAccountRepository,  IPostalCodeRepository postalCodeRepository, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
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
                    reducedVendor.street = vendor.Street;
                    reducedVendor.city = vendor.City;
                    reducedVendor.zip = vendor.Zip;
                    reducedVendor.HomePage = vendor.HomePage;
                    reducedVendor.LastEditedDate = vendor.LastEditedDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                    reducedVendor.CreatedDate = vendor.LastEditedDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                    reducedVendor.dineroGuiD = vendor.DineroGuiD;
                    reducedVendor.PhoneNumber = vendor.PhoneNumber;
                    reducedVendor.postalCodeId = vendor.postalCodeId;
                    reducedVendor.CountryCode = vendor.CountryCode;
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

                     throw new Exception("Forced error in Vendor controller");

                    Vendor vendor = _vendorRepository.GetVendor(int.Parse(datamodelInput.id));
                    if (vendor != null)
                    {
                        vendor.Name = datamodelInput.name;
                        if (!string.IsNullOrEmpty(datamodelInput.cvrNumber))
                        {
                            vendor.CVRNumber = int.Parse(datamodelInput.cvrNumber);
                        }

                        vendor.Street = datamodelInput.street;
                        vendor.Zip = datamodelInput.zip;
                        vendor.City = datamodelInput.city;
                        vendor.Name = datamodelInput.name;
                        vendor.CountryCode = datamodelInput.CountryCode;
                        vendor.PhoneNumber = datamodelInput.PhoneNumber;
                        vendor.postalCodeId = datamodelInput.postalCodeId;
                        vendor.HomePage = datamodelInput.HomePage;
                        vendor.LastEditedDate = DateTime.Now;
                        _vendorRepository.Update(vendor);
                    }
                }

                if (datamodelInput.action.Equals("create"))
                {
                    Vendor vendor = new Vendor();

                    vendor.Name = datamodelInput.name;
                    if (!string.IsNullOrEmpty(datamodelInput.cvrNumber))
                    {
                        vendor.CVRNumber = int.Parse(datamodelInput.cvrNumber);
                    }
                    vendor.Street = datamodelInput.street;
                    vendor.Zip = datamodelInput.zip;
                    vendor.City = datamodelInput.city;
                    vendor.Name = datamodelInput.name;
                    vendor.CountryCode = datamodelInput.CountryCode;
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


                    //if (_dineroContacts.synchronizeCompanies)
                    //{
                    //    string status = _dineroContacts.AddContactToDineroAsync(newVendor).ToString();
                    //    if (!status.Equals("NotOK"))
                    //    {
                    //        Guid DineroGuidId = Guid.Parse(status);
                    //        newVendor.DineroGuiD = DineroGuidId;
                    //        _vendorRepository.Update(newVendor);
                    //    }
                    //}

                }

                if (datamodelInput.action.Equals("remove"))
                {
                    Vendor vendor = _vendorRepository.GetVendor(int.Parse(datamodelInput.id));
                    if (vendor != null)
                    {
                        _vendorRepository.Delete(int.Parse(datamodelInput.id));
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

        public class ReducedVendor
        {

            public string id { get; set; }
            public string name { get; set; }
            public string cvrNumber { get; set; }

            public string city { get; set; }
            public string street { get; set; }

            public string zip { get; set; }
            public string CountryCode { get; set; }
            public string PhoneNumber { get; set; }

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

            public string zip { get; set; }
            public string CountryCode { get; set; }
            public string PhoneNumber { get; set; }

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
