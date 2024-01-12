using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenSealWebApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRankingFieldFromGroundSensors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroundWasteSensorStates_Drones_drone_id",
                table: "GroundWasteSensorStates");

            migrationBuilder.DropIndex(
                name: "IX_GroundWasteSensorStates_drone_id",
                table: "GroundWasteSensorStates");

            migrationBuilder.DropColumn(
                name: "drone_id",
                table: "GroundWasteSensorStates");

            migrationBuilder.DropColumn(
                name: "rank",
                table: "GroundWasteSensorStates");

            migrationBuilder.DropColumn(
                name: "rank",
                table: "GroundWasteSensorStateLogs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "drone_id",
                table: "GroundWasteSensorStates",
                type: "int(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "rank",
                table: "GroundWasteSensorStates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "rank",
                table: "GroundWasteSensorStateLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GroundWasteSensorStates_drone_id",
                table: "GroundWasteSensorStates",
                column: "drone_id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroundWasteSensorStates_Drones_drone_id",
                table: "GroundWasteSensorStates",
                column: "drone_id",
                principalTable: "Drones",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
