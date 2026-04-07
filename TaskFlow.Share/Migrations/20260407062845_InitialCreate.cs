using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskFlow.Shared.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "CreatedDate", "Description", "DueDate", "Priority", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("a0000001-0000-0000-0000-000000000001"), new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Write comprehensive documentation for all API endpoints including request/response examples", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, "Complete API Documentation" },
                    { new Guid("a0000002-0000-0000-0000-000000000002"), new DateTime(2025, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resolve the JWT token expiration issue in the login endpoint", new DateTime(2025, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, "Fix Authentication Bug" },
                    { new Guid("a0000003-0000-0000-0000-000000000003"), new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Add unit tests for the TaskService class with 90% code coverage", new DateTime(2025, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, "Implement Unit Tests" },
                    { new Guid("a0000004-0000-0000-0000-000000000004"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Update all outdated NuGet packages to latest stable versions", new DateTime(2025, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Update NuGet Packages" },
                    { new Guid("a0000005-0000-0000-0000-000000000005"), new DateTime(2025, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review and optimize slow-performing database queries", new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "Optimize Database Queries" },
                    { new Guid("a0000006-0000-0000-0000-000000000006"), new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Create reusable UI components for the task management dashboard", new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, "Design New UI Components" },
                    { new Guid("a0000007-0000-0000-0000-000000000007"), new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Review pull requests from team members and provide feedback", new DateTime(2025, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, "Code Review Session" },
                    { new Guid("a0000008-0000-0000-0000-000000000008"), new DateTime(2025, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deploy latest version to production environment with zero downtime", new DateTime(2025, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, "Deploy to Production" },
                    { new Guid("a0000009-0000-0000-0000-000000000009"), new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Document all changes and features for the upcoming v2.0 release", new DateTime(2025, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, "Write Release Notes" },
                    { new Guid("a0000010-0000-0000-0000-000000000010"), new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Perform security audit and vulnerability assessment", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "Security Audit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
