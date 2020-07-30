using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class nyxiumSetupTableChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "NyxiumSubscription1NumberOfMonths",
                table: "NyxiumSetups",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NyxiumSubscription2NumberOfMonths",
                table: "NyxiumSetups",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "NyxiumSubscriptionPricePerMonth",
                table: "NyxiumSetups",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentConditionNumberOfDays",
                table: "NyxiumSetups",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaymentConditionType",
                table: "NyxiumSetups",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NyxiumSubscription1NumberOfMonths",
                table: "NyxiumSetups");

            migrationBuilder.DropColumn(
                name: "NyxiumSubscription2NumberOfMonths",
                table: "NyxiumSetups");

            migrationBuilder.DropColumn(
                name: "NyxiumSubscriptionPricePerMonth",
                table: "NyxiumSetups");

            migrationBuilder.DropColumn(
                name: "PaymentConditionNumberOfDays",
                table: "NyxiumSetups");

            migrationBuilder.DropColumn(
                name: "PaymentConditionType",
                table: "NyxiumSetups");
        }
    }
}
