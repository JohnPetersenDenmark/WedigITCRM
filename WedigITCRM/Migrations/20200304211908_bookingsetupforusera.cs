using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class bookingsetupforusera : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SunOfficeStartTime",
                table: "BookingSetups",
                newName: "SundayOfficeStartTime");

            migrationBuilder.RenameColumn(
                name: "SunOfficeEndTime",
                table: "BookingSetups",
                newName: "SundayOfficeEndTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SundayOfficeStartTime",
                table: "BookingSetups",
                newName: "SunOfficeStartTime");

            migrationBuilder.RenameColumn(
                name: "SundayOfficeEndTime",
                table: "BookingSetups",
                newName: "SunOfficeEndTime");
        }
    }
}
