namespace Ventas.WebApp.Models
{
    public class VentasIndexViewModel
    {
        public List<VentaViewModel> Ventas { get; set; }
        public List<ClienteViewModel> Clientes { get; set; }
        public List<PuntoDeVentaViewModel> PuntosDeVenta { get; set; }

        public string FiltroCodigoVenta { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}
