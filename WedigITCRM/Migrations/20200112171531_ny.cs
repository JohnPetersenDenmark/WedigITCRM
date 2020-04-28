using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class ny : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IntegartionDinero",
                table: "companyAccounts",
                newName: "IntegrationDinero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IntegrationDinero",
                table: "companyAccounts",
                newName: "IntegartionDinero");
        }
    }
}
