﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WedigITCRM;

namespace WedigITCRM.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200331100516_countryCodeVendor")]
    partial class countryCodeVendor
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WedigITCRM.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Date")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastEditedDate");

                    b.Property<bool>("NotificationIsSent");

                    b.Property<string>("NotifyOffset")
                        .IsRequired();

                    b.Property<string>("Subject")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.Property<int>("companyAccountId");

                    b.Property<int>("contactPersonId");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("WedigITCRM.BookingResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CalendarEventsColor");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("EmailForCalendar");

                    b.Property<string>("JobDescription");

                    b.Property<string>("JobServiceTypes");

                    b.Property<DateTime>("LastEditedDate");

                    b.Property<int>("UserId");

                    b.Property<int>("companyAccountId");

                    b.HasKey("Id");

                    b.ToTable("BookingResources");
                });

            modelBuilder.Entity("WedigITCRM.BookingService", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<Guid>("DineroGuiD");

                    b.Property<int>("GapTimeAfterInMinutes");

                    b.Property<int>("GapTimeBeforeInMinutes");

                    b.Property<bool>("IsBookable");

                    b.Property<DateTime>("LastEditedDate");

                    b.Property<string>("Name");

                    b.Property<string>("ProductNumber");

                    b.Property<decimal>("SalesPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("companyAccountId");

                    b.Property<int>("durationInMinutes");

                    b.HasKey("id");

                    b.ToTable("BookingServices");
                });

            modelBuilder.Entity("WedigITCRM.BookingSetup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookingAPIkey");

                    b.Property<int>("BookingFreeTimeInterval");

                    b.Property<DateTime>("FridayOfficeEndTime");

                    b.Property<DateTime>("FridayOfficeStartTime");

                    b.Property<DateTime>("MondayOfficeEndTime");

                    b.Property<DateTime>("MondayOfficeStartTime");

                    b.Property<DateTime>("SaturdayOfficeEndTime");

                    b.Property<DateTime>("SaturdayOfficeStartTime");

                    b.Property<DateTime>("SundayOfficeEndTime");

                    b.Property<DateTime>("SundayOfficeStartTime");

                    b.Property<DateTime>("ThursdayOfficeEndTime");

                    b.Property<DateTime>("ThursdayOfficeStartTime");

                    b.Property<DateTime>("TuesdayOfficeEndTime");

                    b.Property<DateTime>("TuesdayOfficeStartTime");

                    b.Property<DateTime>("WednesdayOfficeEndTime");

                    b.Property<DateTime>("WednesdayOfficeStartTime");

                    b.Property<int>("companyAccountId");

                    b.HasKey("Id");

                    b.ToTable("BookingSetups");
                });

            modelBuilder.Entity("WedigITCRM.CalendarEntry", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CalendarEventResourceOwnerId");

                    b.Property<bool>("IsFromResourceCalendar");

                    b.Property<int>("companyAccountId");

                    b.Property<int>("customerId");

                    b.Property<string>("description");

                    b.Property<DateTime>("endDateTime");

                    b.Property<DateTime>("endDateTimeRange");

                    b.Property<string>("rangeWeekDays");

                    b.Property<int>("repeatingId");

                    b.Property<bool>("selectRepeat");

                    b.Property<bool>("selectallday");

                    b.Property<DateTime>("startDateTime");

                    b.Property<DateTime>("startDateTimeRange");

                    b.HasKey("id");

                    b.ToTable("CalendarEntries");
                });

            modelBuilder.Entity("WedigITCRM.ChangePasswordRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("LinkRequestId");

                    b.Property<DateTime>("RequestDateTime");

                    b.Property<string>("SendToEmail");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("changePasswordRequests");
                });

            modelBuilder.Entity("WedigITCRM.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CVRNumber");

                    b.Property<string>("City");

                    b.Property<string>("CountryCode");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("DineroGuiD");

                    b.Property<string>("Email");

                    b.Property<string>("HomePage");

                    b.Property<bool>("IsPerson");

                    b.Property<DateTime>("LastEditedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("SMSverificationCode");

                    b.Property<string>("Street");

                    b.Property<string>("Zip");

                    b.Property<int>("companyAccountId");

                    b.Property<string>("postalCodeId");

                    b.HasKey("Id");

                    b.HasIndex("companyAccountId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("WedigITCRM.CompanyAccount", b =>
                {
                    b.Property<int>("companyAccountId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AmountToPayForLicense")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Booking");

                    b.Property<string>("CompanyName");

                    b.Property<string>("Companyidentifier");

                    b.Property<DateTime>("ContactsToDineroLastSynchronizationDate");

                    b.Property<DateTime>("ContactsToNyxiumLastSynchronizationDate");

                    b.Property<string>("DineroAPIOrganization");

                    b.Property<string>("DineroAPIOrganizationKey");

                    b.Property<bool>("IntegrationDinero");

                    b.Property<int>("NyxiumLicenseTypeId");

                    b.Property<string>("NyxiumLicenseTypeName");

                    b.Property<bool>("SalesStatistic");

                    b.Property<DateTime>("StockItemsToDineroLastSynchronizationDate");

                    b.Property<DateTime>("StockItemsToNyxiumSynchronizationDate");

                    b.Property<bool>("SubscriptionCRM");

                    b.Property<bool>("SubscriptionInventory");

                    b.Property<bool>("SubscriptionProcurement");

                    b.Property<bool>("SubscriptionVendor");

                    b.Property<DateTime>("VendorsItemsToDineroLastSynchronizationDate");

                    b.Property<DateTime>("activationDate");

                    b.Property<Guid>("activationKey");

                    b.Property<DateTime>("registrationDate");

                    b.Property<bool>("synchronizeCustomerFromDineroToNyxium");

                    b.Property<bool>("synchronizeCustomerFromNyxiumToDinero");

                    b.Property<bool>("synchronizeStockItemFromDineroToNyxium");

                    b.Property<bool>("synchronizeStockItemFromNyxiumToDinero");

                    b.HasKey("companyAccountId");

                    b.ToTable("companyAccounts");
                });

            modelBuilder.Entity("WedigITCRM.ContactPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CellPhone");

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Department");

                    b.Property<Guid>("DineroGuiD");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<DateTime>("LastEditedDate");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Title");

                    b.Property<int>("companyAccountId");

                    b.HasKey("Id");

                    b.ToTable("ContactPersons");
                });

            modelBuilder.Entity("WedigITCRM.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode");

                    b.Property<string>("CountryName");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("WedigITCRM.JobServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookingServicesIds");

                    b.Property<string>("Desciption");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("companyAccountId");

                    b.HasKey("Id");

                    b.ToTable("jobServiceTypes");
                });

            modelBuilder.Entity("WedigITCRM.LicenseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<decimal>("SalesPriceAnnualPayment")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SalesPriceMonthlyPayment")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("LicenseTypes");
                });

            modelBuilder.Entity("WedigITCRM.PostalCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.ToTable("postnumre");
                });

            modelBuilder.Entity("WedigITCRM.RelateCompanyAccountWithRole", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("companyAccount");

                    b.Property<string>("role");

                    b.HasKey("id");

                    b.ToTable("relateCompanyAccountWithRoles");
                });

            modelBuilder.Entity("WedigITCRM.RelateCompanyAccountWithUser", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName");

                    b.Property<int>("companyAccount");

                    b.Property<string>("user");

                    b.Property<string>("userName");

                    b.HasKey("id");

                    b.ToTable("relateCompanyAccountWithUsers");
                });

            modelBuilder.Entity("WedigITCRM.StockItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("DineroGuiD");

                    b.Property<DateTime>("Expirationdate");

                    b.Property<DateTime>("InStockAgainDate");

                    b.Property<string>("ItemName");

                    b.Property<string>("ItemNumber");

                    b.Property<DateTime>("LastEditedDate");

                    b.Property<string>("Location");

                    b.Property<int>("NumberInStock");

                    b.Property<int>("ReorderNumberInStock");

                    b.Property<decimal>("SalesPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("StockValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Unit");

                    b.Property<int>("VendorId");

                    b.Property<string>("VendorItemNumber");

                    b.Property<int>("category1Id");

                    b.Property<int>("category2Id");

                    b.Property<int>("category3Id");

                    b.Property<int>("companyAccountId");

                    b.HasKey("Id");

                    b.ToTable("stockItems");
                });

            modelBuilder.Entity("WedigITCRM.StockItemCategory1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("companyAccountId");

                    b.HasKey("Id");

                    b.ToTable("stockItemCategory1s");
                });

            modelBuilder.Entity("WedigITCRM.StockItemCategory2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category1Id");

                    b.Property<string>("Name");

                    b.Property<int>("companyAccountId");

                    b.HasKey("Id");

                    b.ToTable("stockItemCategory2s");
                });

            modelBuilder.Entity("WedigITCRM.StockItemCategory3", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category2Id");

                    b.Property<string>("Name");

                    b.Property<int>("companyAccountId");

                    b.HasKey("Id");

                    b.ToTable("stockItemCategory3s");
                });

            modelBuilder.Entity("WedigITCRM.Vendor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CVRNumber");

                    b.Property<string>("City");

                    b.Property<string>("CountryCode");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<Guid>("DineroGuiD");

                    b.Property<string>("HomePage");

                    b.Property<DateTime>("LastEditedDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Street");

                    b.Property<string>("Zip");

                    b.Property<int>("companyAccountId");

                    b.Property<string>("postalCodeId");

                    b.HasKey("Id");

                    b.HasIndex("companyAccountId");

                    b.ToTable("Vendors");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WedigITCRM.Company", b =>
                {
                    b.HasOne("WedigITCRM.CompanyAccount", "companyAccount")
                        .WithMany()
                        .HasForeignKey("companyAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WedigITCRM.Vendor", b =>
                {
                    b.HasOne("WedigITCRM.CompanyAccount", "companyAccount")
                        .WithMany()
                        .HasForeignKey("companyAccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
