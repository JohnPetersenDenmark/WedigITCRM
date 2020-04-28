using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class vendor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CVRNumber = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    HomePage = table.Column<string>(nullable: true),
                    postalCodeId = table.Column<string>(nullable: true),
                    companyAccountId = table.Column<int>(nullable: false),
                    DineroGuiD = table.Column<Guid>(nullable: false),
                    LastEditedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendors_companyAccounts_companyAccountId",
                        column: x => x.companyAccountId,
                        principalTable: "companyAccounts",
                        principalColumn: "companyAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_companyAccountId",
                table: "Vendors",
                column: "companyAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vendors");
        }
    }
}
