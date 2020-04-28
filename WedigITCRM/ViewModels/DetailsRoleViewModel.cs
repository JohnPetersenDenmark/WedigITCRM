using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class DetailsRoleViewModel
    {
        public DetailsRoleViewModel()
        {

        }
        public IdentityRole role { get; set; }

        public List<IdentityUser> userswithTheRole { get; set; }
    }
}
