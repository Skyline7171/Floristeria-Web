using System.Diagnostics.Contracts;
using FloristeriaWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FloristeriaWeb.Datos
{
    public class ApplicationDbContext : IdentityDbContext<UsuarioAplicacion>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }

        // Recuerda agregar los modelos aquí para que sean cargados en la base de datos
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<DetalleOrden> DetalleOrden { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Flor> Flor { get; set; }
        public DbSet<Municipio> Municipio { get; set; }
        public DbSet<Orden> Orden { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { Id = 1, Nombre = "Boaco" },
                new Departamento { Id = 2, Nombre = "Carazo" },
                new Departamento { Id = 3, Nombre = "Chinandega" },
                new Departamento { Id = 4, Nombre = "Chontales" },
                new Departamento { Id = 5, Nombre = "Estelí" },
                new Departamento { Id = 6, Nombre = "Granada" },
                new Departamento { Id = 7, Nombre = "Jinotega" },
                new Departamento { Id = 8, Nombre = "León" },
                new Departamento { Id = 9, Nombre = "Madriz" },
                new Departamento { Id = 10, Nombre = "Managua" },
                new Departamento { Id = 11, Nombre = "Masaya" },
                new Departamento { Id = 12, Nombre = "Matagalpa" },
                new Departamento { Id = 13, Nombre = "Nueva Segovia" },
                new Departamento { Id = 14, Nombre = "Río San Juan" },
                new Departamento { Id = 15, Nombre = "Rivas" },
                new Departamento { Id = 16, Nombre = "Costa Caribe Norte" },
                new Departamento { Id = 17, Nombre = "Costa Caribe Sur" }
            );

            modelBuilder.Entity<Municipio>().HasData(
                // Boaco
                new Municipio { Id = 1, Nombre = "Boaco", DepartamentoId = 1 },
                new Municipio { Id = 2, Nombre = "Camoapa", DepartamentoId = 1 },
                new Municipio { Id = 3, Nombre = "San José de los Remates", DepartamentoId = 1 },
                new Municipio { Id = 4, Nombre = "San Lorenzo", DepartamentoId = 1 },
                new Municipio { Id = 5, Nombre = "Santa Lucía", DepartamentoId = 1 },
                new Municipio { Id = 6, Nombre = "Teustepe", DepartamentoId = 1 },

                // Carazo
                new Municipio { Id = 7, Nombre = "Jinotepe", DepartamentoId = 2 },
                new Municipio { Id = 8, Nombre = "Diriamba", DepartamentoId = 2 },
                new Municipio { Id = 9, Nombre = "San Marcos", DepartamentoId = 2 },
                new Municipio { Id = 10, Nombre = "Dolores", DepartamentoId = 2 },
                new Municipio { Id = 11, Nombre = "Santa Teresa", DepartamentoId = 2 },
                new Municipio { Id = 12, Nombre = "El Rosario", DepartamentoId = 2 },
                new Municipio { Id = 13, Nombre = "La Paz de Carazo", DepartamentoId = 2 },
                new Municipio { Id = 14, Nombre = "La Conquista", DepartamentoId = 2 },

                // Chinandega
                new Municipio { Id = 15, Nombre = "Chinandega", DepartamentoId = 3 },
                new Municipio { Id = 16, Nombre = "El Viejo", DepartamentoId = 3 },
                new Municipio { Id = 17, Nombre = "Corinto", DepartamentoId = 3 },
                new Municipio { Id = 18, Nombre = "Chichigalpa", DepartamentoId = 3 },
                new Municipio { Id = 19, Nombre = "El Realejo", DepartamentoId = 3 },
                new Municipio { Id = 20, Nombre = "Posoltega", DepartamentoId = 3 },
                new Municipio { Id = 21, Nombre = "Quezalguaque", DepartamentoId = 3 },
                new Municipio { Id = 22, Nombre = "Somotillo", DepartamentoId = 3 },
                new Municipio { Id = 23, Nombre = "Villanueva", DepartamentoId = 3 },
                new Municipio { Id = 24, Nombre = "Santo Tomás del Norte", DepartamentoId = 3 },
                new Municipio { Id = 25, Nombre = "Cinco Pinos", DepartamentoId = 3 },
                new Municipio { Id = 26, Nombre = "San Pedro del Norte", DepartamentoId = 3 },
                new Municipio { Id = 27, Nombre = "San Francisco del Norte", DepartamentoId = 3 },

                // Chontales
                new Municipio { Id = 28, Nombre = "Juigalpa", DepartamentoId = 4 },
                new Municipio { Id = 29, Nombre = "Acoyapa", DepartamentoId = 4 },
                new Municipio { Id = 30, Nombre = "Santo Tomás", DepartamentoId = 4 },
                new Municipio { Id = 31, Nombre = "La Libertad", DepartamentoId = 4 },
                new Municipio { Id = 32, Nombre = "San Pedro de Lóvago", DepartamentoId = 4 },
                new Municipio { Id = 33, Nombre = "Santo Domingo", DepartamentoId = 4 },
                new Municipio { Id = 34, Nombre = "Villa Sandino", DepartamentoId = 4 },
                new Municipio { Id = 35, Nombre = "Comalapa", DepartamentoId = 4 },
                new Municipio { Id = 36, Nombre = "San Francisco de Cuapa", DepartamentoId = 4 },
                new Municipio { Id = 37, Nombre = "El Coral", DepartamentoId = 4 },

                // Estelí
                new Municipio { Id = 38, Nombre = "Estelí", DepartamentoId = 5 },
                new Municipio { Id = 39, Nombre = "Condega", DepartamentoId = 5 },
                new Municipio { Id = 40, Nombre = "Pueblo Nuevo", DepartamentoId = 5 },
                new Municipio { Id = 41, Nombre = "La Trinidad", DepartamentoId = 5 },
                new Municipio { Id = 42, Nombre = "San Juan de Limay", DepartamentoId = 5 },
                new Municipio { Id = 43, Nombre = "San Nicolás", DepartamentoId = 5 },

                // Granada
                new Municipio { Id = 44, Nombre = "Granada", DepartamentoId = 6 },
                new Municipio { Id = 45, Nombre = "Diriá", DepartamentoId = 6 },
                new Municipio { Id = 46, Nombre = "Diriomo", DepartamentoId = 6 },
                new Municipio { Id = 47, Nombre = "Nandaime", DepartamentoId = 6 },

                // Jinotega
                new Municipio { Id = 48, Nombre = "Jinotega", DepartamentoId = 7 },
                new Municipio { Id = 49, Nombre = "Wiwilí de Jinotega", DepartamentoId = 7 },
                new Municipio { Id = 50, Nombre = "El Cuá", DepartamentoId = 7 },
                new Municipio { Id = 51, Nombre = "San José de Bocay", DepartamentoId = 7 },
                new Municipio { Id = 52, Nombre = "San Sebastián de Yalí", DepartamentoId = 7 },
                new Municipio { Id = 53, Nombre = "Santa María de Pantasma", DepartamentoId = 7 },
                new Municipio { Id = 54, Nombre = "San Rafael del Norte", DepartamentoId = 7 },
                new Municipio { Id = 55, Nombre = "La Concordia", DepartamentoId = 7 },

                // León
                new Municipio { Id = 56, Nombre = "León", DepartamentoId = 8 },
                new Municipio { Id = 57, Nombre = "Nagarote", DepartamentoId = 8 },
                new Municipio { Id = 58, Nombre = "La Paz Centro", DepartamentoId = 8 },
                new Municipio { Id = 59, Nombre = "Telica", DepartamentoId = 8 },
                new Municipio { Id = 60, Nombre = "Quezalguaque", DepartamentoId = 8 },
                new Municipio { Id = 61, Nombre = "Larreynaga", DepartamentoId = 8 },
                new Municipio { Id = 62, Nombre = "El Sauce", DepartamentoId = 8 },
                new Municipio { Id = 63, Nombre = "Achuapa", DepartamentoId = 8 },
                new Municipio { Id = 64, Nombre = "Santa Rosa del Peñón", DepartamentoId = 8 },
                new Municipio { Id = 65, Nombre = "El Jicaral", DepartamentoId = 8 },

                // Madriz
                new Municipio { Id = 66, Nombre = "Somoto", DepartamentoId = 9 },
                new Municipio { Id = 67, Nombre = "Totogalpa", DepartamentoId = 9 },
                new Municipio { Id = 68, Nombre = "Telpaneca", DepartamentoId = 9 },
                new Municipio { Id = 69, Nombre = "San Lucas", DepartamentoId = 9 },
                new Municipio { Id = 70, Nombre = "Yalagüina", DepartamentoId = 9 },
                new Municipio { Id = 71, Nombre = "Palacagüina", DepartamentoId = 9 },
                new Municipio { Id = 72, Nombre = "San Juan de Río Coco", DepartamentoId = 9 },
                new Municipio { Id = 73, Nombre = "San José de Cusmapa", DepartamentoId = 9 },
                new Municipio { Id = 74, Nombre = "Las Sabanas", DepartamentoId = 9 },

                // Managua
                new Municipio { Id = 75, Nombre = "Managua", DepartamentoId = 10 },
                new Municipio { Id = 76, Nombre = "Tipitapa", DepartamentoId = 10 },
                new Municipio { Id = 77, Nombre = "Ciudad Sandino", DepartamentoId = 10 },
                new Municipio { Id = 78, Nombre = "San Rafael del Sur", DepartamentoId = 10 },
                new Municipio { Id = 79, Nombre = "Mateare", DepartamentoId = 10 },
                new Municipio { Id = 80, Nombre = "Villa El Carmen", DepartamentoId = 10 },
                new Municipio { Id = 81, Nombre = "Ticuantepe", DepartamentoId = 10 },
                new Municipio { Id = 82, Nombre = "San Francisco Libre", DepartamentoId = 10 },
                new Municipio { Id = 83, Nombre = "El Crucero", DepartamentoId = 10 },

                // Masaya
                new Municipio { Id = 84, Nombre = "Masaya", DepartamentoId = 11 },
                new Municipio { Id = 85, Nombre = "Nindirí", DepartamentoId = 11 },
                new Municipio { Id = 86, Nombre = "Masatepe", DepartamentoId = 11 },
                new Municipio { Id = 87, Nombre = "Nandasmo", DepartamentoId = 11 },
                new Municipio { Id = 88, Nombre = "Catarina", DepartamentoId = 11 },
                new Municipio { Id = 89, Nombre = "San Juan de Oriente", DepartamentoId = 11 },
                new Municipio { Id = 90, Nombre = "Niquinohomo", DepartamentoId = 11 },
                new Municipio { Id = 91, Nombre = "Tisma", DepartamentoId = 11 },
                new Municipio { Id = 92, Nombre = "La Concepción", DepartamentoId = 11 },

                // Matagalpa
                new Municipio { Id = 93, Nombre = "Matagalpa", DepartamentoId = 12 },
                new Municipio { Id = 94, Nombre = "Sébaco", DepartamentoId = 12 },
                new Municipio { Id = 95, Nombre = "San Isidro", DepartamentoId = 12 },
                new Municipio { Id = 96, Nombre = "Ciudad Darío", DepartamentoId = 12 },
                new Municipio { Id = 97, Nombre = "Terrabona", DepartamentoId = 12 },
                new Municipio { Id = 98, Nombre = "San Dionisio", DepartamentoId = 12 },
                new Municipio { Id = 99, Nombre = "Esquipulas", DepartamentoId = 12 },
                new Municipio { Id = 100, Nombre = "Muy Muy", DepartamentoId = 12 },
                new Municipio { Id = 101, Nombre = "Matiguás", DepartamentoId = 12 },
                new Municipio { Id = 102, Nombre = "Río Blanco", DepartamentoId = 12 },
                new Municipio { Id = 103, Nombre = "San Ramón", DepartamentoId = 12 },
                new Municipio { Id = 104, Nombre = "Rancho Grande", DepartamentoId = 12 },
                new Municipio { Id = 105, Nombre = "Tuma-La Dalia", DepartamentoId = 12 },

                // Nueva Segovia
                new Municipio { Id = 106, Nombre = "Ocotal", DepartamentoId = 13 },
                new Municipio { Id = 107, Nombre = "Jalapa", DepartamentoId = 13 },
                new Municipio { Id = 108, Nombre = "Wiwilí de Nueva Segovia", DepartamentoId = 13 },
                new Municipio { Id = 109, Nombre = "Quilalí", DepartamentoId = 13 },
                new Municipio { Id = 110, Nombre = "Jícaro", DepartamentoId = 13 },
                new Municipio { Id = 111, Nombre = "Murra", DepartamentoId = 13 },
                new Municipio { Id = 112, Nombre = "San Fernando", DepartamentoId = 13 },
                new Municipio { Id = 113, Nombre = "Ciudad Antigua", DepartamentoId = 13 },
                new Municipio { Id = 114, Nombre = "Mozonte", DepartamentoId = 13 },
                new Municipio { Id = 115, Nombre = "Dipilto", DepartamentoId = 13 },
                new Municipio { Id = 116, Nombre = "Santa María", DepartamentoId = 13 },
                new Municipio { Id = 117, Nombre = "Macuelizo", DepartamentoId = 13 },

                // Río San Juan
                new Municipio { Id = 118, Nombre = "San Carlos", DepartamentoId = 14 },
                new Municipio { Id = 119, Nombre = "El Castillo", DepartamentoId = 14 },
                new Municipio { Id = 120, Nombre = "San Juan del Norte", DepartamentoId = 14 },
                new Municipio { Id = 121, Nombre = "San Miguelito", DepartamentoId = 14 },
                new Municipio { Id = 122, Nombre = "El Almendro", DepartamentoId = 14 },
                new Municipio { Id = 123, Nombre = "Morrito", DepartamentoId = 14 },

                // Rivas
                new Municipio { Id = 124, Nombre = "Rivas", DepartamentoId = 15 },
                new Municipio { Id = 125, Nombre = "San Juan del Sur", DepartamentoId = 15 },
                new Municipio { Id = 126, Nombre = "Moyogalpa", DepartamentoId = 15 },
                new Municipio { Id = 127, Nombre = "Altagracia", DepartamentoId = 15 },
                new Municipio { Id = 128, Nombre = "Tola", DepartamentoId = 15 },
                new Municipio { Id = 129, Nombre = "San Jorge", DepartamentoId = 15 },
                new Municipio { Id = 130, Nombre = "Potosí", DepartamentoId = 15 },
                new Municipio { Id = 131, Nombre = "Buenos Aires", DepartamentoId = 15 },
                new Municipio { Id = 132, Nombre = "Belén", DepartamentoId = 15 },
                new Municipio { Id = 133, Nombre = "Cárdenas", DepartamentoId = 15 },

                // Costa Caribe Norte
                new Municipio { Id = 134, Nombre = "Puerto Cabezas", DepartamentoId = 16 },
                new Municipio { Id = 135, Nombre = "Waspam", DepartamentoId = 16 },
                new Municipio { Id = 136, Nombre = "Siuna", DepartamentoId = 16 },
                new Municipio { Id = 137, Nombre = "Rosita", DepartamentoId = 16 },
                new Municipio { Id = 138, Nombre = "Bonanza", DepartamentoId = 16 },
                new Municipio { Id = 139, Nombre = "Prinzapolka", DepartamentoId = 16 },
                new Municipio { Id = 140, Nombre = "Waslala", DepartamentoId = 16 },
                new Municipio { Id = 141, Nombre = "Mulukukú", DepartamentoId = 16 },

                // Costa Caribe Sur
                new Municipio { Id = 142, Nombre = "Bluefields", DepartamentoId = 17 },
                new Municipio { Id = 143, Nombre = "Corn Island", DepartamentoId = 17 },
                new Municipio { Id = 144, Nombre = "Laguna de Perlas", DepartamentoId = 17 },
                new Municipio { Id = 145, Nombre = "Nueva Guinea", DepartamentoId = 17 },
                new Municipio { Id = 146, Nombre = "El Rama", DepartamentoId = 17 },
                new Municipio { Id = 147, Nombre = "Kukra Hill", DepartamentoId = 17 },
                new Municipio { Id = 148, Nombre = "La Cruz de Río Grande", DepartamentoId = 17 },
                new Municipio { Id = 149, Nombre = "Desembocadura de Río Grande", DepartamentoId = 17 },
                new Municipio { Id = 150, Nombre = "El Tortuguero", DepartamentoId = 17 },
                new Municipio { Id = 151, Nombre = "Muelle de los Bueyes", DepartamentoId = 17 },
                new Municipio { Id = 152, Nombre = "El Ayote", DepartamentoId = 17 },
                new Municipio { Id = 153, Nombre = "Paiwas", DepartamentoId = 17 }
            );

            modelBuilder.Entity<Estado>().HasData(
                new Estado { Id = 1, Nombre = "Pendiente" },
                new Estado { Id = 2, Nombre = "En preparación" },
                new Estado { Id = 3, Nombre = "En camino" },
                new Estado { Id = 4, Nombre = "Entregado" },
                new Estado { Id = 5, Nombre = "Cancelado" }
            );

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nombre = "Arreglos Fúnebres", Descripcion = "Coronas, cruces y arreglos solemnes de condolencias.", Activo = true },
                new Categoria { Id = 2, Nombre = "Ramos Románticos", Descripcion = "Ramos elegantes diseñados para expresar amor y aniversario.", Activo = true },
                new Categoria { Id = 3, Nombre = "Detalles de Cumpleaños", Descripcion = "Arreglos alegres y coloridos para celebraciones especiales.", Activo = true },
                new Categoria { Id = 4, Nombre = "Plantas Exóticas", Descripcion = "Plantas vivas y flores exóticas para interiores y decoración duradera.", Activo = true }
            );

            modelBuilder.Entity<Flor>().HasData(
                // Categoría 1: Arreglos Fúnebres
                new Flor
                {
                    Id = 1,
                    Nombre = "Corona de Condolencias Imperial",
                    Descripcion = "Elegante corona fúnebre con lirios blancos, rosas y follaje fino.",
                    Precio = 2450.00m,
                    Stock = 10,
                    ImagenUrl = "https://cdnx.jumpseller.com/floresensantiago/image/64518186/thumb/300/300?1750020573",
                    Activo = true,
                    CategoriaId = 1
                },
                new Flor
                {
                    Id = 2,
                    Nombre = "Cruz del Eterno Descanso",
                    Descripcion = "Arreglo solemne en forma de cruz elaborado con claveles y rosas blancas.",
                    Precio = 1800.00m,
                    Stock = 8,
                    ImagenUrl = "https://www.yaakunflores.com/uploads/arreglos/cruz-eterno-descanso.jpg",
                    Activo = true,
                    CategoriaId = 1
                },
                new Flor
                {
                    Id = 3,
                    Nombre = "Cojín de Crisantemos y Lirios",
                    Descripcion = "Almohadón floral fúnebre con crisantemos blancos y acentos de lila.",
                    Precio = 1200.00m,
                    Stock = 15,
                    ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSO2y9GVpniMB2Fmy26Ptsp0aSjl-J0NmtNWA&s",
                    Activo = true,
                    CategoriaId = 1
                },

                // Categoría 2: Ramos Románticos
                new Flor
                {
                    Id = 4,
                    Nombre = "Ramo de 24 Rosas Rojas Premium",
                    Descripcion = "Clásico y majestuoso ramo de rosas rojas de tallo largo con envoltura de lujo.",
                    Precio = 1500.00m,
                    Stock = 30,
                    ImagenUrl = "https://ponchycaprico.com/cdn/shop/files/RR003_24_cc29830d-f44b-4533-ab54-d9de13384b0b.jpg?v=1760662544&width=1946",
                    Activo = true,
                    CategoriaId = 2
                },
                new Flor
                {
                    Id = 5,
                    Nombre = "Caja Corazón Romántico",
                    Descripcion = "Caja premium en forma de corazón rellena de rosas rojas y bombones.",
                    Precio = 1950.00m,
                    Stock = 12,
                    ImagenUrl = "https://www.floreriabloom.com/cdn/shop/files/arreglo-romantico-rosas-rojas-chocolates-bombones-delivery-lima.jpg?v=1775691296&width=2048",
                    Activo = true,
                    CategoriaId = 2
                },
                new Flor
                {
                    Id = 6,
                    Nombre = "Ramo Suspiro de Amor",
                    Descripcion = "Combinación delicada de rosas rosadas, astromelias y hortensias blancas.",
                    Precio = 950.00m,
                    Stock = 20,
                    ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR-XYaOTgZOnDhOapcBiwAoc5Sa4jnaYdqW-g&s",
                    Activo = true,
                    CategoriaId = 2
                },
                new Flor
                {
                    Id = 7,
                    Nombre = "Eternidad de Tulipanes",
                    Descripcion = "Fino ramo de tulipanes importados en tonos pastel perfectos para aniversarios.",
                    Precio = 1750.00m,
                    Stock = 6,
                    ImagenUrl = "https://i.etsystatic.com/51995127/r/il/db9c41/6747189706/il_fullxfull.6747189706_56d6.jpg",
                    Activo = true,
                    CategoriaId = 2
                },

                // Categoría 3: Detalles de Cumpleaños
                new Flor
                {
                    Id = 8,
                    Nombre = "Florero Explosión Tropical",
                    Descripcion = "Arreglo vibrante con aves del paraíso, gerberas brillantes y lirios amarillos.",
                    Precio = 1100.00m,
                    Stock = 18,
                    ImagenUrl = "https://static.wixstatic.com/media/59f71b_e269d3d9c4384e9dbb533e1c36d4a982~mv2.jpg/v1/fill/w_480,h_480,al_c,q_80,usm_0.66_1.00_0.01,enc_avif,quality_auto/59f71b_e269d3d9c4384e9dbb533e1c36d4a982~mv2.jpg",
                    Activo = true,
                    CategoriaId = 3
                },
                new Flor
                {
                    Id = 9,
                    Nombre = "Cesta de Gerberas Sonrientes",
                    Descripcion = "Cesta rústica con una colorida selección de gerberas multicolor para alegrar el día.",
                    Precio = 850.00m,
                    Stock = 25,
                    ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQEHEglquTwWYOQkBETwZ9_RkAMsADWGvDkSA&s",
                    Activo = true,
                    CategoriaId = 3
                },
                new Flor
                {
                    Id = 10,
                    Nombre = "Girasoles Radiantes en Jarrón",
                    Descripcion = "Jarrón de vidrio con espectaculares girasoles frescos acompañados de flores silvestres.",
                    Precio = 980.00m,
                    Stock = 15,
                    ImagenUrl = "https://floresco.co/351-large_default/arreglo-con-girasoles-radiante.jpg",
                    Activo = true,
                    CategoriaId = 3
                },
                new Flor
                {
                    Id = 11,
                    Nombre = "Dulce Deseo con Globos",
                    Descripcion = "Arreglo mediano de flores variadas que incluye un globo metálico de feliz cumpleaños.",
                    Precio = 1250.00m,
                    Stock = 14,
                    ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSyOV2DZdrK1SN6rXuWF91D6qhYU4F67dIMeg&s",
                    Activo = true,
                    CategoriaId = 3
                },

                // Categoría 4: Plantas Exóticas
                new Flor
                {
                    Id = 12,
                    Nombre = "Orquídea Phalaenopsis Doble Tallo",
                    Descripcion = "Elegante planta de orquídea blanca en maceta de cerámica, símbolo de sofisticación.",
                    Precio = 1600.00m,
                    Stock = 5,
                    ImagenUrl = "https://casafloravivarium.com/cdn/shop/products/IMG_8598.jpg?v=1634678627&width=1024",
                    Activo = true,
                    CategoriaId = 4
                },
                new Flor
                {
                    Id = 13,
                    Nombre = "Bonsái de la Abundancia",
                    Descripcion = "Árbol bonsái de interiores ideal para oficinas o salas, fácil cuidado.",
                    Precio = 1400.00m,
                    Stock = 7,
                    ImagenUrl = "https://www.shutterstock.com/image-illustration/3d-rendering-pink-blooming-sakura-600nw-2619492913.jpg",
                    Activo = true,
                    CategoriaId = 4
                },
                new Flor
                {
                    Id = 14,
                    Nombre = "Maceta de Anturios Rojos",
                    Descripcion = "Planta de interior con llamativas hojas rojas brillantes y duraderas.",
                    Precio = 750.00m,
                    Stock = 22,
                    ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQtRoZ-calbf552JjobqGm5MMCmy799KTUr9g&s",
                    Activo = true,
                    CategoriaId = 4
                },
                // Flor especial con stock bajo para que pruebes tu nuevo buscador optimizado:
                new Flor
                {
                    Id = 15,
                    Nombre = "Lirio de la Paz Premium",
                    Descripcion = "Hermosa planta purificadora de aire con elegantes flores blancas de espata.",
                    Precio = 680.00m,
                    Stock = 2, // Stock mínimo para pruebas
                    ImagenUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSfupsVzWjkbughdoDl57xyi6R_aXFz1ZMc9Q&s",
                    Activo = true,
                    CategoriaId = 4
                }
            );
        }
    }
}
