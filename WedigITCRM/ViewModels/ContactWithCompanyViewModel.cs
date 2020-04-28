using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class ContactWithCompanyViewModel
    {
        public ContactPerson contactPerson { get; set; }

        public string CompanyName { get; set; }
        public string CompanyStreet { get; set; }
        public string CompanyZip { get; set; }

        public string CompanyCity { get; set; }
        public string CompanyPhone { get; set; }
    }
}
