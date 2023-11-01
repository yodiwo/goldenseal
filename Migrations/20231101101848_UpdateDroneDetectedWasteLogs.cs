using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenSealWebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDroneDetectedWasteLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "DroneDetectedWasteLogs",
                type: "varchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "DroneDetectedWasteLogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "confidence_level",
                table: "DroneDetectedWasteLogs",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                table: "DroneDetectedWasteLogs");

            migrationBuilder.DropColumn(
                name: "confidence_level",
                table: "DroneDetectedWasteLogs");

            migrationBuilder.UpdateData(
                table: "DroneDetectedWasteLogs",
                keyColumn: "image",
                keyValue: null,
                column: "image",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "image",
                table: "DroneDetectedWasteLogs",
                type: "varchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
