using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class notes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AttachedFileName",
                table: "Notes",
                newName: "FileNameOnly");

            migrationBuilder.AddColumn<string>(
                name: "AttachedFileNameAndPath",
                table: "Notes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachedFileNameAndPath",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "FileNameOnly",
                table: "Notes",
                newName: "AttachedFileName");
        }
    }
}
