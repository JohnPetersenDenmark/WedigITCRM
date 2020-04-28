using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class stockItems1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stockItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemName = table.Column<string>(nullable: true),
                    ItemNumber = table.Column<string>(nullable: true),
                    NumberInStock = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    VendorId = table.Column<int>(nullable: false),
                    VendorItemNumber = table.Column<string>(nullable: true),
                    Expirationdate = table.Column<DateTime>(nullable: false),
                    InStockAgainDate = table.Column<DateTime>(nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    SalesPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stockItems");
        }
    }
}
