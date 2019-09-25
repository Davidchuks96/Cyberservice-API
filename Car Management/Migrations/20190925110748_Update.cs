using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Car_Management.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OverallServices_Services_ServiceId",
                table: "OverallServices");

            migrationBuilder.DropTable(
                name: "HackneyPermits");

            migrationBuilder.DropTable(
                name: "Issurances");

            migrationBuilder.DropTable(
                name: "RoadWorthinesses");

            migrationBuilder.DropTable(
                name: "VehicleLicenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OverallServices",
                table: "OverallServices");

            migrationBuilder.RenameTable(
                name: "OverallServices",
                newName: "Overall");

            migrationBuilder.RenameIndex(
                name: "IX_OverallServices_ServiceId",
                table: "Overall",
                newName: "IX_Overall_ServiceId");

            migrationBuilder.AddColumn<DateTime>(
                name: "HackneyExpirationDate",
                table: "Vehicles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HackneyPermitIssuedDate",
                table: "Vehicles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "IssuranceExpirationDate",
                table: "Vehicles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "IssuranceIssuedDate",
                table: "Vehicles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RoadWorthinessExpirationDate",
                table: "Vehicles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RoadWorthinessIssuedDate",
                table: "Vehicles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "VehicleLicenseExpirationDate",
                table: "Vehicles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "VehicleLicenseIssuedDate",
                table: "Vehicles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Overall",
                table: "Overall",
                column: "OverallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Overall_Services_ServiceId",
                table: "Overall",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Overall_Services_ServiceId",
                table: "Overall");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Overall",
                table: "Overall");

            migrationBuilder.DropColumn(
                name: "HackneyExpirationDate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "HackneyPermitIssuedDate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "IssuranceExpirationDate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "IssuranceIssuedDate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "RoadWorthinessExpirationDate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "RoadWorthinessIssuedDate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleLicenseExpirationDate",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleLicenseIssuedDate",
                table: "Vehicles");

            migrationBuilder.RenameTable(
                name: "Overall",
                newName: "OverallServices");

            migrationBuilder.RenameIndex(
                name: "IX_Overall_ServiceId",
                table: "OverallServices",
                newName: "IX_OverallServices_ServiceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OverallServices",
                table: "OverallServices",
                column: "OverallId");

            migrationBuilder.CreateTable(
                name: "HackneyPermits",
                columns: table => new
                {
                    HackneyPermitId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    H_Status = table.Column<int>(nullable: false),
                    IssuedDate = table.Column<DateTime>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HackneyPermits", x => x.HackneyPermitId);
                    table.ForeignKey(
                        name: "FK_HackneyPermits_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Issurances",
                columns: table => new
                {
                    IssuranceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    H_Status = table.Column<int>(nullable: false),
                    IssuedDate = table.Column<DateTime>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issurances", x => x.IssuranceId);
                    table.ForeignKey(
                        name: "FK_Issurances_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoadWorthinesses",
                columns: table => new
                {
                    RoadWorthinessId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    H_Status = table.Column<int>(nullable: false),
                    IssuedDate = table.Column<DateTime>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadWorthinesses", x => x.RoadWorthinessId);
                    table.ForeignKey(
                        name: "FK_RoadWorthinesses_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleLicenses",
                columns: table => new
                {
                    VehicleLicenseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    H_Status = table.Column<int>(nullable: false),
                    IssuedDate = table.Column<DateTime>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleLicenses", x => x.VehicleLicenseId);
                    table.ForeignKey(
                        name: "FK_VehicleLicenses_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HackneyPermits_VehicleId",
                table: "HackneyPermits",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Issurances_VehicleId",
                table: "Issurances",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoadWorthinesses_VehicleId",
                table: "RoadWorthinesses",
                column: "VehicleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleLicenses_VehicleId",
                table: "VehicleLicenses",
                column: "VehicleId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OverallServices_Services_ServiceId",
                table: "OverallServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
