using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public class BookingService
    {
        public int id { get; set; }
        public string  Name { get; set; }
        public string Description { get; set; }

        public string ProductNumber { get; set; }
        public int durationInMinutes { get; set; }

        public bool IsBookable { get; set; }

        public int GapTimeBeforeInMinutes { get; set; }
        public int GapTimeAfterInMinutes { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public  Decimal SalesPrice { get; set; }
        public DateTime LastEditedDate { get; set; }

        public DateTime CreatedDate { get; set; }
        public int companyAccountId { get; set; }
        public Guid DineroGuiD { get; set; }
    }
}
