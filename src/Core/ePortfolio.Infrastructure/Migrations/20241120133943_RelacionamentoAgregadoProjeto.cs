using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ePortfolio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelacionamentoAgregadoProjeto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectsTags",
                table: "ProjectsTags");

            migrationBuilder.DropIndex(
                name: "IX_ProjectsTags_ProjectId",
                table: "ProjectsTags");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectsTags",
                table: "ProjectsTags",
                columns: new[] { "ProjectId", "TagId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectsTags",
                table: "ProjectsTags");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectsTags",
                table: "ProjectsTags",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsTags_ProjectId",
                table: "ProjectsTags",
                column: "ProjectId");
        }
    }
}
