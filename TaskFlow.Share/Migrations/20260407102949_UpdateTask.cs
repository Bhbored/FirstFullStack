using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFlow.Shared.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstimatedHours",
                table: "Tasks",
                type: "INT",
                nullable: false,
                defaultValue: 1);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedHours",
                table: "Tasks");
        }
    }
}
