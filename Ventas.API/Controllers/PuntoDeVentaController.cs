using Microsoft.AspNetCore.Mvc;
using Ventas.Aplicacion.DTOs;
using Ventas.Aplicacion.Servicios;

[ApiController]
[Route("api/[controller]")]
public class PuntosDeVentaController : ControllerBase
{
    private readonly IPuntoDeVentaService _puntoDeVentaService;

    public PuntosDeVentaController(IPuntoDeVentaService puntoDeVentaService)
    {
        _puntoDeVentaService = puntoDeVentaService ?? throw new ArgumentNullException(nameof(puntoDeVentaService));
    }

    // GET: api/PuntosDeVenta
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PuntoDeVentaDto>), 200)]
    [ProducesResponseType(204)] // No Content si no hay puntos de venta
    public async Task<IActionResult> GetAllPuntosDeVenta()
    {
        var puntosDeVenta = await _puntoDeVentaService.GetAllPuntosDeVentaAsync();

        if (puntosDeVenta == null || !((List<PuntoDeVentaDto>)puntosDeVenta).Any()) // Usamos Any() para verificar si hay elementos
        {
            return NoContent(); // 204 No Content si la lista está vacía
        }

        return Ok(puntosDeVenta);
    }
}