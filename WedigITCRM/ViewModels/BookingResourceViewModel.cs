using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class BookingResourceViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Resursenavn skal udfyldes")]
        [Display(Name = "Resursenavn")]
        public string JobDescription { get; set; }

        [Required(ErrorMessage = "Email skal udfyldes")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string EmailForCalendar { get; set; }

        [Display(Name = "Servicetype")]
        public List<string> JobServiceTypes { get; set; }

        public string CalendarEventsColor { get; set; }

        public IEnumerable<JobServiceType> SelectionListServiceTypes { get; set; }

    }
}
