using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class bookingapikey1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "BookingAPIkey",
                table: "BookingSetups",
                nullable: true,
                oldClrType: typeof(Guid));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "BookingAPIkey",
                table: "BookingSetups",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
