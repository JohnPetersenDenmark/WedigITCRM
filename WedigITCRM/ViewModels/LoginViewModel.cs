using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email skal udfyldes")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email skal udfyldes")]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Kodeord skal udfyldes")]
        [DataType(DataType.Password)]
        [Display(Name = "Vælg kodeord")]
        public String Password { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        [Display(Name = "Husk mig")]
        public bool LoginRememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
