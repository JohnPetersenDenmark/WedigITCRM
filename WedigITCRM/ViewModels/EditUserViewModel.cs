using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class EditUserViewModel
    {
      

        public IdentityUser user { get; set; }


        public IList<IdentityRole> Roles { get; set; }

        public string userName { get; set; }
    }
}