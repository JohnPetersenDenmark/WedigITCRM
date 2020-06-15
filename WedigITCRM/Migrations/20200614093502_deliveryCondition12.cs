using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class deliveryCondition12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryConditions",
                table: "PurchaseOrders");

            migrationBuilder.AddColumn<string>(
                name: "VendorDeliveryConditionId",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VendorDeliveryConditions",
                table: "PurchaseOrders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VendorDeliveryConditionId",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "VendorDeliveryConditions",
                table: "PurchaseOrders");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryConditions",
                table: "PurchaseOrders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
