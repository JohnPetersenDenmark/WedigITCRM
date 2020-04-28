using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class JobServiceTypeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Servicetypen skal udfyldes")]
        [Display(Name = "Servicetype")]
        public string Name { get; set; }
        public string Desciption { get; set; }

        public List<string> BookingServicesIds { get; set; }

        public IEnumerable<BookingService> SelectionListBookingService { get; set; }

        public int companyAccountId { get; set; }
    }
}
