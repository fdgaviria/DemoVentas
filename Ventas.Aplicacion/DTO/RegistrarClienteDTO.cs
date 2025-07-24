using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Aplicacion.DTO
{
    public class RegistrarClienteDto
    {
        [Required]
        [StringLength(50)]
        public string Identificacion { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [StringLength(10)]
        public string Telefono { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }
    }
}
