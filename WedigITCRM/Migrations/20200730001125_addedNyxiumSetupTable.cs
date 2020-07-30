using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class addedNyxiumSetupTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NyxiumSetups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DineroAPIOrganizationKey = table.Column<string>(nullable: true),
                    DineroAPIOrganization = table.Column<string>(nullable: true),
                    NyxiumSubscription1DineroProductGuid = table.Column<string>(nullable: true),
                    NyxiumSubscription2DineroProductGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NyxiumSetups", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NyxiumSetups");
        }
    }
}
