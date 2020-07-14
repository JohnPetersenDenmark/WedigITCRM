using Microsoft.AspNetCore.Mvc.Rendering;
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
        public string Description { get; set; }
        public string SearchByStockItemName { get; set; }
        public string SearchByStockItemNumber { get; set; }
        public string VendorId { get; set; }
        public List<SelectListItem> SearchByVendor { get; } = new List<SelectListItem>
        {
              new SelectListItem { Value = "0", Text = "Vælg" }
        };
        public string category1Id { get; set; }
        public List<SelectListItem> SearchByCategory1 { get; } = new List<SelectListItem>
        {
              new SelectListItem { Value = "0", Text = "Vælg" }
        };

        public string category2Id { get; set; }
        public List<SelectListItem> SearchByCategory2 { get; } = new List<SelectListItem>
        {
              new SelectListItem { Value = "0", Text = "Vælg" }
        };

        public string category3Id { get; set; }
        public List<SelectListItem> SearchByCategory3 { get; } = new List<SelectListItem>
        {
              new SelectListItem { Value = "0", Text = "Vælg" }
        };

        public string PurchaseBudgetId { get; set; }
        public List<StockItem> StockItems { get; set; }
        public List<PurchaseBudgetPeriodLine> PeriodLines { get; set; }
        public List<PurchaseBudgetLineModel> BudgetLines { get; set; }
    }

    
}
