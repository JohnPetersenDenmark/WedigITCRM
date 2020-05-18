using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using WedigITCRM.Models;
using WedigITCRM.StorageInterfaces;

namespace WedigITCRM.DineroAPI
{
    public class DineroContacts
    {

        private DineroAPIConnect _dineroAPIConnect;



        public DineroContacts(DineroAPIConnect dineroAPIConnect)
        {
            _dineroAPIConnect = dineroAPIConnect;

        }

        public READDineroAPIcollection getContactsFromDinero(string LastupdatedDateTime, Int32 page, Int32 pageSize)
        {


            READDineroAPIcontact dineroAPIcontact = new READDineroAPIcontact();
            Type type = dineroAPIcontact.GetType();
            string fieldList = getFieldListFromClass(type);


            WebClient client = new WebClient();
            client.Headers.Add("Authorization", "Bearer " + _dineroAPIConnect._APItoken);
            String JsonString = client.DownloadString(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "contacts" + "?fields=" + fieldList + "&changesSince=" + LastupdatedDateTime + "&page=" + page + "&pageSize=" + pageSize);

            return (JsonConvert.DeserializeObject<READDineroAPIcollection>(JsonString));
        }

        public READDineroAPIcontact getContactFromDinero(Guid dineroId)
        {
            string dineroIdStr = dineroId.ToString();
            WebClient client = new WebClient();
            client.Headers.Add("Authorization", "Bearer " + _dineroAPIConnect._APItoken);

            String JsonString = client.DownloadString(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "contacts" + "/" + dineroIdStr);
            return (JsonConvert.DeserializeObject<READDineroAPIcontact>(JsonString));
        }



        public string AddCustomerContactToDineroAsync(Company contact)
        {
            ADDAndUpdateDineroAPIcontact dineroContact = new ADDAndUpdateDineroAPIcontact();
            ADDAndUpdateDineroAPIcontact contactToAdd = MapWedigitCustomerToDineroContact(contact, dineroContact);


            HttpClient client = new HttpClient();

            string tmpJson = JsonConvert.SerializeObject(contactToAdd);

            var content = new StringContent(JsonConvert.SerializeObject(contactToAdd), System.Text.Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _dineroAPIConnect._APItoken);

            var result = client.PostAsync(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "contacts", content).Result;
            if (result.IsSuccessStatusCode)
            {
                JObject JsonObj = JsonConvert.DeserializeObject<JObject>(result.Content.ReadAsStringAsync().Result);
                string returnValue = JsonObj.GetValue("ContactGuid").ToString();
                return returnValue;
            }
            return ("NotOK");
        }

        public string AddVendorToDinero(Vendor vendor)
        {
            ADDAndUpdateDineroAPIcontact dineroContact = new ADDAndUpdateDineroAPIcontact();
            ADDAndUpdateDineroAPIcontact contactToAdd = MapWedigitVendorToDineroContact(vendor, dineroContact);


            HttpClient client = new HttpClient();

            string tmpJson = JsonConvert.SerializeObject(contactToAdd);

            var content = new StringContent(JsonConvert.SerializeObject(contactToAdd), System.Text.Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _dineroAPIConnect._APItoken);

            var result = client.PostAsync(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "contacts", content).Result;
            if (result.IsSuccessStatusCode)
            {
                JObject JsonObj = JsonConvert.DeserializeObject<JObject>(result.Content.ReadAsStringAsync().Result);
                string returnValue = JsonObj.GetValue("ContactGuid").ToString();
                return returnValue;
            }
            return ("NotOK");
        }

        public string AddContactToDineroAsync(Contact contact)
        {
            ADDAndUpdateDineroAPIcontact dineroContact = new ADDAndUpdateDineroAPIcontact();
            ADDAndUpdateDineroAPIcontact contactToAdd = MapWedigitContactToDineroContact(contact, dineroContact);


            HttpClient client = new HttpClient();

            string tmpJson = JsonConvert.SerializeObject(contactToAdd);

            var content = new StringContent(JsonConvert.SerializeObject(contactToAdd), System.Text.Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _dineroAPIConnect._APItoken);

            var result = client.PostAsync(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "contacts", content).Result;
            if (result.IsSuccessStatusCode)
            {
                JObject JsonObj = JsonConvert.DeserializeObject<JObject>(result.Content.ReadAsStringAsync().Result);
                string returnValue = JsonObj.GetValue("ContactGuid").ToString();
                return returnValue;
            }
            return ("NotOK");
        }

