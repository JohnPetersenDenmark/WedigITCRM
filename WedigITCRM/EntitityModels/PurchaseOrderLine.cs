using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.EntitityModels
{
    public class PurchaseOrderLine
    {
        public int Id { get; set; }
        public string OurItemNumber { get; set; }
        public string OurUnit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal OurUnitPrice { get; set; }
        public int VendorId { get; set; }
        public string VendorItemNumber { get; set; }
        public string VendorUnit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal VendorUnitPrice { get; set; }
        public int PurchaseOrderId { get; set; }
        public int companyAccountId { get; set; }

       
        public DateTime ReceivedDate { get; set; }
        public DateTime LastEditedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
