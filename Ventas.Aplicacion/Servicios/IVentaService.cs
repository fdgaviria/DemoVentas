using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Aplicacion.DTO;

namespace Ventas.Aplicacion.Servicios
{

    public interface IVentaService
    {
        Task<VentaDto> GetVentaByCodigoAsync(string codigo);
        Task<IEnumerable<VentaDto>> GetAllVentasAsync();
        Task<bool> CrearVentaAsync(CrearVentaDto ventaDto);
        Task<bool> ActualizarVentaAsync(string codigo, ActualizarVentaDto ventaDto);
        Task<bool> EliminarVentaAsync(string codigo);
    }
}
