using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public class StockItemCategory2
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Category1Id { get; set; }
        public int companyAccountId { get; set; }
    }
}
