using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class eventcolor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventColor",
                table: "CalendarEntries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CalendarEventsColor",
                table: "BookingResources",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventColor",
                table: "CalendarEntries");

            migrationBuilder.DropColumn(
                name: "CalendarEventsColor",
                table: "BookingResources");
        }
    }
}
