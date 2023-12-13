using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenSealWebApi.Migrations
{
    /// <inheritdoc />
    public partial class DetectedWasteLogCreations_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "DroneDetectedWasteLogs");

            migrationBuilder.RenameColumn(
                name: "geojson",
                table: "DroneDetectedWasteLogs",
                newName: "bb_polygon_geojson");

            migrationBuilder.AddColumn<int>(
                name: "region_id",
                table: "DroneStates",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "region_id",
                table: "DroneStateLogs",
                type: "int(11)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bb_point_geojson",
                table: "DroneDetectedWasteLogs",
                type: "varchar(500)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "cmlo_upload_id",
                table: "DroneDetectedWasteLogs",
                type: "int(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "upload_confidence_level",
                table: "DroneDetectedWasteLogs",
                type: "float",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DroneStates_region_id",
                table: "DroneStates",
                column: "region_id");

            migrationBuilder.CreateIndex(
                name: "IX_DroneStateLogs_region_id",
                table: "DroneStateLogs",
                column: "region_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DroneStateLogs_Routes_region_id",
                table: "DroneStateLogs",
                column: "region_id",
                principalTable: "Routes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DroneStates_Routes_region_id",
                table: "DroneStates",
                column: "region_id",
                principalTable: "Routes",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DroneStateLogs_Routes_region_id",
                table: "DroneStateLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_DroneStates_Routes_region_id",
                table: "DroneStates");

            migrationBuilder.DropIndex(
                name: "IX_DroneStates_region_id",
                table: "DroneStates");

            migrationBuilder.DropIndex(
                name: "IX_DroneStateLogs_region_id",
                table: "DroneStateLogs");

            migrationBuilder.DropColumn(
                name: "region_id",
                table: "DroneStates");

            migrationBuilder.DropColumn(
                name: "region_id",
                table: "DroneStateLogs");

            migrationBuilder.DropColumn(
                name: "bb_point_geojson",
                table: "DroneDetectedWasteLogs");

            migrationBuilder.DropColumn(
                name: "cmlo_upload_id",
                table: "DroneDetectedWasteLogs");

            migrationBuilder.DropColumn(
                name: "upload_confidence_level",
                table: "DroneDetectedWasteLogs");

            migrationBuilder.RenameColumn(
                name: "bb_polygon_geojson",
                table: "DroneDetectedWasteLogs",
                newName: "geojson");

            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "DroneDetectedWasteLogs",
                type: "int",
                nullable: true);
        }
    }
}
