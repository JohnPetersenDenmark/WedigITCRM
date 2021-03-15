using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class cookiesChangeLog1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CookieChangeLogs",
                table: "CookieChangeLogs");

            migrationBuilder.RenameTable(
                name: "CookieChangeLogs",
                newName: "CookieChangeLog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CookieChangeLog",
                table: "CookieChangeLog",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CookieChangeLog",
                table: "CookieChangeLog");

            migrationBuilder.RenameTable(
                name: "CookieChangeLog",
                newName: "CookieChangeLogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CookieChangeLogs",
                table: "CookieChangeLogs",
                column: "Id");
        }
    }
}
