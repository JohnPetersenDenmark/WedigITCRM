using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class sync : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ContactsLastSynchronizationDate",
                table: "companyAccounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StockItemsLastSynchronizationDate",
                table: "companyAccounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "VendorsItemsLastSynchronizationDate",
                table: "companyAccounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactsLastSynchronizationDate",
                table: "companyAccounts");

            migrationBuilder.DropColumn(
                name: "StockItemsLastSynchronizationDate",
                table: "companyAccounts");

            migrationBuilder.DropColumn(
                name: "VendorsItemsLastSynchronizationDate",
                table: "companyAccounts");
        }
    }
}
