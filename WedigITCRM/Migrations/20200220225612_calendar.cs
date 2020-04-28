using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class calendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "jobServiceTypes",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CalendarEntries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    caleventid = table.Column<string>(nullable: true),
                    selectallday = table.Column<bool>(nullable: false),
                    startDateTime = table.Column<DateTime>(nullable: false),
                    endDateTime = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    repeatingId = table.Column<int>(nullable: false),
                    selectRepeat = table.Column<bool>(nullable: false),
                    startDateTimeRange = table.Column<DateTime>(nullable: false),
                    endDateTimeRange = table.Column<DateTime>(nullable: false),
                    rangeWeekDays = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEntries", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarEntries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "jobServiceTypes",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
