using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class EnterNewPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Kodeord")]
        public String Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Gentag kodeord")]
        [Compare("Password", ErrorMessage = "Kodeord og Gentaget kodeord er ikke ens!")]
        public String ConfirmPassword { get; set; }

        public string email { get; set; }
        public string  token { get; set; }
    }
}
