using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class deliveryCondition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryConditions",
                table: "Vendors",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryConditionsId",
                table: "Vendors",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryConditions",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "DeliveryConditionsId",
                table: "Vendors");
        }
    }
}
