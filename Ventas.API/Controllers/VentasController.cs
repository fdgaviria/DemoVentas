using Microsoft.AspNetCore.Mvc;
using Ventas.Aplicacion.DTO;
using Ventas.Aplicacion.Servicios;

namespace Ventas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly IVentaService _ventaService; // Dependemos de la interfaz

        // IVentaService se inyecta aquí
        public VentasController(IVentaService ventaService)
        {
            _ventaService = ventaService ?? throw new ArgumentNullException(nameof(ventaService));
        }

        // GET: api/Ventas/{codigo}
        [HttpGet("{codigo}")]
        [ProducesResponseType(typeof(VentaDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetVentaByCodigo(string codigo)
        {
            var venta = await _ventaService.GetVentaByCodigoAsync(codigo);
            if (venta == null)
            {
                return NotFound($"Venta con código '{codigo}' no encontrada.");
            }
            return Ok(venta);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VentaDto>), 200)]
        [ProducesResponseType(204)] 
        public async Task<IActionResult> GetAllVentas()
        {
            var ventas = await _ventaService.GetAllVentasAsync();

            if (ventas == null || !ventas.Any())
            {
                return NoContent(); 
            }

            return Ok(ventas);
        }

        
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public async Task<IActionResult> CrearVenta([FromBody] CrearVentaDto ventaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingVenta = await _ventaService.GetVentaByCodigoAsync(ventaDto.Codigo);
            if (existingVenta != null)
            {
                return Conflict($"La venta con el código '{ventaDto.Codigo}' ya existe.");
            }

            var success = await _ventaService.CrearVentaAsync(ventaDto);
            if (!success)
            {
                return StatusCode(500, "Ocurrió un error al intentar crear la venta.");
            }

            return CreatedAtAction(nameof(GetVentaByCodigo), new { codigo = ventaDto.Codigo }, ventaDto);
        }

        // PUT: api/Ventas/{codigo}
        [HttpPut("{codigo}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ActualizarVenta(string codigo, [FromBody] ActualizarVentaDto ventaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var success = await _ventaService.ActualizarVentaAsync(codigo, ventaDto);
            if (!success)
            {
                return NotFound($"Venta con código '{codigo}' no encontrada para actualizar.");
            }
            return NoContent();
        }

        // DELETE: api/Ventas/{codigo}
        [HttpDelete("{codigo}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> EliminarVenta(string codigo)
        {
            var success = await _ventaService.EliminarVentaAsync(codigo);
            if (!success)
            {
                return NotFound($"Venta con código '{codigo}' no encontrada para eliminar.");
            }
            return NoContent();
        }
    }
}

