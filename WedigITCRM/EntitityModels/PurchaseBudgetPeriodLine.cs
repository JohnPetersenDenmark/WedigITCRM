using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.EntitityModels
{
    public class PurchaseBudgetPeriodLine
    {
        public int Id { get; set; }
        public int PurchaseBudgetId { get; set; }
        public string displayWeekNumber { get; set; }
        public string displayPeriodStartText { get; set; }
        public string displayPeriodEndText { get; set; }

        public DateTime PeriodStartDate { get; set; }
        public DateTime PeriodEndDate { get; set; }


    }
}
