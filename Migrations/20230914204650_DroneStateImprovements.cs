using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenSealWebApi.Migrations
{
    /// <inheritdoc />
    public partial class DroneStateImprovements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "geojson",
                table: "DroneStates");

            migrationBuilder.DropColumn(
                name: "velocity",
                table: "DroneStates");

            migrationBuilder.DropColumn(
                name: "geojson",
                table: "DroneStateLogs");

            migrationBuilder.DropColumn(
                name: "velocity",
                table: "DroneStateLogs");

            migrationBuilder.AlterColumn<float>(
                name: "battery",
                table: "DroneStates",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AddColumn<long>(
                name: "altitude",
                table: "DroneStates",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "latitude",
                table: "DroneStates",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "longitude",
                table: "DroneStates",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "velocity_x",
                table: "DroneStates",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "velocity_y",
                table: "DroneStates",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "velocity_z",
                table: "DroneStates",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "battery",
                table: "DroneStateLogs",
                type: "float",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "float");

            migrationBuilder.AddColumn<long>(
                name: "altitude",
                table: "DroneStateLogs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "latitude",
                table: "DroneStateLogs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "longitude",
                table: "DroneStateLogs",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "velocity_x",
                table: "DroneStateLogs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "velocity_y",
                table: "DroneStateLogs",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "velocity_z",
                table: "DroneStateLogs",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "altitude",
                table: "DroneStates");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "DroneStates");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "DroneStates");

            migrationBuilder.DropColumn(
                name: "velocity_x",
                table: "DroneStates");

            migrationBuilder.DropColumn(
                name: "velocity_y",
                table: "DroneStates");

            migrationBuilder.DropColumn(
                name: "velocity_z",
                table: "DroneStates");

            migrationBuilder.DropColumn(
                name: "altitude",
                table: "DroneStateLogs");

            migrationBuilder.DropColumn(
                name: "latitude",
                table: "DroneStateLogs");

            migrationBuilder.DropColumn(
                name: "longitude",
                table: "DroneStateLogs");

            migrationBuilder.DropColumn(
                name: "velocity_x",
                table: "DroneStateLogs");

            migrationBuilder.DropColumn(
                name: "velocity_y",
                table: "DroneStateLogs");

            migrationBuilder.DropColumn(
                name: "velocity_z",
                table: "DroneStateLogs");

            migrationBuilder.AlterColumn<float>(
                name: "battery",
                table: "DroneStates",
                type: "float",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "geojson",
                table: "DroneStates",
                type: "varchar(500)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "velocity",
                table: "DroneStates",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<float>(
                name: "battery",
                table: "DroneStateLogs",
                type: "float",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "geojson",
                table: "DroneStateLogs",
                type: "varchar(500)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<float>(
                name: "velocity",
                table: "DroneStateLogs",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
