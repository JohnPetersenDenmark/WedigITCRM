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
       
        
        public DateTime SendDate { get; set; }
        public string  Note { get; set; }        
        public  PurchaseOrderReceivedStatus ReceivedStatus { get; set; }
        public DateTime WantedDeliveryDate { get; set; }
        public DateTime OurOrderingDate { get; set; }
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
        public string VendorEmail { get; set; }
        public string VendorPaymentConditionsId { get; set; }
        public string VendorPaymentConditions { get; set; }
        public string VendorDeliveryConditions { get; set; }
        public string VendorDeliveryConditionId { get; set; }
        public int companyAccountId { get; set; }

        public string AttachedFilesNameAndPath { get; set; }
        public string AttachedmentIds { get; set; }
        public string FileNamesOnly { get; set; }
        public string IconsFilePathAndName { get; set; }
    }
}