        public string DeleteContactInDinero(Guid dineroId)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _dineroAPIConnect._APItoken);

            var response = client.DeleteAsync(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "contacts" + "/" + dineroId);
            if (response.Result.IsSuccessStatusCode)
            {
                return "OK";
            }
            return ("NotOK");
        }

        public string UpdateCustomerContactInDinero(Company contactCompanyOrPerson, Guid dineroContactGuid)
        {

            READDineroAPIcontact readDineroAPIcontact = getContactFromDinero(dineroContactGuid);

            if (readDineroAPIcontact == null)
            {
                return ("NotOK");
            }


            ADDAndUpdateDineroAPIcontact contactToUpdate = copyDineroContactFromreadToAddUpdate(readDineroAPIcontact);

            ADDAndUpdateDineroAPIcontact contactToAdd = MapWedigitCustomerToDineroContact(contactCompanyOrPerson, contactToUpdate);


            if (contactToUpdate == null)
            {
                return ("NotOK");
            }

            string tmpJson = JsonConvert.SerializeObject(contactToAdd);
            HttpClient client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(contactToAdd), System.Text.Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _dineroAPIConnect._APItoken);

            var result = client.PutAsync(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "contacts" + "/" + dineroContactGuid.ToString(), content).Result;
            if (result.IsSuccessStatusCode)
            {
                return "OK";
            }
            return ("NotOK");
        }

        public string UpdateContactInDinero(Contact contactCompanyOrPerson, Guid dineroContactGuid)
        {

            READDineroAPIcontact readDineroAPIcontact = getContactFromDinero(dineroContactGuid);

            if (readDineroAPIcontact == null)
            {
                return ("NotOK");
            }


            ADDAndUpdateDineroAPIcontact contactToUpdate = copyDineroContactFromreadToAddUpdate(readDineroAPIcontact);

            ADDAndUpdateDineroAPIcontact contactToAdd = MapWedigitContactToDineroContact(contactCompanyOrPerson, contactToUpdate);


            if (contactToUpdate == null)
            {
                return ("NotOK");
            }

            string tmpJson = JsonConvert.SerializeObject(contactToAdd);
            HttpClient client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(contactToAdd), System.Text.Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _dineroAPIConnect._APItoken);

            var result = client.PutAsync(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "contacts" + "/" + dineroContactGuid.ToString(), content).Result;
            if (result.IsSuccessStatusCode)
            {
                return "OK";
            }
            return ("NotOK");
        }

        public string UpdateVendorInDinero(Vendor vendor, Guid dineroContactGuid)
        {

            READDineroAPIcontact readDineroAPIcontact = getContactFromDinero(dineroContactGuid);

            if (readDineroAPIcontact == null)
            {
                return ("NotOK");
            }


            ADDAndUpdateDineroAPIcontact contactToUpdate = copyDineroContactFromreadToAddUpdate(readDineroAPIcontact);

            ADDAndUpdateDineroAPIcontact contactToAdd = MapWedigitVendorToDineroContact(vendor, contactToUpdate);
                                                        


            if (contactToUpdate == null)
            {
                return ("NotOK");
            }

            string tmpJson = JsonConvert.SerializeObject(contactToAdd);
            HttpClient client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(contactToAdd), System.Text.Encoding.UTF8, "application/json");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _dineroAPIConnect._APItoken);

            var result = client.PutAsync(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "contacts" + "/" + dineroContactGuid.ToString(), content).Result;
            if (result.IsSuccessStatusCode)
            {
                return "OK";
            }
            return ("NotOK");
        }



        public string getFieldListFromClass(Type type)
        {
            MethodInfo[] methods = type.GetMethods();
            List<string> methodNames = new List<string>();
            foreach (var method in methods)
            {

                if (method.IsPublic && method.Name.Contains("get_"))
                {
                    methodNames.Add(method.Name.Substring(4));
                }
            }

            string fieldlist = String.Join(",", methodNames);
            return fieldlist;
        }

        public ADDAndUpdateDineroAPIcontact MapWedigitCustomerToDineroContact(Company contactCompanyOrPerson, ADDAndUpdateDineroAPIcontact dineroContact)
        {

            
            dineroContact.IsPerson = contactCompanyOrPerson.IsPerson;

            dineroContact.Name = contactCompanyOrPerson.Name;
            dineroContact.Email = contactCompanyOrPerson.Email;
            dineroContact.Name = contactCompanyOrPerson.Name;
            dineroContact.Street = contactCompanyOrPerson.Street;

            if (contactCompanyOrPerson.CountryCode.Equals("DK"))
            {
                dineroContact.City = contactCompanyOrPerson.City;
                dineroContact.ZipCode = contactCompanyOrPerson.Zip;
            }
            else
            {
                dineroContact.City = contactCompanyOrPerson.ForeignCity;
                dineroContact.ZipCode = contactCompanyOrPerson.ForeignZip;
            }

            dineroContact.ExternalReference = "IsNyxiumCustomer";
            dineroContact.VatNumber = contactCompanyOrPerson.CVRNumber;
            dineroContact.CountryKey = contactCompanyOrPerson.CountryCode;           
            dineroContact.Phone = contactCompanyOrPerson.PhoneNumber;
            dineroContact.Webpage = contactCompanyOrPerson.HomePage;
            dineroContact.IsMember = false;
            dineroContact.UseCvr = false;


            return dineroContact;
        }

        public ADDAndUpdateDineroAPIcontact MapWedigitContactToDineroContact(Contact contactCompanyOrPerson, ADDAndUpdateDineroAPIcontact dineroContact)
        {


            dineroContact.IsPerson = contactCompanyOrPerson.IsPerson;

            dineroContact.Name = contactCompanyOrPerson.Name;
            dineroContact.Email = contactCompanyOrPerson.Email;
            dineroContact.Name = contactCompanyOrPerson.Name;
            dineroContact.Street = contactCompanyOrPerson.Street;

            if (contactCompanyOrPerson.CountryCode.Equals("DK"))
            {
                dineroContact.City = contactCompanyOrPerson.City;
                dineroContact.ZipCode = contactCompanyOrPerson.Zip;
            }
            else
            {
                dineroContact.City = contactCompanyOrPerson.ForeignCity;
                dineroContact.ZipCode = contactCompanyOrPerson.ForeignZip;
            }

            dineroContact.ExternalReference = "IsNyxiumCustomer";
            dineroContact.VatNumber = contactCompanyOrPerson.CVRNumber;
            dineroContact.CountryKey = contactCompanyOrPerson.CountryCode;
            dineroContact.Phone = contactCompanyOrPerson.PhoneNumber;
            dineroContact.Webpage = contactCompanyOrPerson.HomePage;
            dineroContact.IsMember = false;
            dineroContact.UseCvr = false;


            return dineroContact;
        }

        public ADDAndUpdateDineroAPIcontact MapWedigitVendorToDineroContact(Vendor vendor, ADDAndUpdateDineroAPIcontact dineroContact)
        {


            dineroContact.IsPerson = false;
           
            dineroContact.Name = vendor.Name;
            dineroContact.Street = vendor.Street;

            if (vendor.CountryCode.Equals("DK"))
            {
                dineroContact.City = vendor.City;
                dineroContact.ZipCode = vendor.Zip;
            }
            else
            {
                dineroContact.City = vendor.ForeignCity;
                dineroContact.ZipCode = vendor.ForeignZip;
            }

            dineroContact.ExternalReference = "IsNyxiumVendor";
            dineroContact.VatNumber = vendor.CVRNumber;
            dineroContact.CountryKey = vendor.CountryCode;
            dineroContact.Phone = vendor.PhoneNumber;
            dineroContact.Webpage = vendor.HomePage;
            dineroContact.IsMember = false;
            dineroContact.UseCvr = false;


            return dineroContact;
        }

        public ADDAndUpdateDineroAPIcontact copyDineroContactFromreadToAddUpdate(READDineroAPIcontact readDineroContact)
        {
            ADDAndUpdateDineroAPIcontact addOrUpdateContact = new ADDAndUpdateDineroAPIcontact();

            
            addOrUpdateContact.ExternalReference = readDineroContact.ExternalReference;
            addOrUpdateContact.Name = readDineroContact.Name;
            addOrUpdateContact.Street = readDineroContact.Street;
            addOrUpdateContact.ZipCode = readDineroContact.ZipCode;
            addOrUpdateContact.City = readDineroContact.City;
            addOrUpdateContact.City = readDineroContact.City;
            addOrUpdateContact.CountryKey = readDineroContact.CountryKey;
            addOrUpdateContact.Phone = readDineroContact.Phone;
            addOrUpdateContact.Email = readDineroContact.Email;
            addOrUpdateContact.Webpage = readDineroContact.Webpage;
            addOrUpdateContact.AttPerson = readDineroContact.AttPerson;
            addOrUpdateContact.VatNumber = readDineroContact.VatNumber;
            addOrUpdateContact.EanNumber = readDineroContact.EanNumber;
            addOrUpdateContact.PaymentConditionType = readDineroContact.PaymentConditionType;
            addOrUpdateContact.PaymentConditionNumberOfDays = Int32.Parse(readDineroContact.PaymentConditionNumberOfDays);
            addOrUpdateContact.IsPerson = readDineroContact.IsPerson;
            addOrUpdateContact.IsMember = readDineroContact.IsMember;
            addOrUpdateContact.MemberNumber = readDineroContact.MemberNumber;
            addOrUpdateContact.UseCvr = readDineroContact.UseCvr;
            addOrUpdateContact.CompanyTypeKey = readDineroContact.CompanyTypeKey;
            return (addOrUpdateContact);

        }



     


        public Company MapUpdateDineroContactToCustomer(READDineroAPIcontact contactToAdd, Company wedigitCompany)
        {
            wedigitCompany.CVRNumber = contactToAdd.VatNumber;

            wedigitCompany.Name = contactToAdd.Name;
            wedigitCompany.IsPerson = contactToAdd.IsPerson;
            wedigitCompany.Street = contactToAdd.Street;
            wedigitCompany.CountryCode = contactToAdd.CountryKey;

            if (contactToAdd.CountryKey.Equals("DK"))
            {
                wedigitCompany.City = contactToAdd.City;
                wedigitCompany.Zip = contactToAdd.ZipCode;
            }
            else
            {
                wedigitCompany.ForeignCity = contactToAdd.City;
                wedigitCompany.ForeignZip = contactToAdd.ZipCode;
            }

          
          
            wedigitCompany.PhoneNumber = contactToAdd.Phone;
            wedigitCompany.HomePage = contactToAdd.Webpage;
           

            wedigitCompany.DineroGuiD = new Guid(contactToAdd.ContactGuid);
            wedigitCompany.LastEditedDate = DateTime.Now;


            return wedigitCompany;
        }

        public Vendor MapUpdateDineroContactToVendor(READDineroAPIcontact contactToAdd, Vendor wedigitVendor)
        {
            wedigitVendor.CVRNumber = contactToAdd.VatNumber;

            wedigitVendor.Name = contactToAdd.Name;

            wedigitVendor.Street = contactToAdd.Street;
            wedigitVendor.CountryCode = contactToAdd.CountryKey;

            if (contactToAdd.CountryKey.Equals("DK"))
            {
                wedigitVendor.City = contactToAdd.City;
                wedigitVendor.Zip = contactToAdd.ZipCode;
            }
            else
            {
                wedigitVendor.ForeignCity = contactToAdd.City;
                wedigitVendor.ForeignZip = contactToAdd.ZipCode;
            }



            wedigitVendor.PhoneNumber = contactToAdd.Phone;
            wedigitVendor.HomePage = contactToAdd.Webpage;


            wedigitVendor.DineroGuiD = new Guid(contactToAdd.ContactGuid);
            wedigitVendor.LastEditedDate = DateTime.Now;


            return wedigitVendor;
        }

        public Contact MapUpdateDineroContactToNyxiumContact(READDineroAPIcontact contactToAdd, Contact nyxiumContact)
        {
            nyxiumContact.CVRNumber = contactToAdd.VatNumber;

            nyxiumContact.Name = contactToAdd.Name;

            nyxiumContact.Street = contactToAdd.Street;
            nyxiumContact.CountryCode = contactToAdd.CountryKey;

            if (contactToAdd.CountryKey.Equals("DK"))
            {
                nyxiumContact.City = contactToAdd.City;
                nyxiumContact.Zip = contactToAdd.ZipCode;
            }
            else
            {
                nyxiumContact.ForeignCity = contactToAdd.City;
                nyxiumContact.ForeignZip = contactToAdd.ZipCode;
            }



            nyxiumContact.PhoneNumber = contactToAdd.Phone;
            nyxiumContact.HomePage = contactToAdd.Webpage;


            nyxiumContact.DineroGuiD = new Guid(contactToAdd.ContactGuid);
            nyxiumContact.LastEditedDate = DateTime.Now;


            return nyxiumContact;
        }


        public void CopyCustomersFromDinero(CompanyAccount companyAccount, ICompanyRepository _companyRepository)
        {
            DateTimeFormatInfo SweedishTimeformat = CultureInfo.GetCultureInfo("sv-SE").DateTimeFormat;
          
            Int32 page;
            Int32 pageSize;


            DateTime LastupdatedDateTime = new DateTime(1980, 01, 01);

            string dateStr = LastupdatedDateTime.ToUniversalTime().ToString(SweedishTimeformat.ShortDatePattern);
            string timeStr = LastupdatedDateTime.ToUniversalTime().ToLongTimeString();
            string LastupdatedToDineroAPIDateTime = dateStr + "T" + timeStr + "Z";

            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();

            if (dineroAPIConnect.connectToDinero(companyAccount) != null)
            {
                DineroContacts dineroContactsToNyxium = new DineroContacts(dineroAPIConnect);

                page = -1;
                pageSize = 500;
                READDineroAPIcollection readDineroAPIcollection;
                do
                {
                    page++;
                    readDineroAPIcollection = dineroContactsToNyxium.getContactsFromDinero(LastupdatedToDineroAPIDateTime, page, pageSize);
                    foreach (var dineroContact in readDineroAPIcollection.Collection)
                    {
                        updateOrAddCustomerContactInNyxium(dineroContact, dineroContactsToNyxium, companyAccount, _companyRepository);
                    }

                } while (readDineroAPIcollection.Pagination.Result == pageSize);

            }
        }



        public void CopyCustomersToDinero(CompanyAccount companyAccount, ICompanyRepository _companyRepository)
        {
            List<Company> companies = _companyRepository.GetAllCompanies().Where(company => company.companyAccountId == companyAccount.companyAccountId).ToList();

            foreach (var company in companies)
            {
                string status = AddCustomerContactToDineroAsync(company).ToString();
                if (!status.Equals("NotOK"))
                {
                    Guid DineroGuidId = Guid.Parse(status);
                    company.DineroGuiD = DineroGuidId;
                    _companyRepository.Update(company);
                }
            }
        }

        public void updateOrAddCustomerContactInNyxium(READDineroAPIcontact dineroContact, DineroContacts dineroContactsToNyxium, CompanyAccount companyAccount, ICompanyRepository _companyRepository)
        {
            if (!string.IsNullOrEmpty(dineroContact.ContactGuid))
            {
                Guid dineroGuid = Guid.Parse(dineroContact.ContactGuid);
                List<Company> companyList = _companyRepository.GetAllCompanies().Where(tmpCompany => tmpCompany.DineroGuiD == dineroGuid).ToList();
                if (companyList.Count == 1)
                {
                    Company company = companyList.First();
                    company = dineroContactsToNyxium.MapUpdateDineroContactToCustomer(dineroContact, company);

                    company.LastEditedDate = DateTime.Now;
                    _companyRepository.Update(company);
                }
                else
                {
                    if (companyList.Count == 0)
                    {
                        Company company = new Company();

                        Company newCompany = dineroContactsToNyxium.MapUpdateDineroContactToCustomer(dineroContact, company);
                        newCompany.LastEditedDate = DateTime.Now;
                        newCompany.CreatedDate = DateTime.Now;
                        newCompany.companyAccountId = companyAccount.companyAccountId;
                        _companyRepository.Add(newCompany);
                    }
                }
            }

        }

        public void updateOrAddVendorInNyxium(READDineroAPIcontact dineroContact, DineroContacts dineroContactsToNyxium, CompanyAccount companyAccount, IVendorRepository _vendorRepository)
        {
            if (!string.IsNullOrEmpty(dineroContact.ContactGuid))
            {
                Guid dineroGuid = Guid.Parse(dineroContact.ContactGuid);
                List<Vendor> vendorList = _vendorRepository.GetAllVendors().Where(tmpVendor => tmpVendor.DineroGuiD == dineroGuid).ToList();
                if (vendorList.Count == 1)
                {
                    Vendor vendor = vendorList.First();
                    vendor = dineroContactsToNyxium.MapUpdateDineroContactToVendor(dineroContact, vendor);

                    vendor.LastEditedDate = DateTime.Now;
                    _vendorRepository.Update(vendor);
                }
                else
                {
                    if (vendorList.Count == 0)
                    {
                        Vendor vendor = new Vendor();

                        Vendor newVendor = dineroContactsToNyxium.MapUpdateDineroContactToVendor(dineroContact, vendor);
                        newVendor.LastEditedDate = DateTime.Now;
                        newVendor.CreatedDate = DateTime.Now;
                        newVendor.companyAccountId = companyAccount.companyAccountId;
                        _vendorRepository.Add(newVendor);
                    }
                }
            }

        }

        public void updateOrAddContactInNyxium(READDineroAPIcontact dineroContact, DineroContacts dineroContactsToNyxium, CompanyAccount companyAccount, IContactRepository _contactRepository)
        {
            if (!string.IsNullOrEmpty(dineroContact.ContactGuid))
            {
                Guid dineroGuid = Guid.Parse(dineroContact.ContactGuid);
                List<Contact> contactList = _contactRepository.GetAllContacts().Where(tmpContact => tmpContact.DineroGuiD == dineroGuid).ToList();
                if (contactList.Count == 1)
                {
                    Contact contact = contactList.First();
                    contact = dineroContactsToNyxium.MapUpdateDineroContactToNyxiumContact(dineroContact, contact);

                    contact.LastEditedDate = DateTime.Now;
                    _contactRepository.Update(contact);
                }
                else
                {
                    if (contactList.Count == 0)
                    {
                        Contact contact =  new Contact();                      
                        Contact newContact = dineroContactsToNyxium.MapUpdateDineroContactToNyxiumContact(dineroContact, contact);
                        newContact.LastEditedDate = DateTime.Now;
                        newContact.CreatedDate = DateTime.Now;
                        newContact.companyAccountId = companyAccount.companyAccountId;
                        _contactRepository.Add(newContact);
                    }
                }
            }

        }

        public void deleteCustomer(string dineroContactGuid, ICompanyRepository _companyRepository)
        {
            if (!string.IsNullOrEmpty(dineroContactGuid))
            {
                Guid dineroGuid = Guid.Parse(dineroContactGuid);
                List<Company> companyList = _companyRepository.GetAllCompanies().Where(tmpCompany => tmpCompany.DineroGuiD == dineroGuid).ToList();
                if (companyList.Count == 1)
                {
                    Company company = companyList.First();
                    _companyRepository.Delete(company.Id);
                }
            }
        }

        public void deleteVendor(string dineroContactGuid, IVendorRepository _vendorRepository)
        {
            if (!string.IsNullOrEmpty(dineroContactGuid))
            {
                Guid dineroGuid = Guid.Parse(dineroContactGuid);
                List<Vendor> vendorList = _vendorRepository.GetAllVendors().Where(tmpVendor => tmpVendor.DineroGuiD == dineroGuid).ToList();
                if (vendorList.Count == 1)
                {
                    Vendor vendor = vendorList.First();
                    _vendorRepository.Delete(vendor.Id);
                }
            }
        }

        public void deleteContact(string dineroContactGuid, IContactRepository _contactRepository)
        {
            if (!string.IsNullOrEmpty(dineroContactGuid))
            {
                Guid dineroGuid = Guid.Parse(dineroContactGuid);
                List<Contact> contactList = _contactRepository.GetAllContacts().Where(tmpContact => tmpContact.DineroGuiD == dineroGuid).ToList();
                if (contactList.Count == 1)
                {
                    Contact contact = contactList.First();
                    _contactRepository.Delete(contact.Id);
                }
            }
        }

    }


    public class READDineroAPIcontact
    {
        public string ContactGuid { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string DeletedAt { get; set; }
        public bool IsDebitor { get; set; }
        public bool IsCreditor { get; set; }
        public string ExternalReference { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }


        public string ZipCode { get; set; }
        public string City { get; set; }
        public string CountryKey { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Webpage { get; set; }
        public string AttPerson { get; set; }
        public string VatNumber { get; set; }
        public string EanNumber { get; set; }
        public string PaymentConditionType { get; set; }
        public string PaymentConditionNumberOfDays { get; set; }
        public bool IsPerson { get; set; }
        public bool IsMember { get; set; }
        public string MemberNumber { get; set; }
        public bool UseCvr { get; set; }
        public string CompanyTypeKey { get; set; }
    }

    public class READDineroAPIcollection
    {
        public READDineroAPIcontact[] Collection { get; set; }
        public DineroAPIPagination Pagination { get; set; }
    }
}

