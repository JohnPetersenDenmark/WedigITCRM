using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class RegisterUserViewModel
    {
       
        [Required(ErrorMessage = "Email skal udfyldes")]
        [DataType(DataType.EmailAddress)]
        [Display( Name = "Email")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Kodeord skal udfyldes")]
        [DataType(DataType.Password)]
        [Display(Name = "Kodeord")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Gentaget kodeord skal udfyldes")]
        [DataType(DataType.Password)]
        [Display(Name = "Gentag kodeord")]
        [Compare("Password", ErrorMessage="Kodeord og Gentaget kodeord er ikke ens!")]
        public String ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Navn skal udfyldes")]
        [Display(Name = "Navn")]
        public string UserName { get; set; }
    }
}
