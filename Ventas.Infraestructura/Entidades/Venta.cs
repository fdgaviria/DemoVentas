using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.Infraestructura.Entidades
{
    public class Venta
    {
        public string ven_codigo { get; set; }
        public DateTime ven_fecha { get; set; }
        public string ven_cli_identificacion { get; set; }
        public string cli_nombre { get; set; } 
        public string ven_punven_nit { get; set; }
        public string punven_nombre { get; set; }
        public string ven_producto { get; set; }
        public decimal ven_total { get; set; }
    }
}
