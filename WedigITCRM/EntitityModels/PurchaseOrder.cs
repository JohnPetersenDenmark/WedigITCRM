using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.Controllers;

namespace WedigITCRM.EntitityModels
{
    public class PurchaseOrder
    {
        public int Id { get; set; }
        public string PurchaseOrderDocumentNumber { get; set; }
        public string OurReference { get; set; }
        public string VendorReference { get; set; }
        public string Currency { get; set; }
        public string ExchangeRate { get; set; }
        public string PaymentTerms { get; set; }
        public string DeliveryConditions { get; set; }
        public DateTime SendDate { get; set; }
        public string  Note { get; set; }        
        public  PurchaseOrderReceivedStatus ReceivedStatus { get; set; }
        public string WantedDeliveryDate { get; set; }
        public DateTime SendToVendorDate { get; set; }        
        public DateTime AllReceivedDate { get; set; }
        public DateTime LastEditedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public int  VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorStreet { get; set; }
        public string VendorCity { get; set; }
        public string VendorZip { get; set; }
        public string VendorCountryCode { get; set; }
        public string VendorCurrencyCode { get; set; }
        public string VendorPhoneNumber { get; set; }
        public string VendorHomePage { get; set; }

        public int companyAccountId { get; set; }
    }
}
