﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenSealWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRegionArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "area",
                table: "Regions",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "area",
                table: "Regions");
        }
    }
}
