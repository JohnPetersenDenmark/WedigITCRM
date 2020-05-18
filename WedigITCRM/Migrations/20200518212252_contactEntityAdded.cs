using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class contactEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CVRNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    CurrencyCode = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    HomePage = table.Column<string>(nullable: true),
                    ForeignZip = table.Column<string>(nullable: true),
                    ForeignCity = table.Column<string>(nullable: true),
                    PaymentConditions = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsPerson = table.Column<bool>(nullable: false),
                    postalCodeId = table.Column<string>(nullable: true),
                    companyAccountId = table.Column<int>(nullable: false),
                    DineroGuiD = table.Column<Guid>(nullable: false),
                    SMSverificationCode = table.Column<int>(nullable: false),
                    LastEditedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_companyAccounts_companyAccountId",
                        column: x => x.companyAccountId,
                        principalTable: "companyAccounts",
                        principalColumn: "companyAccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_companyAccountId",
                table: "Contacts",
                column: "companyAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
