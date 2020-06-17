using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public class CompanyAccount
    {
        public int companyAccountId { get; set; }

        public string NyxiumLicenseTypeName { get; set; }

        public int NyxiumLicenseTypeId { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public Decimal AmountToPayForLicense { get; set; }

        public string CompanyName { get; set; }
        public string CompanyStreet { get; set; }
        public string CompanyZip { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyCountryCode { get; set; }

        public string Companyidentifier { get; set; }
       
        public Guid activationKey { get; set; }
        public DateTime activationDate { get; set; }

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

        public DateTime ContactsToDineroLastSynchronizationDate { get; set; }
        public DateTime StockItemsToDineroLastSynchronizationDate { get; set; }
        public DateTime StockItemsToNyxiumSynchronizationDate { get; set; }
        public DateTime VendorsItemsToDineroLastSynchronizationDate { get; set; }

        public DateTime ContactsToNyxiumLastSynchronizationDate { get; set; }

        public string LogoAttachmentIds { get; set; }

    }
}
