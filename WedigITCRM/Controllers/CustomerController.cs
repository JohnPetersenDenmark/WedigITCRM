using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WedigITCRM.Models;
using Newtonsoft.Json;
using System.Globalization;
using System.Security.Claims;
using WedigITCRM.Utilities;
using WedigITCRM.DineroAPI;
using WedigITCRM.ViewControllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using WedigITCRM.StorageInterfaces;
using WedigITCRM.EntitityModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WedigITCRM.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private ICurrencyCodeRepository _currencyCodeRepository;
        private ICompanyRepository _companyRepository;
        private IPostalCodeRepository _postalCodeRepository;
        private ICountryRepository _countryRepository;
        IContactPersonRepository _contactPersonRepository;
        IActivityRepository _activityRepository;
        SignInManager<IdentityUser> _signInManager;
        UserManager<IdentityUser> _userManager;
        ICompanyAccountRepository _companyAccountRepository;
        IRelateCompanyAccountWithUserRepository _relateCompanyAccountWithUserRepository;
        IWebHostEnvironment _env;

        AppDbContext _dbContext;

        public CustomerController(ICurrencyCodeRepository currencyCodeRepository, ICountryRepository countryRepository, IWebHostEnvironment env, IRelateCompanyAccountWithUserRepository relateCompanyAccountWithUserRepository, ICompanyAccountRepository companyAccountRepository, ICompanyRepository companyRepository, IPostalCodeRepository postalCodeRepository, IContactPersonRepository contactPersonRepository, IActivityRepository activityRepository, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, AppDbContext dbContext)
        {
            _currencyCodeRepository = currencyCodeRepository;
            _companyRepository = companyRepository;
            _postalCodeRepository = postalCodeRepository;
            _countryRepository = countryRepository;
            _contactPersonRepository = contactPersonRepository;
            _activityRepository = activityRepository;
            _signInManager = signInManager;
            _userManager = userManager;
            _companyAccountRepository = companyAccountRepository;
            _relateCompanyAccountWithUserRepository = relateCompanyAccountWithUserRepository;
            _env = env;
            _dbContext = dbContext;



        }

        public IActionResult Index()
        {
            RegisterCompanyAccountModel model = new RegisterCompanyAccountModel();
            model.UserName = _env.EnvironmentName;
            return View("~/Customer/AllCompaniesWithContactPersons.cshtml", model);
        }

        public IActionResult AllCompaniesWithContactPersons()
        {
            //
            return View();
        }

        public IActionResult AllCustomers()
        {
            return View();
        }

        public IActionResult AllContactPersons()
        {
            return View();
        }

        public IActionResult ActivitiesOnContactPerson()
        {
            return View();
        }

        public IActionResult ActivitiesOnCompany()
        {
            return View();
        }

        public IActionResult AllActivities()
        {
            return View();
        }

        public IActionResult NotesOnCompany()
        {
            return View();
        }




        //This action at EditCompany can bind JSON 
        [HttpPost]

        public IActionResult EditCompany([FromBody] CompanyInputPostModel datamodelInput, CompanyAccount companyAccount)
        {



            if (ModelState.IsValid)
            {

                if (datamodelInput.action.Equals("edit"))
                {
                    Company company = _companyRepository.GetCompany(int.Parse(datamodelInput.id));


                    if (company != null)
                    {
                        company.Name = datamodelInput.name;
                        if (!string.IsNullOrEmpty(datamodelInput.cvrNumber))
                        {
                            company.CVRNumber = datamodelInput.cvrNumber;
                        }

                        company.Street = datamodelInput.street;
                        company.Zip = datamodelInput.zip;
                        company.City = datamodelInput.city;
                        company.ForeignZip = datamodelInput.ForeignZip;
                        company.ForeignCity = datamodelInput.ForeignCity;
                        company.Name = datamodelInput.name;
                        company.CountryCode = datamodelInput.CountryCode;                      
                        company.CurrencyCode = datamodelInput.CurrencyCode;
                        company.PhoneNumber = datamodelInput.PhoneNumber;
                        company.postalCodeId = datamodelInput.postalCodeId;
                        company.HomePage = datamodelInput.HomePage;
                        company.LastEditedDate = DateTime.Now;
                        if (datamodelInput.IsPerson.Equals("Ja"))
                        {
                            company.IsPerson = true;
                        }
                        else
                        {
                            company.IsPerson = false;
                        }

                        company.Email = datamodelInput.Email;

                        Company newCompany = _companyRepository.Update(company);

                        DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
                        string danishdatetime = DateTime.Now.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);

                        datamodelInput.LastEditedDate = danishdatetime;

                        if (companyAccount.IntegrationDinero && companyAccount.synchronizeCustomerFromNyxiumToDinero)
                        {
                            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
                            if (dineroAPIConnect.connectToDinero(companyAccount.DineroAPIOrganizationKey, companyAccount.DineroAPIOrganization) != null)
                            {
                                DineroContacts dineroContacts = new DineroContacts(dineroAPIConnect);
                                string status = dineroContacts.UpdateCustomerContactInDinero(newCompany, newCompany.DineroGuiD);
                            }
                        }
                    }
                }

                if (datamodelInput.action.Equals("create"))
                {
                    Company company = new Company();

                    company.Name = datamodelInput.name;
                    if (!string.IsNullOrEmpty(datamodelInput.cvrNumber))
                    {
                        company.CVRNumber = datamodelInput.cvrNumber;
                    }
                    company.Street = datamodelInput.street;
                    company.Zip = datamodelInput.zip;
                    company.City = datamodelInput.city;
                    company.ForeignZip = datamodelInput.ForeignZip;
                    company.ForeignCity = datamodelInput.ForeignCity;
                    company.Name = datamodelInput.name;
                    company.CountryCode = datamodelInput.CountryCode;
                    company.CurrencyCode = datamodelInput.CurrencyCode;
                    company.PhoneNumber = datamodelInput.PhoneNumber;
                    company.postalCodeId = datamodelInput.postalCodeId;
                    company.HomePage = datamodelInput.HomePage;
                    company.companyAccountId = companyAccount.companyAccountId;
                    if (datamodelInput.IsPerson.Equals("Ja"))
                    {
                        company.IsPerson = true;
                    }
                    else
                    {
                        company.IsPerson = false;
                    }
                    company.Email = datamodelInput.Email;
                    company.LastEditedDate = DateTime.Now;
                    company.CreatedDate = DateTime.Now;

                    Company newCompany = _companyRepository.Add(company);



                    datamodelInput.id = newCompany.Id.ToString();

                    DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
                    string danishdatetime = DateTime.Now.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);

                    datamodelInput.LastEditedDate = danishdatetime;
                    datamodelInput.CreatedDate = danishdatetime;


                    if (companyAccount.IntegrationDinero && companyAccount.synchronizeCustomerFromNyxiumToDinero)
                    {
                        DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
                        if (dineroAPIConnect.connectToDinero(companyAccount.DineroAPIOrganizationKey, companyAccount.DineroAPIOrganization) != null)
                        {
                            DineroContacts dineroContacts = new DineroContacts(dineroAPIConnect);
                            string status = dineroContacts.AddCustomerContactToDineroAsync(newCompany).ToString();
                            if (!status.Equals("NotOK"))
                            {
                                Guid DineroGuidId = Guid.Parse(status);
                                newCompany.DineroGuiD = DineroGuidId;
                                _companyRepository.Update(newCompany);
                            }
                        }
                    }

                }

                if (datamodelInput.action.Equals("remove"))
                {
                    Company company = _companyRepository.GetCompany(int.Parse(datamodelInput.id));
                    if (company != null)
                    {
                        _companyRepository.Delete(int.Parse(datamodelInput.id));

                        if (companyAccount.IntegrationDinero && companyAccount.synchronizeCustomerFromNyxiumToDinero)
                        {
                            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
                            if (dineroAPIConnect.connectToDinero(companyAccount.DineroAPIOrganizationKey, companyAccount.DineroAPIOrganization) != null)
                            {
                                DineroContacts dineroContacts = new DineroContacts(dineroAPIConnect);
                                dineroContacts.DeleteContactInDinero(company.DineroGuiD);
                            }
                        }
                    }
                }
            }


            CompanyOutputDataModel datamodelOutput = new CompanyOutputDataModel();
            datamodelInput.DT_RowId = datamodelInput.id;

            datamodelOutput.data.Add(datamodelInput);

            return Json(datamodelOutput);
        }

        public IActionResult EditContactPerson([FromBody] ContactPersonInputPostModel datamodelInput, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {

                if (datamodelInput.action.Equals("edit"))
                {
                    ContactPerson contactPerson = _contactPersonRepository.GetContactPerson(int.Parse(datamodelInput.id));
                    if (contactPerson != null)
                    {
                        contactPerson.FirstName = datamodelInput.firstName;
                        contactPerson.LastName = datamodelInput.lastName;
                        contactPerson.Title = datamodelInput.title;
                        contactPerson.Email = datamodelInput.email;
                        contactPerson.Department = datamodelInput.Department;
                        contactPerson.CellPhone = datamodelInput.cellPhone;
                        contactPerson.PhoneNumber = datamodelInput.phoneNumber;
                        contactPerson.LastEditedDate = DateTime.Now;
                        _contactPersonRepository.Update(contactPerson);


                        DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
                        string danishdatetime = DateTime.Now.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);

                        datamodelInput.lastEditedDate = danishdatetime;
                    }
                }

                if (datamodelInput.action.Equals("create"))
                {
                    ContactPerson contactPerson = new ContactPerson();

                    contactPerson.FirstName = datamodelInput.firstName;
                    contactPerson.LastName = datamodelInput.lastName;
                    contactPerson.Title = datamodelInput.title;
                    contactPerson.Email = datamodelInput.email;
                    contactPerson.CellPhone = datamodelInput.cellPhone;
                    contactPerson.CompanyId = datamodelInput.companyId;
                    contactPerson.Department = datamodelInput.Department;
                    contactPerson.PhoneNumber = datamodelInput.phoneNumber;
                    contactPerson.companyAccountId = companyAccount.companyAccountId;
                    contactPerson.LastEditedDate = DateTime.Now;
                    contactPerson.CreatedDate = DateTime.Now;
                    ContactPerson newContactPerson = _contactPersonRepository.Add(contactPerson);


                    datamodelInput.id = newContactPerson.Id.ToString();

                    DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
                    string danishdatetime = DateTime.Now.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);

                    datamodelInput.lastEditedDate = danishdatetime;
                    datamodelInput.createdDate = danishdatetime;
                }

                if (datamodelInput.action.Equals("remove"))
                {
                    ContactPerson contactPerson = _contactPersonRepository.GetContactPerson(int.Parse(datamodelInput.id));
                    if (contactPerson != null)
                    {

                        _contactPersonRepository.Delete(int.Parse(datamodelInput.id));
                    }
                }
            }
            ContactPersonOutputDataModel datamodelOutput = new ContactPersonOutputDataModel();
            datamodelInput.DT_RowId = datamodelInput.id;

            datamodelOutput.data.Add(datamodelInput);

            return Json(datamodelOutput);
        }

        public IActionResult EditActivity([FromBody] ActivityPostModel model, CompanyAccount companyAccount)
        {
            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            DateTime testdate;

            if (ModelState.IsValid)
            {


                if (model.action.Equals("edit"))
                {
                    Activity activity = _activityRepository.getActivity(int.Parse(model.Id));
                    if (activity != null)
                    {
                        activity.Subject = model.Subject;
                        activity.Description = model.Description;

                        if (!string.IsNullOrEmpty(model.Date))
                        {
                            if (DateTime.TryParse(model.Date, out testdate))
                            {
                                activity.Date = DateTime.Parse(model.Date, danishDateTimeformat);
                            }
                            else
                            {
                                activity.Date = DateTime.Now;
                            }
                        }
                        else
                        {
                            activity.Date = DateTime.Now;
                        }

                        activity.NotifyOffset = model.NotifyOffset;
                        activity.NotificationIsSent = model.NotificationIsSent;
                        activity.LastEditedDate = DateTime.Now;
                        _activityRepository.Update(activity);
                    }

                }

                if (model.action.Equals("create"))
                {
                    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  // get logged in user id
                    Activity activity = new Activity();

                    activity.Subject = model.Subject;
                    activity.Description = model.Description;


                    if (!string.IsNullOrEmpty(model.Date))
                    {
                        if (DateTime.TryParse(model.Date, out testdate))
                        {
                            activity.Date = DateTime.Parse(model.Date, danishDateTimeformat);
                        }
                        else
                        {
                            activity.Date = DateTime.Now;
                        }
                    }
                    else
                    {
                        activity.Date = DateTime.Now;
                    }

                    activity.NotifyOffset = model.NotifyOffset;
                    activity.NotificationIsSent = model.NotificationIsSent;
                    if (!string.IsNullOrEmpty(model.CompanyId))
                    {
                        activity.CompanyId = Int32.Parse(model.CompanyId);
                    }

                    activity.UserId = userId;
                    if (!string.IsNullOrEmpty(model.contactPersonId))
                    {
                        activity.contactPersonId = Int32.Parse(model.contactPersonId);
                    }

                    activity.LastEditedDate = DateTime.Now;
                    activity.CreatedDate = DateTime.Now;
                    activity.companyAccountId = companyAccount.companyAccountId;
                    Activity newActivity = _activityRepository.Add(activity);


                    model.DT_RowId = newActivity.Id.ToString();
                    model.Id = newActivity.Id.ToString();

                    DateTime todaynow = DateTime.Now;
                    DateTime todaynowRoundedUp = MiscUtility.roundUpToNearest15minutes(todaynow);

                    // DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
                    string danishdatetime = todaynowRoundedUp.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);

                    model.LastEditedDate = danishdatetime;
                    model.CreatedDate = danishdatetime;


                }

                if (model.action.Equals("remove"))
                {
                    Activity activity = _activityRepository.getActivity(int.Parse(model.Id));
                    if (activity != null)
                    {
                        _activityRepository.Delete(int.Parse(model.Id));
                    }

                }
            }

            ActivityOutputDataModel datamodelOutput = new ActivityOutputDataModel();


            datamodelOutput.data.Add(model);

            return Json(datamodelOutput);

        }

        public IActionResult getZipCodes()
        {
            List<PostalCode> dbPostalCodes = _postalCodeRepository.getAllZips().ToList();
            Dictionary<string, string> postalCodes = new Dictionary<string, string>();

            foreach (var dbbPostalCode in dbPostalCodes)
            {
                postalCodes.Add(dbbPostalCode.Id.ToString(), dbbPostalCode.Zip);
            }

            var x = Json(postalCodes);
            return Json(postalCodes);
        }

        public IActionResult getCountries()
        {
            List<Country> countryList = _countryRepository.getAllCountries().ToList();
            Dictionary<string, string> countries = new Dictionary<string, string>();


            foreach (var country in countryList)
            {
                countries.Add(country.CountryCode, country.CountryName);
            }


            return Json(countries);
        }

        public IActionResult getCurrencies()
        {

            List<CurrencyCode> currencyList = _currencyCodeRepository.getAllCurrencyCodes().ToList();
            Dictionary<string, string> currencies = new Dictionary<string, string>();


            foreach (var currencyCode in currencyList)
            {
                currencies.Add(currencyCode.Id, currencyCode.Description);
            }


            return Json(currencies);
        }


        public IActionResult getCityByZipCode([FromBody] CompanyInputPostModel model)
        {

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.zip))
                {
                    List<PostalCode> postalCodes = _postalCodeRepository.getAllZips().Where(postal => postal.Zip.Equals(model.zip)).ToList();

                    if (postalCodes.Count == 1)
                    {
                        PostalCode postalCode = postalCodes.First();
                        model.city = postalCode.City;
                        model.postalCodeId = postalCode.Id.ToString();
                    }
                }
            }

            return Json(model);
        }

        public IActionResult getCityByPostalCode([FromBody] CompanyInputPostModel model)
        {

            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.postalCodeId))
                {
                    PostalCode postalCode = _postalCodeRepository.getPostalCodeById(int.Parse(model.postalCodeId));
                    if (postalCode != null)
                    {
                        model.city = postalCode.City;

                    }
                }
            }


            return Json(model);
        }


        public IActionResult getCompanies(string customerCategory, CompanyAccount companyAccount)
        {

            List<Company> companies = new List<Company>();

            //throw new Exception("throw error ");

            if (!string.IsNullOrEmpty(customerCategory))
            {
                if (customerCategory.Equals("1"))
                {
                    companies = _companyRepository.GetAllCompanies().Where(company => company.companyAccountId == companyAccount.companyAccountId).ToList();
                }

                if (customerCategory.Equals("2"))
                {
                    companies = _companyRepository.GetAllCompanies().Where(company => company.IsPerson == true && company.companyAccountId == companyAccount.companyAccountId).ToList();
                }

                if (customerCategory.Equals("3"))
                {
                    companies = _companyRepository.GetAllCompanies().Where(company => company.IsPerson == false && company.companyAccountId == companyAccount.companyAccountId).ToList();
                }

            }
            else
            {
                companies = _companyRepository.GetAllCompanies().Where(company => company.companyAccountId == companyAccount.companyAccountId).ToList();
            }


            List<reducedCustomer> data1 = new List<reducedCustomer>();
            foreach (var customer in companies)
            {
                DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

                reducedCustomer ReducedCustomer = new reducedCustomer();
                ReducedCustomer.id = customer.Id.ToString();
                ReducedCustomer.name = customer.Name;
                ReducedCustomer.street = customer.Street;
                ReducedCustomer.city = customer.City;
                ReducedCustomer.zip = customer.Zip;
                ReducedCustomer.ForeignCity = customer.ForeignCity;
                ReducedCustomer.ForeignZip = customer.ForeignZip;
                ReducedCustomer.CountryCode = customer.CountryCode;
                ReducedCustomer.CurrencyCode = customer.CurrencyCode;

                ReducedCustomer.HomePage = customer.HomePage;
                ReducedCustomer.LastEditedDate = customer.LastEditedDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                ReducedCustomer.CreatedDate = customer.CreatedDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                ReducedCustomer.dineroGuiD = customer.DineroGuiD;
                ReducedCustomer.PhoneNumber = customer.PhoneNumber;
                if (customer.IsPerson)
                {
                    ReducedCustomer.IsPerson = "Ja";
                }
                else
                {
                    ReducedCustomer.IsPerson = "Nej";
                }

                ReducedCustomer.Email = customer.Email;
                ReducedCustomer.cvrNumber = customer.CVRNumber;
                ReducedCustomer.postalCodeId = customer.postalCodeId;
                ReducedCustomer.companyAccountId = customer.companyAccountId;
                data1.Add(ReducedCustomer);
            }

            return Json(data1);

        }

        public class GetCustomerByCategory
        {
            public string CustomerCategory { get; set; }
        }

        public IActionResult getContactPersons(string companyId, string selectAll, CompanyAccount companyAccount)
        {

            DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
            ContactPersonOutputDataModel1 contactPersonOutputDataModel1 = new ContactPersonOutputDataModel1();



            List<ContactPerson> contactPersonData = null;
            if (!string.IsNullOrEmpty(companyId))
            {

                contactPersonData = _contactPersonRepository.GetAllContactPersons().Where(contact => contact.CompanyId.ToString().Equals(companyId) && contact.companyAccountId == companyAccount.companyAccountId).ToList();
            }
            else
            {
                if (!string.IsNullOrEmpty(selectAll) && selectAll.Equals("1"))
                {
                    contactPersonData = _contactPersonRepository.GetAllContactPersons().Where(contact => contact.companyAccountId == companyAccount.companyAccountId).ToList();
                }
                else
                {
                    contactPersonOutputDataModel1.data = new List<ReducedContactPerson>();
                    return Json(contactPersonOutputDataModel1);
                }
            }


            foreach (var contactPerson in contactPersonData)
            {
                ReducedContactPerson reducedContactPerson = new ReducedContactPerson();
                reducedContactPerson.CellPhone = contactPerson.CellPhone;
                reducedContactPerson.companyAccountId = contactPerson.companyAccountId;
                reducedContactPerson.CompanyId = contactPerson.CompanyId.ToString();
                reducedContactPerson.CreatedDate = contactPerson.CreatedDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern); ;
                reducedContactPerson.Department = contactPerson.Department;
                reducedContactPerson.DineroGuiD = contactPerson.DineroGuiD;
                reducedContactPerson.Email = contactPerson.Email;
                reducedContactPerson.FirstName = contactPerson.FirstName;
                reducedContactPerson.Id = contactPerson.Id.ToString();
                reducedContactPerson.LastEditedDate = contactPerson.LastEditedDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                reducedContactPerson.LastName = contactPerson.LastName;
                reducedContactPerson.PhoneNumber = contactPerson.PhoneNumber;
                reducedContactPerson.Title = contactPerson.Title;
                contactPersonOutputDataModel1.data.Add(reducedContactPerson);
            }




            return Json(contactPersonOutputDataModel1);


        }

        public IActionResult getActivities(string contactPersonId, string companyId, string searchAll, CompanyAccount companyAccount)
        {

            ActivityOutputDataModel activityOutputDataModel = new ActivityOutputDataModel();

            List<Activity> activityData = null;




            if (!string.IsNullOrEmpty(contactPersonId))
            {

                activityData = _activityRepository.GetAllActivities().Where(activity => activity.contactPersonId.ToString().Equals(contactPersonId) && activity.companyAccountId == companyAccount.companyAccountId).ToList();
            }
            else
            {
                if (!string.IsNullOrEmpty(companyId))
                {

                    activityData = _activityRepository.GetAllActivities().Where(activity => activity.CompanyId.ToString().Equals(companyId) && activity.companyAccountId == companyAccount.companyAccountId).ToList();
                }
                else
                {
                    if (searchAll.Equals("1"))
                    {
                        activityData = _activityRepository.GetAllActivities().Where(activity => activity.companyAccountId == companyAccount.companyAccountId).ToList();
                    }
                    else
                    {
                        activityOutputDataModel.data = new List<ActivityPostModel>();
                        return Json(activityOutputDataModel);
                    }
                }

            }



            foreach (var activity in activityData)
            {
                DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

                ActivityPostModel activityTosend = new ActivityPostModel();
                activityTosend.Id = activity.Id.ToString();

                activityTosend.Date = activity.Date.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);

                activityTosend.Subject = activity.Subject;
                activityTosend.Description = activity.Description;
                activityTosend.NotifyOffset = activity.NotifyOffset;

                activityTosend.companyAccountId = activity.companyAccountId.ToString();

                activityTosend.CompanyId = activity.CompanyId.ToString();
                activityTosend.contactPersonId = activity.contactPersonId.ToString();

                if (activity.CompanyId != 0)
                {
                    Company company = _companyRepository.GetCompany(activity.CompanyId);
                    if (company != null)
                    {
                        activityTosend.NameOfContactOrCompany = company.Name;
                    }
                }
                else
                {
                    if (activity.contactPersonId != 0)
                    {
                        ContactPerson contactPerson = _contactPersonRepository.GetContactPerson(activity.contactPersonId);
                        if (contactPerson != null)
                        {
                            activityTosend.NameOfContactOrCompany = contactPerson.FirstName + " " + contactPerson.LastName;
                        }
                    }
                }


                activityTosend.LastEditedDate = activity.LastEditedDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                activityTosend.CreatedDate = activity.LastEditedDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);


                activityOutputDataModel.data.Add(activityTosend);
            }

            return Json(activityOutputDataModel);

        }

    }



    public class reducedCustomer
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

        public string HomePage { get; set; }
        public string postalCodeId { get; set; }

        public Guid dineroGuiD { get; set; }
        public string IsPerson { get; set; }
        public string Email { get; set; }
        public int companyAccountId { get; set; }
        public string LastEditedDate { get; set; }

        public string CreatedDate { get; set; }
    }


    public class ReducedContactPerson
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string CellPhone { get; set; }
        public string Department { get; set; }
        public string CompanyId { get; set; }

        public int companyAccountId { get; set; }
        public Guid DineroGuiD { get; set; }

        public string LastEditedDate { get; set; }

        public string CreatedDate { get; set; }
    }




    public class CompanyOutputDataModel
    {
        public CompanyOutputDataModel()
        {
            this.data = new List<CompanyInputPostModel>();
        }
        public List<CompanyInputPostModel> data { get; set; }

    }
    public class CompanyInputPostModel
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
        public string PhoneNumber { get; set; }

        public string HomePage { get; set; }
        public string postalCodeId { get; set; }

        public string action { get; set; }

        public int companyAccountId { get; set; }
        public Guid dineroGuiD { get; set; }
        public string LastEditedDate { get; set; }
        public string IsPerson { get; set; }
        public string Email { get; set; }
        public string CreatedDate { get; set; }
    }

    public class ContactPersonOutputDataModel1
    {
        public ContactPersonOutputDataModel1()
        {
            this.data = new List<ReducedContactPerson>();
        }
        public List<ReducedContactPerson> data { get; set; }

    }



    public class ContactPersonOutputDataModel
    {
        public ContactPersonOutputDataModel()
        {
            this.data = new List<ContactPersonInputPostModel>();
        }
        public List<ContactPersonInputPostModel> data { get; set; }

    }
    public class ContactPersonInputPostModel
    {
        public string DT_RowId { get; set; }
        public string id { get; set; }
        public string firstName { get; set; }

        public string lastName { get; set; }
        public string title { get; set; }

        public string email { get; set; }

        public string cellPhone { get; set; }

        public string phoneNumber { get; set; }
        public string Department { get; set; }
        public int companyId { get; set; }

        public int companyAccountId { get; set; }
        public string dineroGuiD { get; set; }

        public string lastEditedDate { get; set; }

        public string createdDate { get; set; }

        public string action { get; set; }
    }

    public class ActivityOutputDataModel
    {
        public ActivityOutputDataModel()
        {
            this.data = new List<ActivityPostModel>();
        }
        public List<ActivityPostModel> data { get; set; }

    }

    public class ActivityPostModel
    {
        public string Id { get; set; }

        public string DT_RowId { get; set; }
        public string Date { get; set; }


        public string NotifyOffset { get; set; }

        public bool NotificationIsSent { get; set; }

        public string NameOfContactOrCompany { get; set; }

        public string Subject { get; set; }
        public string Description { get; set; }

        public string contactPersonId { get; set; }
        public string CompanyId { get; set; }

        public string UserId { get; set; }

        public string companyAccountId { get; set; }

        public string LastEditedDate { get; set; }

        public string CreatedDate { get; set; }
        public string action { get; set; }

    }
}
