using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WedigITCRM.EntitityModels;

namespace WedigITCRM
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<DeliveryCondition> DeliveryConditions { get; set; }

        public DbSet<PaymentCondition> PaymentConditions { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<PostalCode> postnumre { get; set; }

        public DbSet<CurrencyCode> CurrencyCodes { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<ContentType> ContentTypes { get; set; }

        public DbSet<CompanyAccount> companyAccounts { get; set; }

        public DbSet<LicenseType> LicenseTypes { get; set; }

        public DbSet<StockItem> stockItems { get; set; }

        public DbSet<StockItemCategory1> stockItemCategory1s { get; set; }

        public DbSet<StockItemCategory2> stockItemCategory2s { get; set; }

        public DbSet<StockItemCategory3> stockItemCategory3s { get; set; }

        public DbSet<JobServiceType> jobServiceTypes { get; set; }

        public DbSet<BookingResource> BookingResources { get; set; }

        public DbSet<BookingService> BookingServices { get; set; }

        public DbSet<BookingSetup> BookingSetups { get; set; }

        public DbSet<CalendarEntry> CalendarEntries { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        //
        public DbSet<RelateCompanyAccountWithUser> relateCompanyAccountWithUsers { get; set; }

        public DbSet<RelateCompanyAccountWithRole> relateCompanyAccountWithRoles { get; set; }
        public DbSet<ChangePasswordRequest> changePasswordRequests { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
