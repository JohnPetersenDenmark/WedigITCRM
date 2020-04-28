using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class gfetajd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingServices_companyAccounts_companyAccountId",
                table: "BookingServices");

            migrationBuilder.DropIndex(
                name: "IX_BookingServices_companyAccountId",
                table: "BookingServices");

            migrationBuilder.AddColumn<string>(
                name: "BookingServicesIds",
                table: "jobServiceTypes",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "companyAccountId",
                table: "BookingServices",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingServicesIds",
                table: "jobServiceTypes");

            migrationBuilder.AlterColumn<int>(
                name: "companyAccountId",
                table: "BookingServices",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_BookingServices_companyAccountId",
                table: "BookingServices",
                column: "companyAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingServices_companyAccounts_companyAccountId",
                table: "BookingServices",
                column: "companyAccountId",
                principalTable: "companyAccounts",
                principalColumn: "companyAccountId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
