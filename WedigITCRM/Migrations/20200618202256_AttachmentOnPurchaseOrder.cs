using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class AttachmentOnPurchaseOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AttachedFilesNameAndPath",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AttachedmentIds",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileNamesOnly",
                table: "PurchaseOrders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconsFilePathAndName",
                table: "PurchaseOrders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachedFilesNameAndPath",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "AttachedmentIds",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "FileNamesOnly",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "IconsFilePathAndName",
                table: "PurchaseOrders");
        }
    }
}
