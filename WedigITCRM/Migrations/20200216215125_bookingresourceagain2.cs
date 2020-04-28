using Microsoft.EntityFrameworkCore.Migrations;

namespace WedigITCRM.Migrations
{
    public partial class bookingresourceagain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_jobServiceTypes_BookingResources_BookingResourceId",
                table: "jobServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_jobServiceTypes_BookingResourceId",
                table: "jobServiceTypes");

            migrationBuilder.DropColumn(
                name: "BookingResourceId",
                table: "jobServiceTypes");

            migrationBuilder.AddColumn<string>(
                name: "JobServiceTypes",
                table: "BookingResources",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobServiceTypes",
                table: "BookingResources");

            migrationBuilder.AddColumn<int>(
                name: "BookingResourceId",
                table: "jobServiceTypes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_jobServiceTypes_BookingResourceId",
                table: "jobServiceTypes",
                column: "BookingResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_jobServiceTypes_BookingResources_BookingResourceId",
                table: "jobServiceTypes",
                column: "BookingResourceId",
                principalTable: "BookingResources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
