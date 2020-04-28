using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class bookingsetupforuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingSetups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MondayOfficeStartTime = table.Column<DateTime>(nullable: false),
                    TuesdayOfficeStartTime = table.Column<DateTime>(nullable: false),
                    WednesdayOfficeStartTime = table.Column<DateTime>(nullable: false),
                    ThursdayOfficeStartTime = table.Column<DateTime>(nullable: false),
                    FridayOfficeStartTime = table.Column<DateTime>(nullable: false),
                    SaturdayOfficeStartTime = table.Column<DateTime>(nullable: false),
                    SunOfficeStartTime = table.Column<DateTime>(nullable: false),
                    MondayOfficeEndTime = table.Column<DateTime>(nullable: false),
                    TuesdayOfficeEndTime = table.Column<DateTime>(nullable: false),
                    WednesdayOfficeEndTime = table.Column<DateTime>(nullable: false),
                    ThursdayOfficeEndTime = table.Column<DateTime>(nullable: false),
                    FridayOfficeEndTime = table.Column<DateTime>(nullable: false),
                    SaturdayOfficeEndTime = table.Column<DateTime>(nullable: false),
                    SunOfficeEndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSetups", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingSetups");
        }
    }
}
