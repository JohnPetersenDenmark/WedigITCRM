using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.DineroAPI;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.Utilities
{
    public class NyxiumCustomerHandling
    {
        public string createNyxiumCustomerInDinero(string NyxiumDineroAPIOrganizationKey, CompanyAccount nyxiumCustomerCompanyAccount)
        {
            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
            if (dineroAPIConnect.connectToDinero(NyxiumDineroAPIOrganizationKey) != null)
            {
                DineroContacts dineroContacts = new DineroContacts(dineroAPIConnect);

                Company company = new Company();
                company.Name = nyxiumCustomerCompanyAccount.CompanyName;
                company.CVRNumber = nyxiumCustomerCompanyAccount.CompanyCVRNumber;
                company.Street = nyxiumCustomerCompanyAccount.CompanyStreet;
                company.Zip = nyxiumCustomerCompanyAccount.CompanyZip;
                company.City = nyxiumCustomerCompanyAccount.CompanyCity;
                company.CountryCode = "DK";
                company.CurrencyCode = "DKK";


                string status = dineroContacts.AddCustomerContactToDineroAsync(company).ToString();
                if (!status.Equals("NotOK"))
                {
                    //Guid DineroGuidId = Guid.Parse(status);   
                    return status;
                }
            }
            return null;
        }

        public void createTradeOfferInDinero(Guid dineroCustomerId, NyxiumSetup nyxiumSetup, string typeOfSubscription)
        {

        }
    }
}
