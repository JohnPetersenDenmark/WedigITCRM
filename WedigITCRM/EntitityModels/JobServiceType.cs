using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public class JobServiceType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Servicetypen skal udfyldes")]       
        [Display(Name = "Servicetype")]
        public string Name { get; set; }
        public string Desciption { get; set; }

        public string BookingServicesIds { get; set; }

        public int companyAccountId { get; set; }
    }
}
