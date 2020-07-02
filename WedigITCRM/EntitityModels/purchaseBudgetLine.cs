using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.EntitityModels
{
    public class purchaseBudgetLine
    {
        public int Id { get; set; }
        public int StockItemId { get; set; }
        public string OurItemNumber { get; set; }
        public string OurUnit { get; set; }
        public string OurLocation { get; set; }
        public string OurItemName { get; set; }
        public int PurchaseBudgetId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal OurUnitCostPrice { get; set; }
        public Decimal OurUnitSalesPrice { get; set; }
        public int VendorId { get; set; }

        public DateTime LastEditedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
