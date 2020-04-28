using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class UserRoleViewModel
       
    {
        public UserRoleViewModel()
        {
            this.users = new List<IdentityUser>();
            this.IsSelected = new List<bool>();
        }
        public IdentityRole role { get; set; }
        public List<IdentityUser> users { get; set; }
      
        public List<bool> IsSelected { get; set; }
    }
}
