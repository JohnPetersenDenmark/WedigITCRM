using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class addedVendorPaymentCondition1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentTerms",
                table: "PurchaseOrders");

            migrationBuilder.AddColumn<int>(
                name: "PaymentConditionsId",
                table: "Vendors",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VendorPaymentConditions",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorPaymentConditionsId",
                table: "PurchaseOrders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentConditionsId",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "VendorPaymentConditions",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "VendorPaymentConditionsId",
                table: "PurchaseOrders");

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerms",
                table: "PurchaseOrders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
