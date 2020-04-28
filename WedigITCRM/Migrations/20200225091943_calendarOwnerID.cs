using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class calendarOwnerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CalendarEventResourceOwnerId",
                table: "CalendarEntries",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalendarEventResourceOwnerId",
                table: "CalendarEntries");
        }
    }
}
