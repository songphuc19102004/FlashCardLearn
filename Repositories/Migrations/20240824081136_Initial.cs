using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlashCardSet",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    title = table.Column<string>(type: "TEXT", unicode: false, maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    progress = table.Column<int>(type: "INTEGER", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FlashCar__3213E83FE1539727", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FlashCard",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    question = table.Column<string>(type: "TEXT", unicode: false, maxLength: 255, nullable: false),
                    answer = table.Column<string>(type: "text", nullable: false),
                    flashcardset_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FlashCar__3213E83F666D7250", x => x.id);
                    table.ForeignKey(
                        name: "FK__FlashCard__flash__267ABA7A",
                        column: x => x.flashcardset_id,
                        principalTable: "FlashCardSet",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlashCard_flashcardset_id",
                table: "FlashCard",
                column: "flashcardset_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlashCard");

            migrationBuilder.DropTable(
                name: "FlashCardSet");
        }
    }
}
