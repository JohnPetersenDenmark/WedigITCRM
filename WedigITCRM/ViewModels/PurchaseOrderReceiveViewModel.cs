using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.Controllers;

namespace WedigITCRM.ViewModels
{
    public class PurchaseOrderReceiveViewModel
    {
        public string PurchaseOrderId { get; set; }
        public string PurchaseOrderDocumentNumber { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }      
        public string VendorReference { get; set; }
        public string VendorPaymentConditionId { get; set; }
        public string VendorPaymentCondition { get; set; }       
        public string Note { get; set; }
        public string OurWantedDeliveryDate { get; set; }
        public string OurOrderingDate { get; set; }
        public string OurReference { get; set; }

        public string AttachedFilesNameAndPath { get; set; }
        public string AttachedmentIds { get; set; }
        public string FileNamesOnly { get; set; }
        public string IconsFilePathAndName { get; set; }
        public List<PurchaseOrderLineReceiveModel> OrderLinesToReceive { get; set; }

        
    }
}
