using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Infraestructura.Entidades;

namespace Ventas.Infraestructura.Repositorios
{
    public interface IClienteRepository
    {
        Task<bool> AddAsync(Cliente cliente);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdentificacionAsync(string identificacion); 
    }
}
