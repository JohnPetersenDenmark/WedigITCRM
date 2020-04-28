using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public class BookingSetup
    {
        public int Id { get; set; }
        public DateTime MondayOfficeStartTime { get; set; }
        public DateTime TuesdayOfficeStartTime { get; set; }
        public DateTime WednesdayOfficeStartTime { get; set; }
        public DateTime ThursdayOfficeStartTime { get; set; }
        public DateTime FridayOfficeStartTime { get; set; }
        public DateTime SaturdayOfficeStartTime { get; set; }
        public DateTime SundayOfficeStartTime { get; set; }

        public DateTime MondayOfficeEndTime { get; set; }
        public DateTime TuesdayOfficeEndTime { get; set; }
        public DateTime WednesdayOfficeEndTime { get; set; }
        public DateTime ThursdayOfficeEndTime { get; set; }
        public DateTime FridayOfficeEndTime { get; set; }
        public DateTime SaturdayOfficeEndTime { get; set; }
        public DateTime SundayOfficeEndTime { get; set; }
        public string BookingAPIkey { get; set; }
        public int BookingFreeTimeInterval { get; set; }
        public int companyAccountId { get; set; }
    }
}
