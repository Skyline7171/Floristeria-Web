using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloristeriaWeb.Migrations
{
    /// <inheritdoc />
    public partial class NombreEspecificosClientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NombreCliente",
                table: "Orden",
                newName: "NombreDestinatario");

            migrationBuilder.AddColumn<string>(
                name: "ApellidoDestinatario",
                table: "Orden",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApellidoDestinatario",
                table: "Orden");

            migrationBuilder.RenameColumn(
                name: "NombreDestinatario",
                table: "Orden",
                newName: "NombreCliente");
        }
    }
}
