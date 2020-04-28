using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace WedigITCRM.ViewControllers
{
    public class HomeIndexViewModel
    {
        public IPagedList<Company> companies { get; set; }

        public string searchString { get; set; }
        public string searchBy { get; set; }
        public string sortColumn { get; set; }

        public string sortDirection { get; set; }


    }
}
