using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lilgobguides.Migrations
{
    /// <inheritdoc />
    public partial class UsePostIdAsKeyForPostCategorizations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCategorizations",
                table: "PostCategorizations");

            migrationBuilder.DropIndex(
                name: "IX_PostCategorizations_PostId",
                table: "PostCategorizations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PostCategorizations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCategorizations",
                table: "PostCategorizations",
                column: "PostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCategorizations",
                table: "PostCategorizations");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "PostCategorizations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCategorizations",
                table: "PostCategorizations",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategorizations_PostId",
                table: "PostCategorizations",
                column: "PostId",
                unique: true);
        }
    }
}
