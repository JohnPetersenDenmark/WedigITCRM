using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public class CalendarEntry
    {
        public int id { get; set; }
       // public string caleventid { get; set; }
        public bool selectallday { get; set; }       
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }
        public string description { get; set; }

        public int repeatingId { get; set; }

        public int customerId { get; set; }

        public int CalendarEventResourceOwnerId { get; set; }

      
        public bool selectRepeat { get; set; }
        public DateTime startDateTimeRange { get; set; }
        public DateTime endDateTimeRange { get; set; }
        public string rangeWeekDays { get; set; }

        public bool IsFromResourceCalendar { get; set; }
        public int companyAccountId { get; set; }


    }
}
