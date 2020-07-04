using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.EntitityModels
{
    public class PurchaseBudgetLine
    {
        public int Id { get; set; }
        public int StockItemId { get; set; }
        public int PurchaseBudgetId { get; set; }
        public string OurLocationId { get; set; }
        public string PeriodLineId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal QuantityToOrder { get; set; }
       
        public DateTime LastEditedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
