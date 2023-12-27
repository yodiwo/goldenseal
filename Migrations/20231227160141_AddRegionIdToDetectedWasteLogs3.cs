using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenSealWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRegionIdToDetectedWasteLogs3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "region_id",
                table: "DroneDetectedWasteLogs",
                type: "int(11)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DroneDetectedWasteLogs_region_id",
                table: "DroneDetectedWasteLogs",
                column: "region_id");

            migrationBuilder.AddForeignKey(
                name: "FK_DroneDetectedWasteLogs_Regions_region_id",
                table: "DroneDetectedWasteLogs",
                column: "region_id",
                principalTable: "Regions",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DroneDetectedWasteLogs_Regions_region_id",
                table: "DroneDetectedWasteLogs");

            migrationBuilder.DropIndex(
                name: "IX_DroneDetectedWasteLogs_region_id",
                table: "DroneDetectedWasteLogs");

            migrationBuilder.DropColumn(
                name: "region_id",
                table: "DroneDetectedWasteLogs");
        }
    }
}
