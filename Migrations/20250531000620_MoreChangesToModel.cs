using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lilgobguides.Migrations
{
    /// <inheritdoc />
    public partial class MoreChangesToModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategorization_Posts_PostId",
                table: "PostCategorization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCategorization",
                table: "PostCategorization");

            migrationBuilder.RenameTable(
                name: "PostCategorization",
                newName: "PostCategorizations");

            migrationBuilder.RenameIndex(
                name: "IX_PostCategorization_PostId",
                table: "PostCategorizations",
                newName: "IX_PostCategorizations_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCategorizations",
                table: "PostCategorizations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategorizations_Posts_PostId",
                table: "PostCategorizations",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategorizations_Posts_PostId",
                table: "PostCategorizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostCategorizations",
                table: "PostCategorizations");

            migrationBuilder.RenameTable(
                name: "PostCategorizations",
                newName: "PostCategorization");

            migrationBuilder.RenameIndex(
                name: "IX_PostCategorizations_PostId",
                table: "PostCategorization",
                newName: "IX_PostCategorization_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostCategorization",
                table: "PostCategorization",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategorization_Posts_PostId",
                table: "PostCategorization",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
