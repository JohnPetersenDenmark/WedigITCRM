using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.Controllers;
using WedigITCRM.EntitityModels;

namespace WedigITCRM.ViewModels
{
    public class PurchaseBudgetEditViewModel
    {
        public string PurchaseBudgetId { get; set; }
        public List<StockItem> StockItems { get; set; }
        public List<PurchaseBudgetPeriodLine> PeriodLines { get; set; }
        public List<PurchaseBudgetLineModel> BudgetLines { get; set; }
    }

    
}
