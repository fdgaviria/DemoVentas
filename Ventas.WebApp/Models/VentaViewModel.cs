using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Ventas.WebApp.Models
{
    public class VentaViewModel
    {
        [Required(ErrorMessage = "El código de venta es obligatorio.")]
        [StringLength(20, ErrorMessage = "El código de venta no puede exceder 20 caracteres.")]
        [Display(Name = "Código Venta")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El código de producto es obligatorio.")]
        [StringLength(20, ErrorMessage = "El código de producto no puede exceder 20 caracteres.")]
        [Display(Name = "Código Producto")]
        public string Producto { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El punto de venta es obligatorio.")]
        [Display(Name = "Punto de Venta NIT")]
        public string PuntoVentaNit { get; set; }

        [Display(Name = "Punto de Venta")] 
        public string PuntoVentaNombre { get; set; } = "N/A";

        [Required(ErrorMessage = "El cliente es obligatorio.")]
        [Display(Name = "Identificación Cliente")]
        public string ClienteIdentificacion { get; set; }

        [Display(Name = "Cliente")] 

        public string ClienteNombre { get; set; } = "N/A";

        [Required(ErrorMessage = "El total es obligatorio.")]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "El total debe ser mayor a cero.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Total")]
        public decimal Total { get; set; }
    }
}
