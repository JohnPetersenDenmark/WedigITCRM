using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class ChangePasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public String Email { get; set; }
    }
}
