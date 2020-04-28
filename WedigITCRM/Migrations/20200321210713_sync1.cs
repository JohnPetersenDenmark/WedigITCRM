using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class sync1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VendorsItemsLastSynchronizationDate",
                table: "companyAccounts",
                newName: "VendorsItemsToDineroLastSynchronizationDate");

            migrationBuilder.RenameColumn(
                name: "StockItemsLastSynchronizationDate",
                table: "companyAccounts",
                newName: "StockItemsToDineroLastSynchronizationDate");

            migrationBuilder.RenameColumn(
                name: "ContactsLastSynchronizationDate",
                table: "companyAccounts",
                newName: "ContactsToNyxiumLastSynchronizationDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "ContactsToDineroLastSynchronizationDate",
                table: "companyAccounts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactsToDineroLastSynchronizationDate",
                table: "companyAccounts");

            migrationBuilder.RenameColumn(
                name: "VendorsItemsToDineroLastSynchronizationDate",
                table: "companyAccounts",
                newName: "VendorsItemsLastSynchronizationDate");

            migrationBuilder.RenameColumn(
                name: "StockItemsToDineroLastSynchronizationDate",
                table: "companyAccounts",
                newName: "StockItemsLastSynchronizationDate");

            migrationBuilder.RenameColumn(
                name: "ContactsToNyxiumLastSynchronizationDate",
                table: "companyAccounts",
                newName: "ContactsLastSynchronizationDate");
        }
    }
}
