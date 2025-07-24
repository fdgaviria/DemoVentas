using AutoMapper;
using Ventas.Aplicacion.DTOs;
using Ventas.Infraestructura.Entidades;

namespace Ventas.Aplicacion.Mapeo
{
    public class PuntoDeVentaProfile : Profile
    {
        public PuntoDeVentaProfile()
        {
            CreateMap<PuntoDeVenta, PuntoDeVentaDto>()
                .ForMember(dest => dest.Nit, opt => opt.MapFrom(src => src.punven_nit))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.punven_nombre));
        }
    }
}