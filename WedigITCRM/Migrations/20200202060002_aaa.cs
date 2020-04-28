using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class aaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "companyAccountId",
                table: "stockItemCategory3s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "companyAccountId",
                table: "stockItemCategory2s",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "companyAccountId",
                table: "stockItemCategory1s",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "companyAccountId",
                table: "stockItemCategory3s");

            migrationBuilder.DropColumn(
                name: "companyAccountId",
                table: "stockItemCategory2s");

            migrationBuilder.DropColumn(
                name: "companyAccountId",
                table: "stockItemCategory1s");
        }
    }
}
