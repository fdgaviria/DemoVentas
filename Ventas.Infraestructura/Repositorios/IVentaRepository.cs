using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Infraestructura.Entidades;

namespace Ventas.Infraestructura.Repositorios
{
    public interface IVentaRepository
    {
        Task<Venta> GetByCodigoAsync(string codigo);
        Task<IEnumerable<Venta>> GetAllAsync();
        Task<bool> AddAsync(Venta venta);
        Task<bool> UpdateAsync(Venta venta);
        Task<bool> DeleteAsync(string codigo);
    }
}
