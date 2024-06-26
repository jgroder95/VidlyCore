using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VidlyCore.Migrations
{
    /// <inheritdoc />
    public partial class PopulateGenreTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT genreTypes ON;");
            migrationBuilder.Sql("INSERT INTO genreTypes (Id, GenreName) VALUES (1, 'Action')");
            migrationBuilder.Sql("INSERT INTO genreTypes (Id, GenreName) VALUES (2, 'Thriller')");
            migrationBuilder.Sql("INSERT INTO genreTypes (Id, GenreName) VALUES (3, 'Family')");
            migrationBuilder.Sql("INSERT INTO genreTypes (Id, GenreName) VALUES (4, 'Romance')");
            migrationBuilder.Sql("INSERT INTO genreTypes (Id, GenreName) VALUES (5, 'Comedy')");
            migrationBuilder.Sql("SET IDENTITY_INSERT genreTypes OFF;");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
