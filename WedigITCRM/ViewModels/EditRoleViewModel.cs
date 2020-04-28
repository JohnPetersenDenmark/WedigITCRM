using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            this.userswithTheRole = new List<IdentityUser>();
        }
        public IdentityRole role { get; set; }

        public List<IdentityUser> userswithTheRole { get; set; }
    }
}
