using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace WedigITCRM.ViewControllers
{
    public class ListUsersViewModel
    {
        public IPagedList<ExtendingdentityUser> users  { get; set; }

        public string searchString { get; set; }
        public string searchBy { get; set; }
        public string sortColumn { get; set; }

        public string sortDirection { get; set; }
    }
}
