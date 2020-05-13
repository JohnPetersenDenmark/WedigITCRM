using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class vendorForeignZipCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForeignCity",
                table: "Vendors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ForeignZip",
                table: "Vendors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForeignCity",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "ForeignZip",
                table: "Vendors");
        }
    }
}
