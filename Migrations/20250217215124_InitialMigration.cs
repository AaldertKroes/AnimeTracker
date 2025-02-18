using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AnimeTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anime", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ListSelf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimeId = table.Column<int>(type: "INTEGER", nullable: true),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: true),
                    Watched = table.Column<bool>(type: "INTEGER", nullable: false),
                    Rating = table.Column<float>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListSelf", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListSelf_Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListSelf_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListTogether",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimeId = table.Column<int>(type: "INTEGER", nullable: true),
                    MovieId = table.Column<int>(type: "INTEGER", nullable: true),
                    People = table.Column<string>(type: "TEXT", nullable: false),
                    Watched = table.Column<bool>(type: "INTEGER", nullable: false),
                    Rating = table.Column<float>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListTogether", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListTogether_Anime_AnimeId",
                        column: x => x.AnimeId,
                        principalTable: "Anime",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListTogether_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QueueSelf",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ListSelfId = table.Column<int>(type: "INTEGER", nullable: false),
                    ListSelfDTOId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueSelf", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueueSelf_ListSelf_ListSelfDTOId",
                        column: x => x.ListSelfDTOId,
                        principalTable: "ListSelf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QueueTogether",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QueueTogetherId = table.Column<int>(type: "INTEGER", nullable: false),
                    ListTogetherDTOId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QueueTogether", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QueueTogether_ListTogether_ListTogetherDTOId",
                        column: x => x.ListTogetherDTOId,
                        principalTable: "ListTogether",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListSelf_AnimeId",
                table: "ListSelf",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListSelf_MovieId",
                table: "ListSelf",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ListTogether_AnimeId",
                table: "ListTogether",
                column: "AnimeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListTogether_MovieId",
                table: "ListTogether",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_QueueSelf_ListSelfDTOId",
                table: "QueueSelf",
                column: "ListSelfDTOId");

            migrationBuilder.CreateIndex(
                name: "IX_QueueTogether_ListTogetherDTOId",
                table: "QueueTogether",
                column: "ListTogetherDTOId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QueueSelf");

            migrationBuilder.DropTable(
                name: "QueueTogether");

            migrationBuilder.DropTable(
                name: "ListSelf");

            migrationBuilder.DropTable(
                name: "ListTogether");

            migrationBuilder.DropTable(
                name: "Anime");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
