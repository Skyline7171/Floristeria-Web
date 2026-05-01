using System.Diagnostics.Contracts;
using FloristeriaWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FloristeriaWeb.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }

        // Agregar los modelos aquí
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
                new Estado { Id = 2, Nombre = "Aprobado" },
                new Estado { Id = 3, Nombre = "Rechazado" }
            );
        }
    }
}
