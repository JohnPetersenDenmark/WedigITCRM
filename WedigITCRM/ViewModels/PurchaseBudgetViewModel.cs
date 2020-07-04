using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewModels
{
    public class PurchaseBudgetViewModel
    {

        public string PeriodFromDate { get; set; }
        public string PeriodToDate { get; set; }
        public string Period { get; set; }
        public List<SelectListItem> SelectPeriod { get; } = new List<SelectListItem>
        {
             new SelectListItem { Value = "0", Text = "Vælg"  },
             new SelectListItem { Value = "1", Text = "1 år" },
            new SelectListItem { Value = "2", Text = "½ år" },
              new SelectListItem { Value = "3", Text = "3 måneder" },
            new SelectListItem { Value = "4", Text = "1 måned" },
             new SelectListItem { Value = "5", Text = "1 uge" },
            new SelectListItem { Value = "6", Text = "Mindre end 1 uge" }

        };
    }
}
