using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.DineroAPI;
using WedigITCRM.EntitityModels;
using WedigITCRM.Models;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.Controllers
{
    public class ContactController : Controller
    {
        private ICurrencyCodeRepository _currencyCodeRepository;
        private IContactRepository _contactRepository;
        private IPostalCodeRepository _postalCodeRepository;
        private ICountryRepository _countryRepository;
        private IContactPersonRepository _contactPersonRepository;
        private IActivityRepository _activityRepository;
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private ICompanyAccountRepository _companyAccountRepository;
        private IRelateCompanyAccountWithUserRepository _relateCompanyAccountWithUserRepository;
        private IWebHostEnvironment _env;
        private AppDbContext _dbContext;

        public ContactController(ICurrencyCodeRepository currencyCodeRepository, ICountryRepository countryRepository, IWebHostEnvironment env, IRelateCompanyAccountWithUserRepository relateCompanyAccountWithUserRepository, ICompanyAccountRepository companyAccountRepository, IContactRepository contactRepository, IPostalCodeRepository postalCodeRepository, IContactPersonRepository contactPersonRepository, IActivityRepository activityRepository, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, AppDbContext dbContext)
        {
            _currencyCodeRepository = currencyCodeRepository;
            _contactRepository = contactRepository;
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

        public IActionResult AllContacts()
        {
            return View();
        }

        public IActionResult getContacts(string contactCategory, CompanyAccount companyAccount)
        {

            List<Contact> contacts = new List<Contact>();


            if (!string.IsNullOrEmpty(contactCategory))
            {
                if (contactCategory.Equals("1"))
                {
                    contacts = _contactRepository.GetAllContacts().Where(contact => contact.companyAccountId == companyAccount.companyAccountId).ToList();
                }

                if (contactCategory.Equals("2"))
                {
                    contacts = _contactRepository.GetAllContacts().Where(contact => contact.IsPerson == true && contact.companyAccountId == companyAccount.companyAccountId).ToList();
                }

                if (contactCategory.Equals("3"))
                {
                    contacts = _contactRepository.GetAllContacts().Where(contact => contact.IsPerson == false && contact.companyAccountId == companyAccount.companyAccountId).ToList();
                }

            }
            else
            {
                contacts = _contactRepository.GetAllContacts().Where(contact => contact.companyAccountId == companyAccount.companyAccountId).ToList();
            }


            List<reducedContact> data1 = new List<reducedContact>();
            foreach (var customer in contacts)
            {
                DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;

                reducedContact reducedContact = new reducedContact();
                reducedContact.id = customer.Id.ToString();
                reducedContact.name = customer.Name;
                reducedContact.street = customer.Street;
                reducedContact.city = customer.City;
                reducedContact.zip = customer.Zip;
                reducedContact.ForeignCity = customer.ForeignCity;
                reducedContact.ForeignZip = customer.ForeignZip;
                reducedContact.CountryCode = customer.CountryCode;
                reducedContact.CurrencyCode = customer.CurrencyCode;

                reducedContact.HomePage = customer.HomePage;
                reducedContact.LastEditedDate = customer.LastEditedDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                reducedContact.CreatedDate = customer.CreatedDate.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);
                reducedContact.dineroGuiD = customer.DineroGuiD;
                reducedContact.PhoneNumber = customer.PhoneNumber;
                if (customer.IsPerson)
                {
                    reducedContact.IsPerson = "Ja";
                }
                else
                {
                    reducedContact.IsPerson = "Nej";
                }

                reducedContact.Email = customer.Email;
                reducedContact.cvrNumber = customer.CVRNumber;
                reducedContact.postalCodeId = customer.postalCodeId;
                reducedContact.companyAccountId = customer.companyAccountId;
                data1.Add(reducedContact);
            }

            return Json(data1);

        }

        [HttpPost]

        public IActionResult EditContact([FromBody] ContactInputPostModel datamodelInput, CompanyAccount companyAccount)
        {
            if (ModelState.IsValid)
            {
                if (datamodelInput.action.Equals("create"))
                {
                    Contact contact = new Contact();

                    contact.Name = datamodelInput.name;
                    if (!string.IsNullOrEmpty(datamodelInput.cvrNumber))
                    {
                        contact.CVRNumber = datamodelInput.cvrNumber;
                    }
                    contact.Street = datamodelInput.street;
                    contact.Zip = datamodelInput.zip;
                    contact.City = datamodelInput.city;
                    contact.ForeignZip = datamodelInput.ForeignZip;
                    contact.ForeignCity = datamodelInput.ForeignCity;
                    contact.Name = datamodelInput.name;
                    contact.CountryCode = datamodelInput.CountryCode;
                    contact.CurrencyCode = datamodelInput.CurrencyCode;
                    contact.PhoneNumber = datamodelInput.PhoneNumber;
                    contact.postalCodeId = datamodelInput.postalCodeId;
                    contact.HomePage = datamodelInput.HomePage;
                    contact.companyAccountId = companyAccount.companyAccountId;
                    if (datamodelInput.IsPerson.Equals("Ja"))
                    {
                        contact.IsPerson = true;
                    }
                    else
                    {
                        contact.IsPerson = false;
                    }
                    contact.Email = datamodelInput.Email;
                    contact.LastEditedDate = DateTime.Now;
                    contact.CreatedDate = DateTime.Now;

                    Contact newContact = _contactRepository.Add(contact);



                    datamodelInput.id = newContact.Id.ToString();

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
                            string status = dineroContacts.AddContactToDineroAsync(newContact).ToString();
                            if (!status.Equals("NotOK"))
                            {
                                Guid DineroGuidId = Guid.Parse(status);
                                newContact.DineroGuiD = DineroGuidId;
                                _contactRepository.Update(newContact);
                            }
                        }
                    }

                }

                if (datamodelInput.action.Equals("edit"))
                {
                    Contact contact = _contactRepository.GetContact(int.Parse(datamodelInput.id));


                    if (contact != null)
                    {
                        contact.Name = datamodelInput.name;
                        if (!string.IsNullOrEmpty(datamodelInput.cvrNumber))
                        {
                            contact.CVRNumber = datamodelInput.cvrNumber;
                        }

                        contact.Street = datamodelInput.street;
                        contact.Zip = datamodelInput.zip;
                        contact.City = datamodelInput.city;
                        contact.ForeignZip = datamodelInput.ForeignZip;
                        contact.ForeignCity = datamodelInput.ForeignCity;
                        contact.Name = datamodelInput.name;
                        contact.CountryCode = datamodelInput.CountryCode;
                        contact.CurrencyCode = datamodelInput.CurrencyCode;
                        contact.PhoneNumber = datamodelInput.PhoneNumber;
                        contact.postalCodeId = datamodelInput.postalCodeId;
                        contact.HomePage = datamodelInput.HomePage;
                        contact.LastEditedDate = DateTime.Now;
                        if (datamodelInput.IsPerson.Equals("Ja"))
                        {
                            contact.IsPerson = true;
                        }
                        else
                        {
                            contact.IsPerson = false;
                        }

                        contact.Email = datamodelInput.Email;

                        Contact newcontact = _contactRepository.Update(contact);

                        DateTimeFormatInfo danishDateTimeformat = CultureInfo.GetCultureInfo("da-DK").DateTimeFormat;
                        string danishdatetime = DateTime.Now.ToString(danishDateTimeformat.ShortDatePattern + " " + danishDateTimeformat.ShortTimePattern);

                        datamodelInput.LastEditedDate = danishdatetime;

                        if (companyAccount.IntegrationDinero && companyAccount.synchronizeCustomerFromNyxiumToDinero)
                        {
                            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
                            if (dineroAPIConnect.connectToDinero(companyAccount.DineroAPIOrganizationKey, companyAccount.DineroAPIOrganization) != null)
                            {
                                DineroContacts dineroContacts = new DineroContacts(dineroAPIConnect);
                                string status = dineroContacts.UpdateContactInDinero(newcontact, newcontact.DineroGuiD);
                            }
                        }
                    }
                }

                if (datamodelInput.action.Equals("remove"))
                {
                    Contact contact = _contactRepository.GetContact(int.Parse(datamodelInput.id));
                    if (contact != null)
                    {
                        _contactRepository.Delete(int.Parse(datamodelInput.id));

                        if (companyAccount.IntegrationDinero && companyAccount.synchronizeCustomerFromNyxiumToDinero)
                        {
                            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
                            if (dineroAPIConnect.connectToDinero(companyAccount.DineroAPIOrganizationKey, companyAccount.DineroAPIOrganization) != null)
                            {
                                DineroContacts dineroContacts = new DineroContacts(dineroAPIConnect);
                                dineroContacts.DeleteContactInDinero(contact.DineroGuiD);
                            }
                        }
                    }
                }
            }

            ContactOutputDataModel datamodelOutput = new ContactOutputDataModel();

            datamodelInput.DT_RowId = datamodelInput.id;

            datamodelOutput.data.Add(datamodelInput);

            return Json(datamodelOutput);
        }
    }

    public class ContactOutputDataModel
    {
        public ContactOutputDataModel()
        {
            this.data = new List<ContactInputPostModel>();
        }
        public List<ContactInputPostModel> data { get; set; }

    }


    public class ContactInputPostModel
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

        public string companyAccountId { get; set; }
        public Guid dineroGuiD { get; set; }
        public string LastEditedDate { get; set; }
        public string IsPerson { get; set; }
        public string Email { get; set; }
        public string CreatedDate { get; set; }
    }

  
    public class reducedContact
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
}
