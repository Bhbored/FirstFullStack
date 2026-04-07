using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFlow.Shared.Migrations
{
    /// <inheritdoc />
    public partial class sp_GetTasksByPriority : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetTasksByPriority = @"
      CREATE PROCEDURE [dbo].[GetTasksByPriority]
    @Priority INT
AS
BEGIN
    SELECT * FROM [dbo].[Tasks] WHERE Priority = @Priority
END
        ";

            migrationBuilder.Sql(sp_GetTasksByPriority);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetTasksByPriority = @"
       DROP PROCEDURE [dbo].[GetTasksByPriority]
        ";

            migrationBuilder.Sql(sp_GetTasksByPriority);
        }
    }
}
