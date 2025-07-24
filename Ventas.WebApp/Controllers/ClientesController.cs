using Microsoft.AspNetCore.Mvc;
using Ventas.WebApp.Models;
using Ventas.WebApp.Services;

namespace Ventas.WebApp.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApiService _apiService;

        public ClientesController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Formulario()
        {
            return View(new RegistrarClienteViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Formulario(RegistrarClienteViewModel clienteDto)
        {
            if (ModelState.IsValid)
            {
                bool success = await _apiService.CreateClienteAsync(clienteDto);

                if (success)
                {
                    TempData["SuccessMessage"] = "Cliente registrado exitosamente.";
                    return RedirectToAction("Formulario", "Home"); 
                }
                else
                {
                    TempData["ErrorMessage"] = "Error al registrar el cliente. Es posible que la identificación ya exista o haya un problema en el servidor.";
                    return View("Formulario", clienteDto); 
                }
            }

            return View("Formulario", clienteDto);
        }
    }
}
