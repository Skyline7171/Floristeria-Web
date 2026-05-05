using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FloristeriaWeb.Migrations
{
    /// <inheritdoc />
    public partial class nuevosEstados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "En preparación");

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nombre",
                value: "En camino");

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 4, null, "Entregado" },
                    { 5, null, "Cancelado" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 2,
                column: "Nombre",
                value: "Aprobado");

            migrationBuilder.UpdateData(
                table: "Estado",
                keyColumn: "Id",
                keyValue: 3,
                column: "Nombre",
                value: "Rechazado");
        }
    }
}
