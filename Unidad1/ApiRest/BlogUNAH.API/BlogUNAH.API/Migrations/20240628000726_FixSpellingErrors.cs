using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogUNAH.API.Migrations
{
    /// <inheritdoc />
    public partial class FixSpellingErrors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tittle",
                schema: "dbo",
                table: "posts",
                newName: "title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                schema: "dbo",
                table: "posts",
                newName: "tittle");
        }
    }
}
