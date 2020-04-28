using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using WedigITCRM.DineroAPI;

namespace WedigITCRM.DineroAPI
{
    public class DineroInvoice
    {
        private DineroAPIConnect _dineroAPIConnect;
        public DineroInvoice(DineroAPIConnect dineroAPIConnect)
        {
            _dineroAPIConnect = dineroAPIConnect;
        }


        public READDineroAPIInvoicecollection getInvoicesFromDinero()
        {

            READDineroAPIInvoices dineroAPIInvoices = new READDineroAPIInvoices();
            Type type = dineroAPIInvoices.GetType();
          //  string fieldList = getFieldListFromClass(type);


            WebClient client = new WebClient();
            client.Headers.Add("Authorization", "Bearer " + _dineroAPIConnect._APItoken);
            String JsonString = client.DownloadString(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "invoices");

            return (JsonConvert.DeserializeObject<READDineroAPIInvoicecollection>(JsonString));
        }

        public READDineroAPIInvoiceProductLines getInvoiceLinesFromDinero(string invoiceGuid)
        {

 
            WebClient client = new WebClient();
            client.Headers.Add("Authorization", "Bearer " + _dineroAPIConnect._APItoken);
            String JsonString = client.DownloadString(_dineroAPIConnect.APIEndpoint + "/" + _dineroAPIConnect.APIversion + "/" + _dineroAPIConnect.APIOrganization + "/" + "invoices" + "/" + invoiceGuid);


            READDineroAPIInvoiceProductLines rEADDineroAPIInvoiceProductLines = JsonConvert.DeserializeObject<READDineroAPIInvoiceProductLines>(JsonString);
            return (rEADDineroAPIInvoiceProductLines);
        }

      


        public class READDineroAPIInvoicecollection
        {
            [JsonProperty("Collection")]
            public READDineroAPIInvoices[] Collection { get; set; }
            public DineroAPIPagination Pagination { get; set; }
        }
        public class READDineroAPIInvoices
        {
            public string Number { get; set; }
            public string Guid { get; set; }
            public string ExternalReference { get; set; }
            public string Date { get; set; }
            public string PaymentDate { get; set; }
            public string Description { get; set; }
            public string Status { get; set; }
            public string Type { get; set; }
            public string ContactName { get; set; }
            public string ContactGuid { get; set; }
            public double TotalInclVat { get; set; }
            public double TotalExclVat { get; set; }
            public double TotalInclVatInDkk { get; set; }
            public double TotalExclVatInDkk { get; set; }
            public string MailOutStatus { get; set; }
            public string Currency { get; set; }
            public string CreatedAt { get; set; }
            public string UpdatedAt { get; set; }
            public string DeletedAt { get; set; }

        }

        public class READDineroAPIInvoiceProductLines
        {
            public READDineroAPIInvoiceProductLines()
            {
                this.ProductLines = new List<DineroAPIInvoiceProductLine>();
            }
            public string PaymentDate { get; set; }
            public string PaymentStatus { get; set; }
            public int PaymentConditionNumberOfDays { get; set; }
            public string PaymentConditionType { get; set; }
            public string FikCode { get; set; }
            public int DepositAccountNumber { get; set; }
            public string MailOutStatus { get; set; }
            public string Status { get; set; }
            public string ContactGuid { get; set; }
            public string Guid { get; set; }
            public string TimeStamp { get; set; }
            public string CreatedAt { get; set; }
            public string UpdatedAt { get; set; }
            public string DeletedAt { get; set; }
            public int Number { get; set; }
            public string ContactName { get; set; }
            public bool ShowLinesInclVat { get; set; }
            public Decimal TotalExclVat { get; set; }
            public Decimal TotalVatableAmount { get; set; }
            public Decimal TotalInclVat { get; set; }

            public Decimal TotalNonVatableAmount { get; set; }
            public Decimal TotalVat { get; set; }

            [JsonProperty("ProductLines")]
            public List<DineroAPIInvoiceProductLine> ProductLines { get; set; }

    }


        public class DineroAPIInvoiceProductLine
        {
            public string ProductGuid { get; set; }
           
            public string AccountName { get; set; }
            public decimal baseamountvalue { get; set; }
            public decimal BaseAmountValueInclVat { get; set; }
            public decimal TotalAmount { get; set; }
            public decimal TotalAmountInclVat { get; set; }
            public decimal Discount { get; set; }
            public decimal Quantity { get; set; }
            public string Description { get; set; }
            public string Comments { get; set; }
            public string Unit { get; set; }
            public string LineType { get; set; }
            public Int32 AccountNumber { get; set; }

        }

            private string getFieldListFromClass(Type type)
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
    }

   
}
