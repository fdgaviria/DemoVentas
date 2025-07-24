using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Aplicacion.DTO
{
    public class ActualizarVentaDto
    {

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(50)]
        public string ClienteIdentificacion { get; set; }

        [Required]
        [StringLength(9)]
        public string PuntoVentaNit { get; set; }

        [Required]
        [StringLength(20)]
        public string Producto { get; set; }

        [Required]
        [Range(0.01, (double)decimal.MaxValue)]
        public decimal Total { get; set; }
    }
}
