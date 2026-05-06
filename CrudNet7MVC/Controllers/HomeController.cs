using System.Diagnostics;
using FloristeriaWeb.Datos;
using FloristeriaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace deleteafter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var flores = await _context.Flor
                .Include(f => f.Categoria)
                .Where(f => f.Activo && f.Stock > 0)
                .ToListAsync();

            ViewBag.Categorias = await _context.Categoria
                .OrderBy(c => c.Nombre)
                .ToListAsync();

            return View(flores);
        }

        [HttpPost]
        public IActionResult FiltrarCatalogo(string buscar, int? categoriaId)
        {
            var query = _context.Flor
                .Include(f => f.Categoria)
                .Where(f => f.Stock > 0)
                .AsQueryable();

            // Filtro por Texto (Nombre)
            if (!string.IsNullOrEmpty(buscar))
            {
                query = query.Where(f => f.Nombre.Contains(buscar));
            }

            // Filtro por Categoría
            if (categoriaId.HasValue)
            {
                query = query.Where(f => f.CategoriaId == categoriaId.Value);
            }

            var listaFiltrada = query.ToList();

            return PartialView("_CatalogoFlores", listaFiltrada);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
