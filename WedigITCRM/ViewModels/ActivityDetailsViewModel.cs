using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class ActivityDetailsViewModel
    {
        public Activity activity { get; set; }
        public Company company { get; set; }
        public ContactPerson contactPerson { get; set; }

        public Company attachToContactPersonCompany { get; set; }
    }
}
