using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public class LicenseType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal SalesPriceMonthlyPayment { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public Decimal SalesPriceAnnualPayment { get; set; }

    }
}
