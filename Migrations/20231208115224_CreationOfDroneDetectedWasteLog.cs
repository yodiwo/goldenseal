using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenSealWebApi.Migrations
{
    /// <inheritdoc />
    public partial class CreationOfDroneDetectedWasteLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "georeferenced_image",
                table: "DroneDetectedWasteLogs",
                type: "varchar(500)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "wms_service",
                table: "DroneDetectedWasteLogs",
                type: "varchar(500)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "georeferenced_image",
                table: "DroneDetectedWasteLogs");

            migrationBuilder.DropColumn(
                name: "wms_service",
                table: "DroneDetectedWasteLogs");
        }
    }
}
