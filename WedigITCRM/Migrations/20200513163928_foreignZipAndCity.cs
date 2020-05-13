using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class foreignZipAndCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForeignCity",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForeignZip",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForeignCity",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ForeignZip",
                table: "Companies");
        }
    }
}
