using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class noter1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileNameOnly",
                table: "Notes",
                newName: "FileNamesOnly");

            migrationBuilder.RenameColumn(
                name: "AttachedFileNameAndPath",
                table: "Notes",
                newName: "AttachedFilesNameAndPath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileNamesOnly",
                table: "Notes",
                newName: "FileNameOnly");

            migrationBuilder.RenameColumn(
                name: "AttachedFilesNameAndPath",
                table: "Notes",
                newName: "AttachedFileNameAndPath");
        }
    }
}
