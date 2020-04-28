using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class wuabdujf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "synchronizeCustomerFromDineroToNyxium",
                table: "companyAccounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "synchronizeCustomerFromNyxiumToDinero",
                table: "companyAccounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "synchronizeStockItemFromDineroToNyxium",
                table: "companyAccounts",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "synchronizeStockItemFromNyxiumToDinero",
                table: "companyAccounts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "synchronizeCustomerFromDineroToNyxium",
                table: "companyAccounts");

            migrationBuilder.DropColumn(
                name: "synchronizeCustomerFromNyxiumToDinero",
                table: "companyAccounts");

            migrationBuilder.DropColumn(
                name: "synchronizeStockItemFromDineroToNyxium",
                table: "companyAccounts");

            migrationBuilder.DropColumn(
                name: "synchronizeStockItemFromNyxiumToDinero",
                table: "companyAccounts");
        }
    }
}
