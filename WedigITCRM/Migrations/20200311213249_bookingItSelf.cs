using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class bookingItSelf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SMSverificationCode",
                table: "Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "customerId",
                table: "CalendarEntries",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SMSverificationCode",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "CalendarEntries");
        }
    }
}
