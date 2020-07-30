using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.DineroAPI;
using WedigITCRM.EntitityModels;
using static WedigITCRM.DineroAPI.DineroInvoice;

namespace WedigITCRM.Utilities
{
    public class NyxiumCustomerHandling
    {
        public string createNyxiumCustomerInDinero(NyxiumSetup nyxiumSetup, CompanyAccount nyxiumCustomerCompanyAccount)
        {
            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
            if (dineroAPIConnect.connectToDinero(nyxiumSetup.DineroAPIOrganizationKey, nyxiumSetup.DineroAPIOrganization) != null)
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

        public string createInvoiceInDinero(string dineroCustomerId, NyxiumSetup nyxiumSetup, int typeOfSubscription)
        {
            string dineroInvoiceId = null;
            DateTimeFormatInfo SweedishTimeformat = CultureInfo.GetCultureInfo("sv-SE").DateTimeFormat;

            DateTime myNow = DateTime.Now;
           


            DineroAPIConnect dineroAPIConnect = new DineroAPIConnect();
            if (dineroAPIConnect.connectToDinero(nyxiumSetup.DineroAPIOrganizationKey, nyxiumSetup.DineroAPIOrganization) != null)
            {
                DineroInvoiceCreate dineroInvoiceCreate = new DineroInvoiceCreate();
                dineroInvoiceCreate.PaymentConditionNumberOfDays = nyxiumSetup.PaymentConditionNumberOfDays;
                dineroInvoiceCreate.PaymentConditionType = nyxiumSetup.PaymentConditionType;
                dineroInvoiceCreate.ContactGuid = dineroCustomerId;
                dineroInvoiceCreate.Currency = "DKK";
                dineroInvoiceCreate.ShowLinesInclVat = false;
                dineroInvoiceCreate.Language = "da-DK";
                dineroInvoiceCreate.Date = myNow.ToString(SweedishTimeformat.ShortDatePattern);

                DineroInvoiceProductLineCreate dineroInvoiceProductLine = new DineroInvoiceProductLineCreate();
               
                if (typeOfSubscription == 1)
                {
                    dineroInvoiceProductLine.ProductGuid = nyxiumSetup.NyxiumSubscription1DineroProductGuid;
                    dineroInvoiceProductLine.Quantity = nyxiumSetup.NyxiumSubscription1NumberOfMonths;
                }
                else
                {
                    dineroInvoiceProductLine.ProductGuid = nyxiumSetup.NyxiumSubscription2DineroProductGuid;
                    dineroInvoiceProductLine.Quantity = nyxiumSetup.NyxiumSubscription2NumberOfMonths;
                }

                dineroInvoiceProductLine.BaseAmountValue = nyxiumSetup.NyxiumSubscriptionPricePerMonth;
                dineroInvoiceProductLine.Unit = "month";
                dineroInvoiceProductLine.AccountNumber = 1000;
                dineroInvoiceProductLine.Discount = 0;
                dineroInvoiceProductLine.LineType = "Product";

                dineroInvoiceCreate.ProductLines.Add(dineroInvoiceProductLine);

                DineroInvoice dineroInvoice = new DineroInvoice(dineroAPIConnect);

                 dineroInvoiceId = dineroInvoice.CreateInvoiceInDinero(dineroInvoiceCreate);               
            }

            return (dineroInvoiceId);
        }
    }

    public class DineroInvoiceCreate
    {
        public DineroInvoiceCreate()
        {
            this.ProductLines = new List<DineroInvoiceProductLineCreate>();
        }

        public int PaymentConditionNumberOfDays { get; set; }
        public string PaymentConditionType { get; set; }
        public string ContactGuid { get; set; }
        public bool ShowLinesInclVat { get; set; }
        public string InvoiceTemplateId { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string ExternalReference { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
        [JsonProperty("ProductLines")]
        public List<DineroInvoiceProductLineCreate> ProductLines { get; set; }
    }

    public class DineroInvoiceProductLineCreate
    {
        public double BaseAmountValue { get; set; }
        public string ProductGuid { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public double Quantity { get; set; }
        public int AccountNumber { get; set; }
        public string Unit { get; set; }
        public int Discount { get; set; }
        public string LineType { get; set; }

    }
}
