using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class notes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Subject = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    AttachedFileName = table.Column<string>(nullable: true),
                    contactPersonId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    companyAccountId = table.Column<int>(nullable: false),
                    LastEditedDate = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
