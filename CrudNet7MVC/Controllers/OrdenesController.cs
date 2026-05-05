using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FloristeriaWeb.Datos;
using FloristeriaWeb.Helpers;
using FloristeriaWeb.Models;
using FloristeriaWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FloristeriaWeb.Controllers
{
    public class OrdenesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UsuarioAplicacion> _userManager;

        public OrdenesController(ApplicationDbContext context, UserManager<UsuarioAplicacion> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Ordenes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orden.Include(o => o.Estado).Include(o => o.Municipio);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ordenes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Orden
                .Include(o => o.Estado)
                .Include(o => o.Municipio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // GET: Ordenes/Create
        public IActionResult Create()
        {
            ViewData["EstadoPagoId"] = new SelectList(_context.Estado, "Id", "Nombre");
            ViewData["MunicipioId"] = new SelectList(_context.Municipio, "Id", "Nombre");
            return View();
        }

        // POST: Ordenes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreDestinatario,ApellidoDestinatario,Email,FechaOrden,Telefono,Total,EstadoPagoId,Direccion,MunicipioId,TransactionId")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoPagoId"] = new SelectList(_context.Estado, "Id", "Nombre", orden.EstadoPagoId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipio, "Id", "Nombre", orden.MunicipioId);
            return View(orden);
        }

        // GET: Ordenes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Orden.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }
            ViewData["EstadoPagoId"] = new SelectList(_context.Estado, "Id", "Nombre", orden.EstadoPagoId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipio, "Id", "Nombre", orden.MunicipioId);
            return View(orden);
        }

        // POST: Ordenes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreDestinatario,ApellidoDestinatario,Email,FechaOrden,Telefono,Total,EstadoPagoId,Direccion,MunicipioId,TransactionId")] Orden orden)
        {
            if (id != orden.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenExists(orden.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoPagoId"] = new SelectList(_context.Estado, "Id", "Nombre", orden.EstadoPagoId);
            ViewData["MunicipioId"] = new SelectList(_context.Municipio, "Id", "Nombre", orden.MunicipioId);
            return View(orden);
        }

        // GET: Ordenes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orden = await _context.Orden
                .Include(o => o.Estado)
                .Include(o => o.Municipio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // POST: Ordenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orden = await _context.Orden.FindAsync(id);
            if (orden != null)
            {
                _context.Orden.Remove(orden);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenExists(int id)
        {
            return _context.Orden.Any(e => e.Id == id);
        }

        // GET: Ordenes/Checkout
        public async Task<IActionResult> Checkout()
        {
            var usuario = await _userManager.GetUserAsync(User);
            if (usuario == null)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            var carrito = HttpContext.Session.GetObjectFromJson<List<ElementoCarrito>>("CarritoFloreria");
            if (carrito == null || !carrito.Any()) return RedirectToAction("Index", "Home");

            ViewBag.Departamentos = await _context.Departamento.OrderBy(d => d.Nombre).ToListAsync();

            var model = new CheckoutVM { Email = usuario.Email, Total = carrito.Sum(x => x.Importe) };
            return View(model);
        }

        // API para cargar municipios dinámicamente
        [HttpGet]
        public async Task<JsonResult> GetMunicipios(int departamentoId)
        {
            var municipios = await _context.Municipio
                .Where(m => m.DepartamentoId == departamentoId)
                .OrderBy(m => m.Nombre)
                .Select(m => new { id = m.Id, nombre = m.Nombre })
                .ToListAsync();
            return Json(municipios);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmarPago([FromBody] ConfirmarPagoDTO modelo)
        {
            var usuarioActual = await _userManager.GetUserAsync(User);
            var carrito = HttpContext.Session.GetObjectFromJson<List<ElementoCarrito>>("CarritoFloreria");

            if (carrito == null) return BadRequest();

            var orden = new Orden
            {
                UsuarioId = usuarioActual.Id,
                NombreDestinatario = modelo.NombreDestinatario,
                ApellidoDestinatario = modelo.ApellidoDestinatario,
                Email = modelo.Email,
                Telefono = modelo.Telefono,
                Direccion = modelo.Direccion,
                MunicipioId = modelo.MunicipioId,
                Total = carrito.Sum(x => x.Importe),
                FechaOrden = DateTime.Now,
                EstadoPagoId = 1, // "Pagado" o "Pendiente"
                TransactionId = modelo.IdTransaccion // ID que viene de PayPal
            };

            // Crear el objeto Orden para la DB
            _context.Orden.Add(orden);
            await _context.SaveChangesAsync();

            // 3. Guardar los Detalles de la Orden
            foreach (var item in carrito)
            {
                var detalle = new DetalleOrden
                {
                    OrdenId = orden.Id,
                    FlorId = item.FlorId,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.Precio
                };
                _context.DetalleOrden.Add(detalle);

                var florEnInventario = await _context.Flor.FindAsync(item.FlorId);
                if (florEnInventario != null)
                {
                    // Restamos la cantidad comprada del stock actual
                    florEnInventario.Stock -= item.Cantidad;

                    // Medida de seguridad: Si por algún desfase el stock da negativo, lo nivelamos a 0
                    if (florEnInventario.Stock < 0)
                    {
                        florEnInventario.Stock = 0;
                    }
                }
            }
            await _context.SaveChangesAsync();

            // 4. Limpiar carrito
            HttpContext.Session.Remove("CarritoFloreria");

            return Ok(new { success = true });
        }

        // Acción para mostrar la pantalla de éxito
        public IActionResult ConfirmacionExito(string idTransaccion)
        {
            ViewBag.IdTransaccion = idTransaccion;
            return View();
        }

        [Authorize]
        public async Task<IActionResult> MisPedidos()
        {
            var usuarioActual = await _userManager.GetUserAsync(User);
            if (usuarioActual == null) return Challenge();

            // Traemos las órdenes del usuario e incluimos la relación del Municipio y su Departamento
            var misOrdenes = await _context.Orden
                .Include(o => o.Municipio)
                    .ThenInclude(m => m.Departamento)
                .Where(o => o.UsuarioId == usuarioActual.Id)
                .OrderByDescending(o => o.FechaOrden)
                .ToListAsync();

            return View(misOrdenes);
        }

        [Authorize]
        public async Task<IActionResult> DetallePedido(int id)
        {
            var usuarioActual = await _userManager.GetUserAsync(User);
            if (usuarioActual == null) return Challenge();

            // Buscamos la orden con todas sus relaciones necesarias
            var orden = await _context.Orden
                .Include(o => o.Municipio)
                    .ThenInclude(m => m.Departamento)
                .FirstOrDefaultAsync(o => o.Id == id && o.UsuarioId == usuarioActual.Id);

            // Si la orden no existe o no le pertenece al usuario, lo redirigimos
            if (orden == null)
            {
                return RedirectToAction("MisPedidos");
            }

            // Cargamos los productos (detalles) de esta orden de forma explícita
            // Asumiendo que tu propiedad de navegación en la clase Orden se llama DetalleOrden
            var detalles = await _context.DetalleOrden
                .Include(d => d.Flor) // Para poder mostrar la foto, nombre y precio de la flor
                .Where(d => d.OrdenId == id)
                .ToListAsync();

            // Pasamos los detalles a la vista mediante el ViewBag o puedes crear un ViewModel si lo prefieres
            ViewBag.Detalles = detalles;

            return View(orden);
        }

        public class ConfirmarPagoDTO
        {
            public string IdTransaccion { get; set; }
            public string NombreDestinatario { get; set; }
            public string ApellidoDestinatario { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }
            public int MunicipioId { get; set; }
            public string Direccion { get; set; }
        }
    }
}
