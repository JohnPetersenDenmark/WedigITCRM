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
using WedigITCRM.Models;

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
            try
            {
                String JsonString = client.DownloadString(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "contacts" + "/" + dineroIdStr);
                return (JsonConvert.DeserializeObject<READDineroAPIcontact>(JsonString));
            }
            catch (Exception ex)
            {
                return (null);
            }
        }



        public string AddContactToDineroAsync(Company contactCompanyOrPerson)
        {
            ADDAndUpdateDineroAPIcontact dineroContact = new ADDAndUpdateDineroAPIcontact();
            ADDAndUpdateDineroAPIcontact contactToAdd = MapWedigitCustomerToDineroContact(contactCompanyOrPerson, dineroContact);


            HttpClient client = new HttpClient();

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

        public string UpdateContactInDinero(Company contactCompanyOrPerson, Guid dineroContactGuid)
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


            HttpClient client = new HttpClient();

            var content = new StringContent(JsonConvert.SerializeObject(contactToUpdate), System.Text.Encoding.UTF8, "application/json");
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
            dineroContact.City = contactCompanyOrPerson.City;
            dineroContact.ZipCode = contactCompanyOrPerson.Zip;
            dineroContact.VatNumber = contactCompanyOrPerson.CVRNumber.ToString();
            
            dineroContact.CountryKey = contactCompanyOrPerson.CountryCode;
            dineroContact.CountryKey = contactCompanyOrPerson.CountryCode;
            dineroContact.Phone = contactCompanyOrPerson.PhoneNumber;
            dineroContact.Webpage = contactCompanyOrPerson.HomePage;
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
            addOrUpdateContact.PaymentConditionNumberOfDays = readDineroContact.PaymentConditionNumberOfDays;
            addOrUpdateContact.IsPerson = readDineroContact.IsPerson;
            addOrUpdateContact.IsMember = readDineroContact.IsMember;
            addOrUpdateContact.MemberNumber = readDineroContact.MemberNumber;
            addOrUpdateContact.UseCvr = readDineroContact.UseCvr;
            addOrUpdateContact.CompanyTypeKey = readDineroContact.CompanyTypeKey;
            return (addOrUpdateContact);

        }



        public Company MapNewDineroContactToCustomer(READDineroAPIcontact contactToAdd)
        {
            Company wedigitCompany = new Company();

            if (contactToAdd.VatNumber == null || contactToAdd.VatNumber == "")
            {
                wedigitCompany.CVRNumber = 0;
            }
            else
            {
                wedigitCompany.CVRNumber = int.Parse(contactToAdd.VatNumber);
            }

            wedigitCompany.Name = contactToAdd.Name;
            wedigitCompany.Street = contactToAdd.Street;
            wedigitCompany.City = contactToAdd.City;
            wedigitCompany.Zip = contactToAdd.ZipCode;
            wedigitCompany.CountryCode = contactToAdd.CountryKey;
          
            wedigitCompany.PhoneNumber = contactToAdd.Phone;
            wedigitCompany.HomePage = contactToAdd.Webpage;
            wedigitCompany.DineroGuiD = new Guid(contactToAdd.ContactGuid);
            wedigitCompany.CreatedDate = DateTime.Now;
            wedigitCompany.LastEditedDate = DateTime.Now;


            return wedigitCompany;
        }



        public Company MapUpdateDineroContactToCustomer(READDineroAPIcontact contactToAdd, Company wedigitCompany)
        {
            if (contactToAdd.VatNumber == null || contactToAdd.VatNumber == "")
            {
                wedigitCompany.CVRNumber = 0;
            }
            else
            {
                wedigitCompany.CVRNumber = int.Parse(contactToAdd.VatNumber);
            }

            wedigitCompany.Name = contactToAdd.Name;
            wedigitCompany.IsPerson = contactToAdd.IsPerson;
            wedigitCompany.Street = contactToAdd.Street;
            wedigitCompany.City = contactToAdd.City;
            wedigitCompany.Zip = contactToAdd.ZipCode;
            wedigitCompany.CountryCode = contactToAdd.CountryKey;
            wedigitCompany.PhoneNumber = contactToAdd.Phone;
            wedigitCompany.HomePage = contactToAdd.Webpage;
            if (! string.IsNullOrEmpty(contactToAdd.VatNumber))
            {
                wedigitCompany.CVRNumber = Int32.Parse(contactToAdd.VatNumber);
            }
            else
            {
                wedigitCompany.CVRNumber = 0;
            }
           
            wedigitCompany.DineroGuiD = new Guid(contactToAdd.ContactGuid);
            wedigitCompany.LastEditedDate = DateTime.Now;


            return wedigitCompany;
        }


        public void CopyCustomersFromDinero(CompanyAccount companyAccount, ICompanyRepository _companyRepository)
        {
            DateTimeFormatInfo SweedishTimeformat = CultureInfo.GetCultureInfo("sv-SE").DateTimeFormat;
            int testInteger;
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
                        updateOrAddContactInNyxium(dineroContact, dineroContactsToNyxium, companyAccount, _companyRepository);
                    }

                } while (readDineroAPIcollection.Pagination.Result == pageSize);

            }
        }

     

        public void CopyCustomersToDinero(CompanyAccount companyAccount, ICompanyRepository _companyRepository)
        {
            List<Company> companies = _companyRepository.GetAllCompanies().Where(company => company.companyAccountId == companyAccount.companyAccountId).ToList();

            foreach (var company in companies)
            {
                string status = AddContactToDineroAsync(company).ToString();
                if (!status.Equals("NotOK"))
                {
                    Guid DineroGuidId = Guid.Parse(status);
                    company.DineroGuiD = DineroGuidId;
                    _companyRepository.Update(company);
                }
            }
        }

        public void updateOrAddContactInNyxium(READDineroAPIcontact dineroContact, DineroContacts dineroContactsToNyxium, CompanyAccount companyAccount, ICompanyRepository _companyRepository)
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
        public int PaymentConditionNumberOfDays { get; set; }
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

