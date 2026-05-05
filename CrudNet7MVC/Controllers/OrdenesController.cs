using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FloristeriaWeb.Datos;
using FloristeriaWeb.Helpers;
using FloristeriaWeb.Models;
using FloristeriaWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FloristeriaWeb.Controllers
{
    public class OrdenesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdenesController(ApplicationDbContext context)
        {
            _context = context;
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
        public async Task<IActionResult> Create([Bind("Id,NombreCliente,Email,FechaOrden,Telefono,Total,EstadoPagoId,Direccion,MunicipioId,TransactionId")] Orden orden)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreCliente,Email,FechaOrden,Telefono,Total,EstadoPagoId,Direccion,MunicipioId,TransactionId")] Orden orden)
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
            var carrito = HttpContext.Session.GetObjectFromJson<List<ElementoCarrito>>("CarritoFloreria");
            if (carrito == null || !carrito.Any()) return RedirectToAction("Index", "Home");

            ViewBag.Departamentos = await _context.Departamento.OrderBy(d => d.Nombre).ToListAsync();

            var model = new CheckoutVM { Total = carrito.Sum(x => x.Importe) };
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
        public async Task<IActionResult> ConfirmarPago([FromBody] dynamic datos)
        {
            // 1. Recuperar carrito y datos del Checkout de la sesión
            var carrito = HttpContext.Session.GetObjectFromJson<List<ElementoCarrito>>("CarritoFloreria");
            var checkoutInfo = HttpContext.Session.GetObjectFromJson<CheckoutVM>("InfoEnvio");

            if (carrito == null || checkoutInfo == null) return BadRequest();

            // 2. Crear el objeto Orden para la DB
            var orden = new Orden
            {
                NombreCliente = checkoutInfo.NombreCliente,
                Email = checkoutInfo.Email,
                Telefono = checkoutInfo.Telefono,
                Direccion = checkoutInfo.Direccion,
                MunicipioId = checkoutInfo.MunicipioId,
                Total = carrito.Sum(x => x.Importe),
                FechaOrden = DateTime.Now,
                EstadoPagoId = 1, // "Pagado" o "Pendiente"
                TransactionId = datos.idTransaccion // ID que viene de PayPal
            };

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
            }
            await _context.SaveChangesAsync();

            // 4. Limpiar carrito
            HttpContext.Session.Remove("CarritoFloreria");

            return Ok(new { success = true });
        }
    }
}
