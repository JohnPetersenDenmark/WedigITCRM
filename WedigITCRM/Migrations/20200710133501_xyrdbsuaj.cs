using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class xyrdbsuaj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeadLine",
                table: "PurchaseBudgetPeriodLines");

            migrationBuilder.AddColumn<string>(
                name: "displayPeriodEndText",
                table: "PurchaseBudgetPeriodLines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "displayPeriodStartText",
                table: "PurchaseBudgetPeriodLines",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "displayWeekNumber",
                table: "PurchaseBudgetPeriodLines",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "displayPeriodEndText",
                table: "PurchaseBudgetPeriodLines");

            migrationBuilder.DropColumn(
                name: "displayPeriodStartText",
                table: "PurchaseBudgetPeriodLines");

            migrationBuilder.DropColumn(
                name: "displayWeekNumber",
                table: "PurchaseBudgetPeriodLines");

            migrationBuilder.AddColumn<string>(
                name: "HeadLine",
                table: "PurchaseBudgetPeriodLines",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
