using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class RegisterCompanyAccountModel
    {
        [Required (ErrorMessage = "Email skal udfyldes")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Email skal udfyldes")]
        [Display(Name = "Email")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Kodeord skal udfyldes")]
        [DataType(DataType.Password)]
        [Display(Name = "Vælg kodeord")]
        public String Password { get; set; }

        [Required(ErrorMessage = "Gentaget kodeord skal udfyldes")]
        [DataType(DataType.Password)]
        [Display(Name = "Gentag kodeord")]
        [Compare("Password", ErrorMessage = "Kodeord og Gentaget kodeord er ikke ens!")]
        public String ConfirmPassword { get; set; }

        
        [Display(Name = "Firmanavn")]
        [Required(ErrorMessage = "Firmanavn skal udfyldes")]
        public String CompanyName { get; set; }

        [Display(Name = "CVR")]
        [Required(ErrorMessage = "CVR skal udfyldes")]
        public String CVRNumber { get; set; }

        [Display(Name = "Adresse")]
        [Required(ErrorMessage = "Adresse skal udfyldes")]
        public String CompanyStreet { get; set; }

        [Display(Name = "Postnummer")]
        [Required(ErrorMessage = "Postnummer skal udfyldes")]
        public String CompanyZip { get; set; }

        [Display(Name = "By")]
        [Required(ErrorMessage = "By skal udfyldes")]
        public String CompanyCity { get; set; }

        [Required(ErrorMessage = "Navn skal udfyldes")]
        [Display(Name = "Navn")]
        public string UserName { get; set; }

        public bool companyAccountEmailSent { get; set; }
        public string companyAccountEmailSentMessage { get; set; }
        public string ReturnUrl { get; set; }

       

       
    }
}
