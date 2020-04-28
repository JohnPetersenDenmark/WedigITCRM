using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class nogetXXXXXX : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DineroAPIOrganization",
                table: "companyAccounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DineroAPIOrganizationKey",
                table: "companyAccounts",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SalesStatistic",
                table: "companyAccounts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DineroAPIOrganization",
                table: "companyAccounts");

            migrationBuilder.DropColumn(
                name: "DineroAPIOrganizationKey",
                table: "companyAccounts");

            migrationBuilder.DropColumn(
                name: "SalesStatistic",
                table: "companyAccounts");
        }
    }
}
