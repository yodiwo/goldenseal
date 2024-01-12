using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenSealWebApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRoutesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DronePreflightConfig_Routes_route_id",
                table: "DronePreflightConfig");

            migrationBuilder.DropForeignKey(
                name: "FK_DroneStateLogs_Routes_route_id",
                table: "DroneStateLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_DroneStates_Routes_route_id",
                table: "DroneStates");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_DroneStates_route_id",
                table: "DroneStates");

            migrationBuilder.DropIndex(
                name: "IX_DroneStateLogs_route_id",
                table: "DroneStateLogs");

            migrationBuilder.DropIndex(
                name: "IX_DronePreflightConfig_route_id",
                table: "DronePreflightConfig");

            migrationBuilder.DropColumn(
                name: "route_id",
                table: "DroneStates");

            migrationBuilder.DropColumn(
                name: "route_id",
                table: "DroneStateLogs");

            migrationBuilder.DropColumn(
                name: "route_id",
                table: "DronePreflightConfig");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "route_id",
                table: "DroneStates",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "route_id",
                table: "DroneStateLogs",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "route_id",
                table: "DronePreflightConfig",
                type: "int(11)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    region_id = table.Column<int>(type: "int(11)", nullable: true),
                    created_ts = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    geojson = table.Column<string>(type: "varchar(500)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Routes_Regions_region_id",
                        column: x => x.region_id,
                        principalTable: "Regions",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DroneStates_route_id",
                table: "DroneStates",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_DroneStateLogs_route_id",
                table: "DroneStateLogs",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_DronePreflightConfig_route_id",
                table: "DronePreflightConfig",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_name",
                table: "Routes",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_region_id",
                table: "Routes",
                column: "region_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DronePreflightConfig_Routes_route_id",
                table: "DronePreflightConfig",
                column: "route_id",
                principalTable: "Routes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DroneStateLogs_Routes_route_id",
                table: "DroneStateLogs",
                column: "route_id",
                principalTable: "Routes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DroneStates_Routes_route_id",
                table: "DroneStates",
                column: "route_id",
                principalTable: "Routes",
                principalColumn: "id");
        }
    }
}
