using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class gggHHHvvv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingServices",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProductNumber = table.Column<string>(nullable: true),
                    durationInMinutes = table.Column<int>(nullable: false),
                    IsBookable = table.Column<bool>(nullable: false),
                    GapTimeBeforeInMinutes = table.Column<int>(nullable: false),
                    GapTimeAfterInMinutes = table.Column<int>(nullable: false),
                    SalesPrice = table.Column<decimal>(nullable: false),
                    LastEditedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    companyAccountId = table.Column<int>(nullable: true),
                    DineroGuiD = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingServices", x => x.id);
                    table.ForeignKey(
                        name: "FK_BookingServices_companyAccounts_companyAccountId",
                        column: x => x.companyAccountId,
                        principalTable: "companyAccounts",
                        principalColumn: "companyAccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingServices_companyAccountId",
                table: "BookingServices",
                column: "companyAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingServices");
        }
    }
}
