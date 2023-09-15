using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenSealWebApi.Migrations
{
    /// <inheritdoc />
    public partial class GroundWasteSensorsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroundWasteSensors",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    region_id = table.Column<int>(type: "int(11)", nullable: false),
                    image = table.Column<string>(type: "varchar(500)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ref_id = table.Column<string>(type: "varchar(500)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    created_ts = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundWasteSensors", x => x.id);
                    table.ForeignKey(
                        name: "FK_GroundWasteSensors_Regions_region_id",
                        column: x => x.region_id,
                        principalTable: "Regions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GroundWasteSensorStateLogs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ground_waste_sensor_id = table.Column<int>(type: "int(11)", nullable: false),
                    mass_kg = table.Column<float>(type: "float", nullable: false),
                    rank = table.Column<int>(type: "int", nullable: false),
                    ts = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundWasteSensorStateLogs", x => x.id);
                    table.ForeignKey(
                        name: "FK_GroundWasteSensorStateLogs_GroundWasteSensors_ground_waste_s~",
                        column: x => x.ground_waste_sensor_id,
                        principalTable: "GroundWasteSensors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GroundWasteSensorStates",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    drone_id = table.Column<int>(type: "int(11)", nullable: false),
                    ground_waste_sensor_id = table.Column<int>(type: "int(11)", nullable: false),
                    mass_kg = table.Column<float>(type: "float", nullable: false),
                    rank = table.Column<int>(type: "int", nullable: false),
                    ts = table.Column<DateTime>(type: "datetime", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroundWasteSensorStates", x => x.id);
                    table.ForeignKey(
                        name: "FK_GroundWasteSensorStates_Drones_drone_id",
                        column: x => x.drone_id,
                        principalTable: "Drones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroundWasteSensorStates_GroundWasteSensors_ground_waste_sens~",
                        column: x => x.ground_waste_sensor_id,
                        principalTable: "GroundWasteSensors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_GroundWasteSensors_ref_id",
                table: "GroundWasteSensors",
                column: "ref_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroundWasteSensors_region_id",
                table: "GroundWasteSensors",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "IX_GroundWasteSensorStateLogs_ground_waste_sensor_id",
                table: "GroundWasteSensorStateLogs",
                column: "ground_waste_sensor_id");

            migrationBuilder.CreateIndex(
                name: "IX_GroundWasteSensorStates_drone_id",
                table: "GroundWasteSensorStates",
                column: "drone_id");

            migrationBuilder.CreateIndex(
                name: "IX_GroundWasteSensorStates_ground_waste_sensor_id",
                table: "GroundWasteSensorStates",
                column: "ground_waste_sensor_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroundWasteSensorStateLogs");

            migrationBuilder.DropTable(
                name: "GroundWasteSensorStates");

            migrationBuilder.DropTable(
                name: "GroundWasteSensors");
        }
    }
}
