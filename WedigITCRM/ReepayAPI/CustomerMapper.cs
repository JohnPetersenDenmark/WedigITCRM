using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ReepayAPI
{
    public class CustomerMapper
    {
        public CustomerModel MapFromNyxiumToReepay(CompanyAccount companyAccount)
        {
            CustomerModel reepayCustomer = new CustomerModel();

            reepayCustomer.Company = companyAccount.CompanyName;
            reepayCustomer.Address = companyAccount.CompanyStreet;
            reepayCustomer.City = companyAccount.CompanyCity;
            reepayCustomer.Vat = companyAccount.CompanyCVRNumber;
            reepayCustomer.PostalCode = companyAccount.CompanyZip;
            reepayCustomer.Handle = companyAccount.companyAccountId.ToString();
            reepayCustomer.Test = true;

            return reepayCustomer;
        }
    }
}
