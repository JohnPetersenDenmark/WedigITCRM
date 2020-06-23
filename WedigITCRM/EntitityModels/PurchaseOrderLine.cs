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
        public int StockItemId { get; set; }
        public string OurItemNumber { get; set; }
        public string OurUnit { get; set; }
        public string OurLocation { get; set; }
        public string OurItemName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal OurUnitCostPrice { get; set; }
        public Decimal OurUnitSalesPrice { get; set; }
        public int VendorId { get; set; }
        public string VendorItemNumber { get; set; }
        public string VendorItemName { get; set; }
        public string VendorUnit { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal VendorSalesUnitPrice { get; set; }
        public int PurchaseOrderId { get; set; }
        public int companyAccountId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal QuantityToOrder { get; set; }
        public Decimal QuantityReceivedUntillNow { get; set; }
        public DateTime ReceivedDate { get; set; }
        public DateTime LastEditedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
