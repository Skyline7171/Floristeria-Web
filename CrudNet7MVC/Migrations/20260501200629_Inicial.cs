using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FloristeriaWeb.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flor_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipio_Departamento_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    FechaOrden = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstadoPagoId = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orden_Estado_EstadoPagoId",
                        column: x => x.EstadoPagoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenId = table.Column<int>(type: "int", nullable: false),
                    FlorId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Flor_FlorId",
                        column: x => x.FlorId,
                        principalTable: "Flor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrden_Orden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Orden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departamento",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Boaco" },
                    { 2, "Carazo" },
                    { 3, "Chinandega" },
                    { 4, "Chontales" },
                    { 5, "Estelí" },
                    { 6, "Granada" },
                    { 7, "Jinotega" },
                    { 8, "León" },
                    { 9, "Madriz" },
                    { 10, "Managua" },
                    { 11, "Masaya" },
                    { 12, "Matagalpa" },
                    { 13, "Nueva Segovia" },
                    { 14, "Río San Juan" },
                    { 15, "Rivas" },
                    { 16, "Costa Caribe Norte" },
                    { 17, "Costa Caribe Sur" }
                });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, null, "Pendiente" },
                    { 2, null, "Aprobado" },
                    { 3, null, "Rechazado" }
                });

            migrationBuilder.InsertData(
                table: "Municipio",
                columns: new[] { "Id", "DepartamentoId", "Nombre" },
                values: new object[,]
                {
                    { 1, 1, "Boaco" },
                    { 2, 1, "Camoapa" },
                    { 3, 1, "San José de los Remates" },
                    { 4, 1, "San Lorenzo" },
                    { 5, 1, "Santa Lucía" },
                    { 6, 1, "Teustepe" },
                    { 7, 2, "Jinotepe" },
                    { 8, 2, "Diriamba" },
                    { 9, 2, "San Marcos" },
                    { 10, 2, "Dolores" },
                    { 11, 2, "Santa Teresa" },
                    { 12, 2, "El Rosario" },
                    { 13, 2, "La Paz de Carazo" },
                    { 14, 2, "La Conquista" },
                    { 15, 3, "Chinandega" },
                    { 16, 3, "El Viejo" },
                    { 17, 3, "Corinto" },
                    { 18, 3, "Chichigalpa" },
                    { 19, 3, "El Realejo" },
                    { 20, 3, "Posoltega" },
                    { 21, 3, "Quezalguaque" },
                    { 22, 3, "Somotillo" },
                    { 23, 3, "Villanueva" },
                    { 24, 3, "Santo Tomás del Norte" },
                    { 25, 3, "Cinco Pinos" },
                    { 26, 3, "San Pedro del Norte" },
                    { 27, 3, "San Francisco del Norte" },
                    { 28, 4, "Juigalpa" },
                    { 29, 4, "Acoyapa" },
                    { 30, 4, "Santo Tomás" },
                    { 31, 4, "La Libertad" },
                    { 32, 4, "San Pedro de Lóvago" },
                    { 33, 4, "Santo Domingo" },
                    { 34, 4, "Villa Sandino" },
                    { 35, 4, "Comalapa" },
                    { 36, 4, "San Francisco de Cuapa" },
                    { 37, 4, "El Coral" },
                    { 38, 5, "Estelí" },
                    { 39, 5, "Condega" },
                    { 40, 5, "Pueblo Nuevo" },
                    { 41, 5, "La Trinidad" },
                    { 42, 5, "San Juan de Limay" },
                    { 43, 5, "San Nicolás" },
                    { 44, 6, "Granada" },
                    { 45, 6, "Diriá" },
                    { 46, 6, "Diriomo" },
                    { 47, 6, "Nandaime" },
                    { 48, 7, "Jinotega" },
                    { 49, 7, "Wiwilí de Jinotega" },
                    { 50, 7, "El Cuá" },
                    { 51, 7, "San José de Bocay" },
                    { 52, 7, "San Sebastián de Yalí" },
                    { 53, 7, "Santa María de Pantasma" },
                    { 54, 7, "San Rafael del Norte" },
                    { 55, 7, "La Concordia" },
                    { 56, 8, "León" },
                    { 57, 8, "Nagarote" },
                    { 58, 8, "La Paz Centro" },
                    { 59, 8, "Telica" },
                    { 60, 8, "Quezalguaque" },
                    { 61, 8, "Larreynaga" },
                    { 62, 8, "El Sauce" },
                    { 63, 8, "Achuapa" },
                    { 64, 8, "Santa Rosa del Peñón" },
                    { 65, 8, "El Jicaral" },
                    { 66, 9, "Somoto" },
                    { 67, 9, "Totogalpa" },
                    { 68, 9, "Telpaneca" },
                    { 69, 9, "San Lucas" },
                    { 70, 9, "Yalagüina" },
                    { 71, 9, "Palacagüina" },
                    { 72, 9, "San Juan de Río Coco" },
                    { 73, 9, "San José de Cusmapa" },
                    { 74, 9, "Las Sabanas" },
                    { 75, 10, "Managua" },
                    { 76, 10, "Tipitapa" },
                    { 77, 10, "Ciudad Sandino" },
                    { 78, 10, "San Rafael del Sur" },
                    { 79, 10, "Mateare" },
                    { 80, 10, "Villa El Carmen" },
                    { 81, 10, "Ticuantepe" },
                    { 82, 10, "San Francisco Libre" },
                    { 83, 10, "El Crucero" },
                    { 84, 11, "Masaya" },
                    { 85, 11, "Nindirí" },
                    { 86, 11, "Masatepe" },
                    { 87, 11, "Nandasmo" },
                    { 88, 11, "Catarina" },
                    { 89, 11, "San Juan de Oriente" },
                    { 90, 11, "Niquinohomo" },
                    { 91, 11, "Tisma" },
                    { 92, 11, "La Concepción" },
                    { 93, 12, "Matagalpa" },
                    { 94, 12, "Sébaco" },
                    { 95, 12, "San Isidro" },
                    { 96, 12, "Ciudad Darío" },
                    { 97, 12, "Terrabona" },
                    { 98, 12, "San Dionisio" },
                    { 99, 12, "Esquipulas" },
                    { 100, 12, "Muy Muy" },
                    { 101, 12, "Matiguás" },
                    { 102, 12, "Río Blanco" },
                    { 103, 12, "San Ramón" },
                    { 104, 12, "Rancho Grande" },
                    { 105, 12, "Tuma-La Dalia" },
                    { 106, 13, "Ocotal" },
                    { 107, 13, "Jalapa" },
                    { 108, 13, "Wiwilí de Nueva Segovia" },
                    { 109, 13, "Quilalí" },
                    { 110, 13, "Jícaro" },
                    { 111, 13, "Murra" },
                    { 112, 13, "San Fernando" },
                    { 113, 13, "Ciudad Antigua" },
                    { 114, 13, "Mozonte" },
                    { 115, 13, "Dipilto" },
                    { 116, 13, "Santa María" },
                    { 117, 13, "Macuelizo" },
                    { 118, 14, "San Carlos" },
                    { 119, 14, "El Castillo" },
                    { 120, 14, "San Juan del Norte" },
                    { 121, 14, "San Miguelito" },
                    { 122, 14, "El Almendro" },
                    { 123, 14, "Morrito" },
                    { 124, 15, "Rivas" },
                    { 125, 15, "San Juan del Sur" },
                    { 126, 15, "Moyogalpa" },
                    { 127, 15, "Altagracia" },
                    { 128, 15, "Tola" },
                    { 129, 15, "San Jorge" },
                    { 130, 15, "Potosí" },
                    { 131, 15, "Buenos Aires" },
                    { 132, 15, "Belén" },
                    { 133, 15, "Cárdenas" },
                    { 134, 16, "Puerto Cabezas" },
                    { 135, 16, "Waspam" },
                    { 136, 16, "Siuna" },
                    { 137, 16, "Rosita" },
                    { 138, 16, "Bonanza" },
                    { 139, 16, "Prinzapolka" },
                    { 140, 16, "Waslala" },
                    { 141, 16, "Mulukukú" },
                    { 142, 17, "Bluefields" },
                    { 143, 17, "Corn Island" },
                    { 144, 17, "Laguna de Perlas" },
                    { 145, 17, "Nueva Guinea" },
                    { 146, 17, "El Rama" },
                    { 147, 17, "Kukra Hill" },
                    { 148, 17, "La Cruz de Río Grande" },
                    { 149, 17, "Desembocadura de Río Grande" },
                    { 150, 17, "El Tortuguero" },
                    { 151, 17, "Muelle de los Bueyes" },
                    { 152, 17, "El Ayote" },
                    { 153, 17, "Paiwas" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_FlorId",
                table: "DetalleOrden",
                column: "FlorId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrden_OrdenId",
                table: "DetalleOrden",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Flor_CategoriaId",
                table: "Flor",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_DepartamentoId",
                table: "Municipio",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_EstadoPagoId",
                table: "Orden",
                column: "EstadoPagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_MunicipioId",
                table: "Orden",
                column: "MunicipioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleOrden");

            migrationBuilder.DropTable(
                name: "Flor");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Departamento");
        }
    }
}
