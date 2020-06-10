using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class purchaseOrderExpanded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseOrderDocumentNumber",
                table: "PurchaseOrders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VendorCity",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorCountryCode",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorCurrencyCode",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorHomePage",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorName",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorPhoneNumber",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorStreet",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorZip",
                table: "PurchaseOrders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseOrderDocumentNumber",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "VendorCity",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "VendorCountryCode",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "VendorCurrencyCode",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "VendorHomePage",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "VendorName",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "VendorPhoneNumber",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "VendorStreet",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "VendorZip",
                table: "PurchaseOrders");
        }
    }
}
