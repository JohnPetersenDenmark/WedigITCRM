using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public class BookingResource
    {
        public int Id { get; set; }
        public int UserId { get; set; }
       
        public string JobDescription { get; set; }

        public string JobServiceTypes { get; set; }

        public string CalendarEventsColor { get; set; }
        public string EmailForCalendar { get; set; }

        public int companyAccountId { get; set; }
             
        public DateTime LastEditedDate { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
