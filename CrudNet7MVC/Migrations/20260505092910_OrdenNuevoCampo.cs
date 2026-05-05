using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloristeriaWeb.Migrations
{
    /// <inheritdoc />
    public partial class OrdenNuevoCampo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId",
                table: "Orden",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Orden");
        }
    }
}
