using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class HomeDetailsViewModel
    {
        public Company Company { get; set; }
        public string Pagetitle { get; set; }
        public List<ContactPerson> ContactPersons { get; set; }

        public List<Activity> Activities { get; set; }
    }
}
