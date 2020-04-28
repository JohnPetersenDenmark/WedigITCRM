using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class ContactPersonEditViewModel
    {
        public IEnumerable<PostalCode> getSelectableZips;

        public ContactPersonEditViewModel()
        {

        }

        public ContactPerson contactPerson { get; set; }

        public List<Activity> Activities { get; set; }

        public Company company { get; set; }
        public string selectedZipId { get; set; }

        public string ContactPersonEditViewFormAction { get; set; }
        
    }
}
