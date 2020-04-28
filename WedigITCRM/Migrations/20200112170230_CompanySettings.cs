using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class CompanySettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IntegartionDinero",
                table: "companyAccounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SubscriptionCRM",
                table: "companyAccounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SubscriptionInventory",
                table: "companyAccounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SubscriptionProcurement",
                table: "companyAccounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SubscriptionVendor",
                table: "companyAccounts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntegartionDinero",
                table: "companyAccounts");

            migrationBuilder.DropColumn(
                name: "SubscriptionCRM",
                table: "companyAccounts");

            migrationBuilder.DropColumn(
                name: "SubscriptionInventory",
                table: "companyAccounts");

            migrationBuilder.DropColumn(
                name: "SubscriptionProcurement",
                table: "companyAccounts");

            migrationBuilder.DropColumn(
                name: "SubscriptionVendor",
                table: "companyAccounts");
        }
    }
}
