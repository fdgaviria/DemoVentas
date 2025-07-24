using Microsoft.AspNetCore.Mvc;
using Ventas.Aplicacion.DTO;
using Ventas.Aplicacion.Servicios;

namespace Ventas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
        }

        // POST: api/Clientes
        [HttpPost]
        [ProducesResponseType(201)] // Created
        [ProducesResponseType(400)] // Bad Request
        [ProducesResponseType(409)] // Conflict (si la identificación ya existe)
        [ProducesResponseType(500)] // Internal Server Error
        public async Task<IActionResult> RegistrarCliente([FromBody] RegistrarClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Verificar si el cliente ya existe por identificación
            var existingCliente = await _clienteService.GetClienteByIdentificacionAsync(clienteDto.Identificacion);
            if (existingCliente != null)
            {
                return Conflict($"El cliente con identificación '{clienteDto.Identificacion}' ya está registrado.");
            }

            var success = await _clienteService.RegistrarClienteAsync(clienteDto);
            if (!success)
            {
                return StatusCode(500, "Ocurrió un error al intentar registrar el cliente.");
            }

            // Retorna 201 Created y la ubicación del recurso creado
            return CreatedAtAction(nameof(GetClienteByIdentificacion), new { identificacion = clienteDto.Identificacion }, clienteDto);
        }

        // GET: api/Clientes
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClienteDto>), 200)]
        [ProducesResponseType(204)] // No Content si no hay clientes
        public async Task<IActionResult> GetAllClientes()
        {
            var clientes = await _clienteService.GetAllClientesAsync();

            if (clientes == null || !clientes.Any())
            {
                return NoContent(); // 204 No Content si la lista está vacía
            }

            return Ok(clientes);
        }

        // GET: api/Clientes/{identificacion} (Endpoint auxiliar para CreatedAtAction y posibles consultas futuras)
        [HttpGet("{identificacion}")]
        [ProducesResponseType(typeof(ClienteDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetClienteByIdentificacion(string identificacion)
        {
            var cliente = await _clienteService.GetClienteByIdentificacionAsync(identificacion);
            if (cliente == null)
            {
                return NotFound($"Cliente con identificación '{identificacion}' no encontrado.");
            }
            return Ok(cliente);
        }
    }
}
