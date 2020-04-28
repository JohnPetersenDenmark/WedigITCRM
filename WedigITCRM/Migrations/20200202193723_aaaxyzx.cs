using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class aaaxyzx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "category1Id",
                table: "stockItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "category2Id",
                table: "stockItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "category3Id",
                table: "stockItems",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "category1Id",
                table: "stockItems");

            migrationBuilder.DropColumn(
                name: "category2Id",
                table: "stockItems");

            migrationBuilder.DropColumn(
                name: "category3Id",
                table: "stockItems");
        }
    }
}
