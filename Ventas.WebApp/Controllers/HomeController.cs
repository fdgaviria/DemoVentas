using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Ventas.WebApp.Models;
using Ventas.WebApp.Services;

namespace Ventas.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApiService _apiService;

        public HomeController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index(string filtroCodigoVenta, int pageNumber = 1, int pageSize = 10)
        {
            var allVentas = await _apiService.GetAllVentasAsync();

            if (!string.IsNullOrEmpty(filtroCodigoVenta))
            {
                allVentas = allVentas
                    .Where(v => v.Codigo.Contains(filtroCodigoVenta, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            var totalRecords = allVentas.Count;
            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
            var paginatedVentas = allVentas
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var viewModel = new VentasIndexViewModel
            {
                Ventas = paginatedVentas,
                FiltroCodigoVenta = filtroCodigoVenta,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalRecords = totalRecords
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Formulario()
        {
            var clientes = await _apiService.GetAllClientesAsync();
            var puntosDeVenta = await _apiService.GetAllPuntosDeVentaAsync();

            ViewBag.Clientes = new SelectList(clientes, "Identificacion", "Nombre");
            ViewBag.PuntosDeVenta = new SelectList(puntosDeVenta, "Nit", "Nombre");

            var model = new VentaViewModel { Fecha = DateTime.Today };
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(string codigo)
        {
            var venta = await _apiService.GetVentaByCodigoAsync(codigo);
            if (venta == null)
            {
                return NotFound();
            }

            var clientes = await _apiService.GetAllClientesAsync();
            var puntosDeVenta = await _apiService.GetAllPuntosDeVentaAsync();

            ViewBag.Clientes = new SelectList(clientes, "Identificacion", "Nombre", venta.ClienteIdentificacion);
            ViewBag.PuntosDeVenta = new SelectList(puntosDeVenta, "Nit", "Nombre", venta.PuntoVentaNit);

            return View("Formulario", venta); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Formulario(VentaViewModel venta)
        {
            if (ModelState.IsValid)
            {
                bool success;
                bool noExiste = await _apiService.GetVentaByCodigoAsync(venta.Codigo) == null;
                if (noExiste) 
                {
                    success = await _apiService.CreateVentaAsync(venta);
                }
                else
                {
                    success = await _apiService.UpdateVentaAsync(venta.Codigo, venta);
                }


                if (success)
                {
                    TempData["SuccessMessage"] = "Venta registrada/actualizada exitosamente.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = "Error al registrar/actualizar la venta. Verifique los datos e intente de nuevo.";
                  
                    var clientes = await _apiService.GetAllClientesAsync();
                    var puntosDeVenta = await _apiService.GetAllPuntosDeVentaAsync();
                    ViewBag.Clientes = new SelectList(clientes, "Identificacion", "Nombre", venta.ClienteIdentificacion);
                    ViewBag.PuntosDeVenta = new SelectList(puntosDeVenta, "Nit", "Nombre", venta.PuntoVentaNit);
                    return View("Formulario", venta); 
                }
            }

            var clientesInvalid = await _apiService.GetAllClientesAsync();
            var puntosDeVentaInvalid = await _apiService.GetAllPuntosDeVentaAsync();
            ViewBag.Clientes = new SelectList(clientesInvalid, "Identificacion", "Nombre", venta.ClienteIdentificacion);
            ViewBag.PuntosDeVenta = new SelectList(puntosDeVentaInvalid, "Nit", "Nombre", venta.PuntoVentaNit);
            return View("Formulario", venta);
        }


        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(string codigo)
        {
            var success = await _apiService.DeleteVentaAsync(codigo);
            if (success)
            {
                TempData["SuccessMessage"] = "Venta eliminada exitosamente.";
            }
            else
            {
                TempData["ErrorMessage"] = "Error al eliminar la venta. Es posible que no exista o haya un problema en el servidor.";
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult NuevoCliente()
        {
            return RedirectToAction("Formulario", "Clientes"); 
        }
    }
}
