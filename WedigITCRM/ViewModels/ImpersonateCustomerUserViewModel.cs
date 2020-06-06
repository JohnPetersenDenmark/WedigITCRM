using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewModels
{
    public class ImpersonateCustomerUserViewModel
    {
        public string CompanyAccountName { get; set; }
        public string companyAccountId { get; set; }

        public string UserToImpersonateName{ get; set; }

        //[Required(ErrorMessage = "Der skal angives en bruger")]
       // [Display(Name = "Bruger")]
        public string UserToImpersonateId { get; set; }

    }
}

