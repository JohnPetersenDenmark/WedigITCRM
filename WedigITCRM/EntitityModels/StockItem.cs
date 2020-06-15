using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public class StockItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }

        public string ItemNumber { get; set; }
        public string Unit { get; set; }
        public int NumberInStock { get; set; }

       public int ReorderNumberInStock { get; set; }
        public string Location { get; set; }

        public string Category { get; set; }
        public int VendorId { get; set; }
        
        public string VendorItemNumber { get; set; }
        public string VendorItemName { get; set; }
        public DateTime Expirationdate { get; set; }
        public DateTime InStockAgainDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal CostPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public Decimal SalesPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal StockValue { get; set; }

        public int companyAccountId { get; set; }

        public int category1Id { get; set; }
        public int category2Id { get; set; }
        public int category3Id { get; set; }
        public DateTime LastEditedDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public Guid DineroGuiD { get; set; }

    }
}
