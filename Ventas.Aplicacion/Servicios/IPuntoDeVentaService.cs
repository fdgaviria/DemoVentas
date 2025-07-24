using System.Collections.Generic;
using System.Threading.Tasks;
using Ventas.Aplicacion.DTOs;

namespace Ventas.Aplicacion.Servicios
{
    public interface IPuntoDeVentaService
    {
        Task<IEnumerable<PuntoDeVentaDto>> GetAllPuntosDeVentaAsync();
    }
}