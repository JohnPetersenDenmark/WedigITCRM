using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class licensetypesAggain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "companyAccounts",
                newName: "NyxiumLicenseTypeName");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountToPayForLicense",
                table: "companyAccounts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "NyxiumLicenseTypeId",
                table: "companyAccounts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountToPayForLicense",
                table: "companyAccounts");

            migrationBuilder.DropColumn(
                name: "NyxiumLicenseTypeId",
                table: "companyAccounts");

            migrationBuilder.RenameColumn(
                name: "NyxiumLicenseTypeName",
                table: "companyAccounts",
                newName: "type");
        }
    }
}
