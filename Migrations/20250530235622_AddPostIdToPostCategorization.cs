using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lilgobguides.Migrations
{
    /// <inheritdoc />
    public partial class AddPostIdToPostCategorization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostCategorization_CategorizationId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategorizationId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CategorizationId",
                table: "Posts");

            migrationBuilder.AddColumn<string>(
                name: "PostId",
                table: "PostCategorization",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PostCategorization_PostId",
                table: "PostCategorization",
                column: "PostId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PostCategorization_Posts_PostId",
                table: "PostCategorization",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostCategorization_Posts_PostId",
                table: "PostCategorization");

            migrationBuilder.DropIndex(
                name: "IX_PostCategorization_PostId",
                table: "PostCategorization");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "PostCategorization");

            migrationBuilder.AddColumn<string>(
                name: "CategorizationId",
                table: "Posts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategorizationId",
                table: "Posts",
                column: "CategorizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostCategorization_CategorizationId",
                table: "Posts",
                column: "CategorizationId",
                principalTable: "PostCategorization",
                principalColumn: "Id");
        }
    }
}
