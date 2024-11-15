using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ePortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TrocadoImageUrlParaPath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Images",
                newName: "Path");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "Images",
                newName: "Url");
        }
    }
}
