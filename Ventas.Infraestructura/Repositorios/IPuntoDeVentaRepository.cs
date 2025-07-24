using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Infraestructura.Entidades;
namespace Ventas.Infraestructura.Repositorios
{
    public interface IPuntoDeVentaRepository
    {
        Task<IEnumerable<PuntoDeVenta>> GetAllAsync();
    }
}