using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class purchaseOrderPDF1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CompanyCity",
                table: "companyAccounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCountryCode",
                table: "companyAccounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyStreet",
                table: "companyAccounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyZip",
                table: "companyAccounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyCity",
                table: "companyAccounts");

            migrationBuilder.DropColumn(
                name: "CompanyCountryCode",
                table: "companyAccounts");

            migrationBuilder.DropColumn(
                name: "CompanyStreet",
                table: "companyAccounts");

            migrationBuilder.DropColumn(
                name: "CompanyZip",
                table: "companyAccounts");
        }
    }
}
