using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class purchaseOrderImplemented : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OurReference = table.Column<string>(nullable: true),
                    VendorReference = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    ExchangeRate = table.Column<string>(nullable: true),
                    PaymentTerms = table.Column<string>(nullable: true),
                    DeliveryConditions = table.Column<string>(nullable: true),
                    SendDate = table.Column<DateTime>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    ReceivedStatus = table.Column<int>(nullable: false),
                    WantedDeliveryDate = table.Column<string>(nullable: true),
                    SendToVendorDate = table.Column<DateTime>(nullable: false),
                    AllReceivedDate = table.Column<DateTime>(nullable: false),
                    LastEditedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    VendorId = table.Column<int>(nullable: false),
                    companyAccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrders");
        }
    }
}
