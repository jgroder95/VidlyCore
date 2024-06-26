using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidlyCore.Migrations
{
    /// <inheritdoc />
    public partial class AddGenreTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreTypeId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GenreTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreTypeId",
                table: "Movies",
                column: "GenreTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_GenreTypes_GenreTypeId",
                table: "Movies",
                column: "GenreTypeId",
                principalTable: "GenreTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_GenreTypes_GenreTypeId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "GenreTypes");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreTypeId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenreTypeId",
                table: "Movies");
        }
    }
}
