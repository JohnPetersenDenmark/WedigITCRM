using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class ActivityViewModel
    {
        public Activity activity { get; set; }
        public ContactPerson contactPerson { get; set; }
        public Company company { get; set; }
    }
}
