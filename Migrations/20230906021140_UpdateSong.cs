using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SongSearch.Migrations
{
    public partial class UpdateSong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArtistId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Album = table.Column<string>(type: "text", nullable: false),
                    Length = table.Column<string>(type: "text", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongId);
                    table.ForeignKey(
                        name: "FK_Songs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "ArtistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Songs_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId");
                });

            migrationBuilder.CreateTable(
                name: "Song_Genres",
                columns: table => new
                {
                    Song_GenreId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SongId = table.Column<int>(type: "integer", nullable: false),
                    GenreId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song_Genres", x => x.Song_GenreId);
                    table.ForeignKey(
                        name: "FK_Song_Genres_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "SongId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "Age", "Bio", "Name" },
                values: new object[,]
                {
                    { 101, 19, "The Classic Crime is an American rock band from Seattle, Washington, formed in 2004.", "The Classic Crime" },
                    { 102, 7, "The Amazing Devil is a dramatic, lyrical alt-folk band formed by Joey Batey and Madeleine Hyland.", "The Amazing Devil" },
                    { 103, 19, "Bring Me the Horizon are a British rock band, formed in Sheffield in 2004.", "Bring Me The Horizon" },
                    { 104, 16, "Machine Gun Kelly is an American rapper, singer, songwriter, musician, and actor.", "Machine Gun Kelly" },
                    { 105, 13, "Is an English singer and actor. His musical career began in 2010 as part of a boy band, One Direction.", "Harry Styles" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Description" },
                values: new object[,]
                {
                    { 401, "Alternative Rock" },
                    { 402, "Screamo" },
                    { 403, "Pop" },
                    { 404, "Hip Hop" },
                    { 405, "Pop Punk" },
                    { 406, "Alternative Folk" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "SongId", "Album", "ArtistId", "GenreId", "Length", "Title" },
                values: new object[,]
                {
                    { 2001, "The Horror and The Wild", 102, null, "5:23", "Welly Boots" },
                    { 2002, "Harry's House", 105, null, "2:57", "Late Night Talking" },
                    { 2003, "The Silver Chord", 101, null, "5:34", "Salt in the Snow" },
                    { 2004, "That's the Spirit", 103, null, "4:34", "Doomed" },
                    { 2005, "Mainstream Sellout", 104, null, "1:47", "mainstream sellout" },
                    { 2006, "POST HUMAN: SURVIVAL HORROR", 103, null, "2:44", "Dear Diary," },
                    { 2007, "Ruin", 102, null, "6:09", "The Calling" },
                    { 2008, "Fine Line", 105, null, "3:09", "Canyon Moon" },
                    { 2009, "How to be Human", 101, null, "5:15", "Black & White" },
                    { 2010, "El Diablo", 104, null, "2:03", "Sex Drive" }
                });

            migrationBuilder.InsertData(
                table: "Song_Genres",
                columns: new[] { "Song_GenreId", "GenreId", "SongId" },
                values: new object[,]
                {
                    { 301, 406, 2001 },
                    { 302, 403, 2002 },
                    { 303, 401, 2003 },
                    { 304, 402, 2004 },
                    { 305, 405, 2005 },
                    { 306, 402, 2006 },
                    { 307, 406, 2007 },
                    { 308, 403, 2008 },
                    { 309, 401, 2009 },
                    { 310, 404, 2010 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_Genres_SongId",
                table: "Song_Genres",
                column: "SongId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GenreId",
                table: "Songs",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song_Genres");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
