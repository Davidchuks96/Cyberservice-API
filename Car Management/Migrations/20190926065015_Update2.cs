using Microsoft.EntityFrameworkCore.Migrations;

namespace Car_Management.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Overall_Services_ServiceId",
                table: "Overall");

            migrationBuilder.DropIndex(
                name: "IX_Overall_ServiceId",
                table: "Overall");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Overall");

            migrationBuilder.AddColumn<int>(
                name: "OverallId",
                table: "Services",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Services_OverallId",
                table: "Services",
                column: "OverallId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Overall_OverallId",
                table: "Services",
                column: "OverallId",
                principalTable: "Overall",
                principalColumn: "OverallId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Overall_OverallId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_OverallId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "OverallId",
                table: "Services");

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Overall",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Overall_ServiceId",
                table: "Overall",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Overall_Services_ServiceId",
                table: "Overall",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
