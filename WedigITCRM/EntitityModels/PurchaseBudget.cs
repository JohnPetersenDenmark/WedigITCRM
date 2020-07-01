using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.EntitityModels
{
    public class PurchaseBudget
    {
        public DateTime StartDateOfPeriod { get; set; }
        public DateTime EndDateOfPeriod { get; set; }

     
        public string Interval { get; set; }

        public DateTime LastEditedDate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
