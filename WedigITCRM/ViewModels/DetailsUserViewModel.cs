using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class DetailsUserViewModel
    {
      

        public IdentityUser user { get; set; }


        public List<IdentityRole> Roles { get; set; }

        public string userName { get; set; }

    }
}
