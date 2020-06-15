using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class purchaseorderlines1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VendorUnitPrice",
                table: "PurchaseOrderLines",
                newName: "VendorSalesUnitPrice");

            migrationBuilder.RenameColumn(
                name: "OurUnitPrice",
                table: "PurchaseOrderLines",
                newName: "QuantityToOrder");

            migrationBuilder.AddColumn<string>(
                name: "VendorItemName",
                table: "stockItems",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OurUnitCostPrice",
                table: "PurchaseOrderLines",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OurUnitSalesPrice",
                table: "PurchaseOrderLines",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VendorItemName",
                table: "stockItems");

            migrationBuilder.DropColumn(
                name: "OurUnitCostPrice",
                table: "PurchaseOrderLines");

            migrationBuilder.DropColumn(
                name: "OurUnitSalesPrice",
                table: "PurchaseOrderLines");

            migrationBuilder.RenameColumn(
                name: "VendorSalesUnitPrice",
                table: "PurchaseOrderLines",
                newName: "VendorUnitPrice");

            migrationBuilder.RenameColumn(
                name: "QuantityToOrder",
                table: "PurchaseOrderLines",
                newName: "OurUnitPrice");
        }
    }
}
