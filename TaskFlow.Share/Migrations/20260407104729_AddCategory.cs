using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFlow.Shared.Migrations
{
    /// <inheritdoc />
    public partial class AddCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a0000001-0000-0000-0000-000000000001"),
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a0000002-0000-0000-0000-000000000002"),
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a0000003-0000-0000-0000-000000000003"),
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a0000004-0000-0000-0000-000000000004"),
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a0000005-0000-0000-0000-000000000005"),
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a0000006-0000-0000-0000-000000000006"),
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a0000007-0000-0000-0000-000000000007"),
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a0000008-0000-0000-0000-000000000008"),
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a0000009-0000-0000-0000-000000000009"),
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: new Guid("a0000010-0000-0000-0000-000000000010"),
                column: "CategoryId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CategoryId",
                table: "Tasks",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Categories_CategoryId",
                table: "Tasks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Categories_CategoryId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CategoryId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Tasks");
        }
    }
}
