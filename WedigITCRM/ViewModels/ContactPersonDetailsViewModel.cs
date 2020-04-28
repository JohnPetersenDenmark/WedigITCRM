using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class ContactPersonDetailsViewModel
    {
        public ContactPerson contactPerson { get; set; }
        public string Pagetitle { get; set; }

        public Company company { get; set; }
        public List<Activity> Activities { get; set; }
    }
}
