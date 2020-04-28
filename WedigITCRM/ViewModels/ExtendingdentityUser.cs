using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class ExtendingdentityUser
    {
        public IdentityUser User { get; set; }
        public string userName { get; set; }
    }
}
