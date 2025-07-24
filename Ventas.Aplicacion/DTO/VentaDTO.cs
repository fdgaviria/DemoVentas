using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Aplicacion.DTO
{
    public class VentaDto
    {
        public string Codigo { get; set; }
        public DateTime Fecha { get; set; }
        public string ClienteIdentificacion { get; set; } 
        public string ClienteNombre { get; set; } 
        public string PuntoVentaNit { get; set; } 
        public string PuntoVentaNombre { get; set; } 
        public string Producto { get; set; }
        public decimal Total { get; set; }
    }
}
