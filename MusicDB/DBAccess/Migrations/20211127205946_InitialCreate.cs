using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistSongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    SongId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistSongs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistSongs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "DateOfBirth", "Email", "InstagramUrl", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(1942, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "PaulMcC@gmail.com", "www.instagram.com/paulmccartney", "Paul McCartney", "+4382836323" },
                    { 2, new DateTime(1963, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "TillLindemann@gmail.com", "www.instagram.com/till_lindemann_official", "Till Lendemann", "+5843893993" },
                    { 3, new DateTime(1986, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "LadyGaga@gmail.com", "www.instagram.com/ladygaga", "Lady Gaga", "+4347823742" },
                    { 4, new DateTime(1972, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eminem@gmail.com", "www.instagram.com/eminem", "Eminem", "+53457349587" },
                    { 5, new DateTime(1988, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adele@gmail.com", "www.instagram.com/adele", "Adele", "+42348789233" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Rap" },
                    { 2, "Rock" },
                    { 3, "Pop" },
                    { 4, "Hip hop" },
                    { 5, "Electronic" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "Duration", "GenreId", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 323, 1, new DateTime(2002, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lose Yourself" },
                    { 4, 235, 2, new DateTime(1997, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Du Hast" },
                    { 5, 131, 2, new DateTime(1966, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eleanor Rigby" },
                    { 2, 308, 3, new DateTime(2009, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bad Romance" },
                    { 3, 366, 3, new DateTime(2015, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hello" }
                });

            migrationBuilder.InsertData(
                table: "ArtistSongs",
                columns: new[] { "Id", "ArtistId", "SongId" },
                values: new object[,]
                {
                    { 4, 4, 1 },
                    { 2, 2, 4 },
                    { 1, 1, 5 },
                    { 3, 3, 2 },
                    { 5, 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSongs_ArtistId",
                table: "ArtistSongs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSongs_SongId",
                table: "ArtistSongs",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistSongs");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
