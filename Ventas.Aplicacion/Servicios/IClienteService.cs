using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Aplicacion.DTO;

namespace Ventas.Aplicacion.Servicios
{
    public interface IClienteService
    {
        Task<bool> RegistrarClienteAsync(RegistrarClienteDto clienteDto);
        Task<IEnumerable<ClienteDto>> GetAllClientesAsync();
        Task<ClienteDto> GetClienteByIdentificacionAsync(string identificacion);
    }
}
