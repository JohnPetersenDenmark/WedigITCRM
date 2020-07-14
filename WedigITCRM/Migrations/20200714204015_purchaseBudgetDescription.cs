using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class purchaseBudgetDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PurchaseBudgets",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PurchaseBudgets");
        }
    }
}
