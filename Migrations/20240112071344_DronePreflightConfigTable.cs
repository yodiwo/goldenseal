using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenSealWebApi.Migrations
{
    /// <inheritdoc />
    public partial class DronePreflightConfigTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DronePreflightConfig",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    drone_id = table.Column<int>(type: "int(11)", nullable: false),
                    pilot_id = table.Column<int>(type: "int(11)", nullable: true),
                    route_id = table.Column<int>(type: "int(11)", nullable: true),
                    region_id = table.Column<int>(type: "int(11)", nullable: false),
                    altitude = table.Column<long>(type: "bigint", nullable: true),
                    ts = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DronePreflightConfig", x => x.id);
                    table.ForeignKey(
                        name: "FK_DronePreflightConfig_Drones_drone_id",
                        column: x => x.drone_id,
                        principalTable: "Drones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DronePreflightConfig_Regions_region_id",
                        column: x => x.region_id,
                        principalTable: "Regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DronePreflightConfig_Routes_route_id",
                        column: x => x.route_id,
                        principalTable: "Routes",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_DronePreflightConfig_Users_pilot_id",
                        column: x => x.pilot_id,
                        principalTable: "Users",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DronePreflightConfig_drone_id",
                table: "DronePreflightConfig",
                column: "drone_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DronePreflightConfig_pilot_id",
                table: "DronePreflightConfig",
                column: "pilot_id");

            migrationBuilder.CreateIndex(
                name: "IX_DronePreflightConfig_region_id",
                table: "DronePreflightConfig",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "IX_DronePreflightConfig_route_id",
                table: "DronePreflightConfig",
                column: "route_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DronePreflightConfig");
        }
    }
}
