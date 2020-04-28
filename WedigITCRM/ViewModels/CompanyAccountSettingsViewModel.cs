using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM.ViewControllers
{
    public class CompanyAccountSettingsViewModel
    {
        public int companyAccountId { get; set; }
        public string CompanyName { get; set; }
        public DateTime registrationDate { get; set; }

        public bool SubscriptionCRM { get; set; }
        public bool synchronizeCustomerFromDineroToNyxium { get; set; }
        public bool synchronizeCustomerFromNyxiumToDinero { get; set; }
        public bool SubscriptionInventory { get; set; }

        public bool synchronizeStockItemFromDineroToNyxium { get; set; }
        public bool synchronizeStockItemFromNyxiumToDinero { get; set; }

        public bool SubscriptionVendor { get; set; }
       
        public bool SubscriptionProcurement { get; set; }

        
        public bool SalesStatistic { get; set; }

        public bool Booking { get; set; }
        public bool IntegrationDinero { get; set; }
        public string DineroAPIOrganizationKey { get; set; }
        public string DineroAPIOrganization { get; set; }

        public string ExistingLogoAttachedmentIds { get; set; }
        public string ExistinglogoFileNameOnly { get; set; }
        public string ExistingAttachedLogoFilesNameAndPath { get; set; }
        public string ExistingAttachedLogoTypeIconPath { get; set; }

        public List<string> logoFileNameOnly { get; set; }
        public List<string> LogoAttachedmentId { get; set; }
       // public string AttachedFilesNameAndPath { get; set; }
        public List<IFormFile> AttachedLogo { get; set; }
    }
}
