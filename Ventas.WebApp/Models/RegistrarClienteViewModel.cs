using System.ComponentModel.DataAnnotations;

namespace Ventas.WebApp.Models
{
    public class RegistrarClienteViewModel 
    {
        [Required(ErrorMessage = "La identificación es obligatoria.")]
        [StringLength(50, ErrorMessage = "La identificación no puede exceder 50 caracteres.")]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(200, ErrorMessage = "El nombre no puede exceder 200 caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [StringLength(10, ErrorMessage = "El teléfono no puede exceder 10 caracteres.")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [StringLength(200, ErrorMessage = "La dirección no puede exceder 200 caracteres.")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
    }
}
