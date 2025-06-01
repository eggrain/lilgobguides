using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lilgobguides.Migrations
{
    /// <inheritdoc />
    public partial class AddCategorizationForPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Posts",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<string>(
                name: "CategorizationId",
                table: "Posts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PostCategorization",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Skilling = table.Column<bool>(type: "INTEGER", nullable: false),
                    Minigame = table.Column<bool>(type: "INTEGER", nullable: false),
                    Item = table.Column<bool>(type: "INTEGER", nullable: false),
                    Boss = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategorization", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostCategorization_CategorizationId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "PostCategorization");

            migrationBuilder.DropIndex(
                name: "IX_Posts_CategorizationId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "CategorizationId",
                table: "Posts");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
