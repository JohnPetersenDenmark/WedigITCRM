using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using X.PagedList;

namespace WedigITCRM.ViewModels
{
    public class PurchaseOrderListViewModel
    {
        public PurchaseOrderListViewModel()
        {
            
        }

        public string ReceivedStatus { get; set; }
        public string VendorId { get; set; }
        public string PurchaseDocumentNumber { get; set; }

        public string SearchFromDate { get; set; }
        public string SearchToDate { get; set; }

        public IPagedList<PurchaseOrder> PurchaseOrders { get; set; }
        public List<SelectListItem> SearchByPurchaseDocumentNumber { get; } = new List<SelectListItem>
        {
              new SelectListItem { Value = "0", Text = "Vælg" }
        };

        public List<SelectListItem> SearchByVendor { get; } = new List<SelectListItem>
        {
              new SelectListItem { Value = "0", Text = "Vælg" }
        };
        public List<SelectListItem> SearchByReceivedStatus { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "Vælg" },
            new SelectListItem { Value = "1", Text = "Modtaget" },
            new SelectListItem { Value = "2", Text = "Ikke modtaget" },
            new SelectListItem { Value = "3", Text = "Delvis modtaget"  }       
        };

        public List<SelectListItem> searchByArchiveStatus { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "0", Text = "Vælg" },
            new SelectListItem { Value = "1", Text = "Kladde" },
            new SelectListItem { Value = "2", Text = "Bogført" }         
        };

    }
}
