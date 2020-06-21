﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;
using X.PagedList;

namespace WedigITCRM.ViewModels
{
    public class SearchPurchaseOrderViewModel
    {
        public string ReceivedStatus { get; set; }
        public string VendorId { get; set; }
        public string PurchaseDocumentNumber { get; set; }
        public string SearchFromDate { get; set; }
        public string SearchToDate { get; set; }
        public IPagedList<PurchaseOrderViewLineModel> PurchaseOrdersViewLines { get; set; }
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
    public class PurchaseOrderViewLineModel
    {
        public string Id { get; set; }
        public string VendorName { get; set; }
        public string OurOrderingDate { get; set; }
        public string SendToVendorDate { get; set; }
        public string PurchaseOrderDocumentNumber { get; set; }

        public string ReceivedStatus { get; set; }
    }
}