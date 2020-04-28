using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class ActivityEditViewModel
    {
        public Activity activity { get; set; }

        public Company company { get; set; }

        public ContactPerson contactPerson { get; set; }

        public Company contactPersonAttachedTocompany { get; set; }

        public string ActivityEditViewFormAction { get; set; }

    }
}
