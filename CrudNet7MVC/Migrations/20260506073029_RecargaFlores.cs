using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FloristeriaWeb.Migrations
{
    /// <inheritdoc />
    public partial class RecargaFlores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Activo", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Coronas, cruces y arreglos solemnes de condolencias.", "Arreglos Fúnebres" },
                    { 2, true, "Ramos elegantes diseñados para expresar amor y aniversario.", "Ramos Románticos" },
                    { 3, true, "Arreglos alegres y coloridos para celebraciones especiales.", "Detalles de Cumpleaños" },
                    { 4, true, "Plantas vivas y flores exóticas para interiores y decoración duradera.", "Plantas Exóticas" }
                });

            migrationBuilder.InsertData(
                table: "Flor",
                columns: new[] { "Id", "Activo", "CategoriaId", "Descripcion", "ImagenUrl", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, true, 1, "Elegante corona fúnebre con lirios blancos, rosas y follaje fino.", "https://cdnx.jumpseller.com/floresensantiago/image/64518186/thumb/300/300?1750020573", "Corona de Condolencias Imperial", 2450.00m, 10 },
                    { 2, true, 1, "Arreglo solemne en forma de cruz elaborado con claveles y rosas blancas.", "https://www.yaakunflores.com/uploads/arreglos/cruz-eterno-descanso.jpg", "Cruz del Eterno Descanso", 1800.00m, 8 },
                    { 3, true, 1, "Almohadón floral fúnebre con crisantemos blancos y acentos de lila.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSO2y9GVpniMB2Fmy26Ptsp0aSjl-J0NmtNWA&s", "Cojín de Crisantemos y Lirios", 1200.00m, 15 },
                    { 4, true, 2, "Clásico y majestuoso ramo de rosas rojas de tallo largo con envoltura de lujo.", "https://ponchycaprico.com/cdn/shop/files/RR003_24_cc29830d-f44b-4533-ab54-d9de13384b0b.jpg?v=1760662544&width=1946", "Ramo de 24 Rosas Rojas Premium", 1500.00m, 30 },
                    { 5, true, 2, "Caja premium en forma de corazón rellena de rosas rojas y bombones.", "https://www.floreriabloom.com/cdn/shop/files/arreglo-romantico-rosas-rojas-chocolates-bombones-delivery-lima.jpg?v=1775691296&width=2048", "Caja Corazón Romántico", 1950.00m, 12 },
                    { 6, true, 2, "Combinación delicada de rosas rosadas, astromelias y hortensias blancas.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR-XYaOTgZOnDhOapcBiwAoc5Sa4jnaYdqW-g&s", "Ramo Suspiro de Amor", 950.00m, 20 },
                    { 7, true, 2, "Fino ramo de tulipanes importados en tonos pastel perfectos para aniversarios.", "https://i.etsystatic.com/51995127/r/il/db9c41/6747189706/il_fullxfull.6747189706_56d6.jpg", "Eternidad de Tulipanes", 1750.00m, 6 },
                    { 8, true, 3, "Arreglo vibrante con aves del paraíso, gerberas brillantes y lirios amarillos.", "https://static.wixstatic.com/media/59f71b_e269d3d9c4384e9dbb533e1c36d4a982~mv2.jpg/v1/fill/w_480,h_480,al_c,q_80,usm_0.66_1.00_0.01,enc_avif,quality_auto/59f71b_e269d3d9c4384e9dbb533e1c36d4a982~mv2.jpg", "Florero Explosión Tropical", 1100.00m, 18 },
                    { 9, true, 3, "Cesta rústica con una colorida selección de gerberas multicolor para alegrar el día.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQEHEglquTwWYOQkBETwZ9_RkAMsADWGvDkSA&s", "Cesta de Gerberas Sonrientes", 850.00m, 25 },
                    { 10, true, 3, "Jarrón de vidrio con espectaculares girasoles frescos acompañados de flores silvestres.", "https://floresco.co/351-large_default/arreglo-con-girasoles-radiante.jpg", "Girasoles Radiantes en Jarrón", 980.00m, 15 },
                    { 11, true, 3, "Arreglo mediano de flores variadas que incluye un globo metálico de feliz cumpleaños.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSyOV2DZdrK1SN6rXuWF91D6qhYU4F67dIMeg&s", "Dulce Deseo con Globos", 1250.00m, 14 },
                    { 12, true, 4, "Elegante planta de orquídea blanca en maceta de cerámica, símbolo de sofisticación.", "https://casafloravivarium.com/cdn/shop/products/IMG_8598.jpg?v=1634678627&width=1024", "Orquídea Phalaenopsis Doble Tallo", 1600.00m, 5 },
                    { 13, true, 4, "Árbol bonsái de interiores ideal para oficinas o salas, fácil cuidado.", "https://www.shutterstock.com/image-illustration/3d-rendering-pink-blooming-sakura-600nw-2619492913.jpg", "Bonsái de la Abundancia", 1400.00m, 7 },
                    { 14, true, 4, "Planta de interior con llamativas hojas rojas brillantes y duraderas.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQtRoZ-calbf552JjobqGm5MMCmy799KTUr9g&s", "Maceta de Anturios Rojos", 750.00m, 22 },
                    { 15, true, 4, "Hermosa planta purificadora de aire con elegantes flores blancas de espata.", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSfupsVzWjkbughdoDl57xyi6R_aXFz1ZMc9Q&s", "Lirio de la Paz Premium", 680.00m, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flor",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flor",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Flor",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Flor",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Flor",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Flor",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Flor",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Flor",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Flor",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Flor",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Flor",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Flor",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
