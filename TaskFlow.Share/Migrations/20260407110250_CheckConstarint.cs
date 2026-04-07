using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFlow.Shared.Migrations
{
    /// <inheritdoc />
    public partial class CheckConstarint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Tasks_DueDate_Future",
                table: "Tasks",
                sql: "[DueDate] >= [CreatedDate]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Tasks_DueDate_Future",
                table: "Tasks");
        }
    }
}
