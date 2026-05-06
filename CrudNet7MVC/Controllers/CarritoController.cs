using FloristeriaWeb.Datos;
using FloristeriaWeb.Helpers;
using FloristeriaWeb.Models;
using FloristeriaWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FloristeriaWeb.Controllers
{
    [Authorize]
    public class CarritoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string SESSION_KEY = "CarritoFloreria";

        public CarritoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Ver el carrito
        public IActionResult Index()
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<ElementoCarrito>>(SESSION_KEY)
                          ?? new List<ElementoCarrito>();

            ViewBag.TotalCarrito = carrito.Sum(x => x.Importe);
            return View(carrito);
        }

        // 2. Agregar producto al carrito
        public async Task<IActionResult> Agregar(int id)
        {
            var flor = await _context.Flor.FindAsync(id);
            if (flor == null) return NotFound();

            // Obtener el carrito actual o crear uno nuevo
            var carrito = HttpContext.Session.GetObjectFromJson<List<ElementoCarrito>>(SESSION_KEY)
                          ?? new List<ElementoCarrito>();

            // Lógica sistemática: ¿Ya existe el producto?
            var itemExistente = carrito.FirstOrDefault(x => x.FlorId == id);

            if (itemExistente != null)
            {
                itemExistente.Cantidad++;
            }
            else
            {
                carrito.Add(new ElementoCarrito
                {
                    FlorId = flor.Id,
                    Nombre = flor.Nombre,
                    Precio = flor.Precio,
                    ImagenUrl = flor.ImagenUrl,
                    Cantidad = 1
                });
            }

            // Guardar de nuevo en sesión
            HttpContext.Session.SetObjectAsJson(SESSION_KEY, carrito);

            // Redirigir al Index del carrito para que el usuario vea lo que agregó
            return RedirectToAction("Index");
        }

        // 3. Eliminar un producto
        public IActionResult Eliminar(int id)
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<ElementoCarrito>>(SESSION_KEY);
            if (carrito != null)
            {
                carrito.RemoveAll(x => x.FlorId == id);
                HttpContext.Session.SetObjectAsJson(SESSION_KEY, carrito);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ActualizarCantidadAjax(int florId, int nuevaCantidad)
        {
            var carrito = HttpContext.Session.GetObjectFromJson<List<ElementoCarrito>>("CarritoFloreria") ?? new List<ElementoCarrito>();
            var item = carrito.FirstOrDefault(x => x.FlorId == florId);

            // Buscar la flor en DB solo para validar que no nos alteren el JS maliciosamente
            var flor = _context.Flor.Find(florId);
            if (flor == null) return Json(new { success = false, message = "Flor no encontrada" });

            if (nuevaCantidad <= 0)
            {
                if (item != null) carrito.Remove(item);
            }
            else
            {
                // Validación de seguridad definitiva del lado del Servidor
                if (nuevaCantidad > flor.Stock)
                {
                    return Json(new { success = false, message = $"Solo quedan {flor.Stock} unidades disponibles." });
                }

                if (item == null)
                {
                    carrito.Add(new ElementoCarrito { FlorId = florId, Cantidad = nuevaCantidad, Precio = flor.Precio, Nombre = flor.Nombre, ImagenUrl = flor.ImagenUrl });
                }
                else
                {
                    item.Cantidad = nuevaCantidad;
                }
            }

            HttpContext.Session.SetObjectAsJson("CarritoFloreria", carrito);

            // Devolvemos la suma total de artículos en el carrito para el contador global
            int totalArticulos = carrito.Sum(x => x.Cantidad);
            return Json(new { success = true, totalArticulos = totalArticulos });
        }
    }
}