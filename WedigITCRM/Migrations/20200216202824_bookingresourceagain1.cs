using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class bookingresourceagain1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Jobdesciption",
                table: "BookingResources",
                newName: "JobDescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobDescription",
                table: "BookingResources",
                newName: "Jobdesciption");
        }
    }
}
