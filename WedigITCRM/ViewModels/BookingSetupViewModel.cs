using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class BookingSetupViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Mandag")]
        public string MondayOfficeStartTime { get; set; }
        [Display(Name = "Tirsdag")]
        public string TuesdayOfficeStartTime { get; set; }
        [Display(Name = "Onsdag")]
        public string WednesdayOfficeStartTime { get; set; }
        [Display(Name = "Torsdag")]
        public string ThursdayOfficeStartTime { get; set; }
        [Display(Name = "Fredag")]
        public string FridayOfficeStartTime { get; set; }
        [Display(Name = "Lørdag")]
        public string SaturdayOfficeStartTime { get; set; }
        [Display(Name = "Søndag")]
        public string SundayOfficeStartTime { get; set; }

        [Display(Name = "Mandag")]
        public string MondayOfficeEndTime { get; set; }
        [Display(Name = "Tirsdag")]
        public string TuesdayOfficeEndTime { get; set; }
        [Display(Name = "Onsdag")]
        public string WednesdayOfficeEndTime { get; set; }
        [Display(Name = "Torsdag")]
        public string ThursdayOfficeEndTime { get; set; }
        [Display(Name = "Fredag")]
        public string FridayOfficeEndTime { get; set; }
        [Display(Name = "Lørdag")]
        public string SaturdayOfficeEndTime { get; set; }
        [Display(Name = "Søndag")]
        public string SundayOfficeEndTime { get; set; }

        [Display(Name = "Booking API-nøgle")]
        public string BookingAPIkey { get; set; }

        [Display(Name = "Mindste booking tidsperiode (Angiv i minutter)")]
        public int BookingFreeTimeInterval { get; set; }
    }
}
