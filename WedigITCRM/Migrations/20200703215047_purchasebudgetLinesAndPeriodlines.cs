using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class purchasebudgetLinesAndPeriodlines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseBudgetLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockItemId = table.Column<int>(nullable: false),
                    PurchaseBudgetId = table.Column<int>(nullable: false),
                    OurLocationId = table.Column<string>(nullable: true),
                    PeriodLineId = table.Column<string>(nullable: true),
                    QuantityToOrder = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastEditedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseBudgetLines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseBudgetPeriodLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseBudgetId = table.Column<int>(nullable: false),
                    PeriodStartDate = table.Column<DateTime>(nullable: false),
                    PeriodEndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseBudgetPeriodLines", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseBudgetLines");

            migrationBuilder.DropTable(
                name: "PurchaseBudgetPeriodLines");
        }
    }
}
