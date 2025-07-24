using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Aplicacion.DTO;
using Ventas.Infraestructura.Entidades;

namespace Ventas.Aplicacion.Mapeo
{
    public class VentaProfile : Profile
    {
        public VentaProfile()
        {
            // Mapeo de Entidad a DTO
            CreateMap<Venta, VentaDto>()
                 .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => src.ven_codigo))
                 .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.ven_fecha))
                 .ForMember(dest => dest.ClienteIdentificacion, opt => opt.MapFrom(src => src.ven_cli_identificacion))
                 .ForMember(dest => dest.ClienteNombre, opt => opt.MapFrom(src => src.cli_nombre)) 
                 .ForMember(dest => dest.PuntoVentaNit, opt => opt.MapFrom(src => src.ven_punven_nit))
                 .ForMember(dest => dest.PuntoVentaNombre, opt => opt.MapFrom(src => src.punven_nombre)) 
                 .ForMember(dest => dest.Producto, opt => opt.MapFrom(src => src.ven_producto))
                 .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.ven_total));


            // Mapeo de DTO de Creación a Entidad
            CreateMap<CrearVentaDto, Venta>()
                .ForMember(dest => dest.ven_codigo, opt => opt.MapFrom(src => src.Codigo))
                .ForMember(dest => dest.ven_fecha, opt => opt.MapFrom(src => src.Fecha))
                .ForMember(dest => dest.ven_cli_identificacion, opt => opt.MapFrom(src => src.ClienteIdentificacion))
                .ForMember(dest => dest.ven_punven_nit, opt => opt.MapFrom(src => src.PuntoVentaNit))
                .ForMember(dest => dest.ven_producto, opt => opt.MapFrom(src => src.Producto))
                .ForMember(dest => dest.ven_total, opt => opt.MapFrom(src => src.Total));

            // Mapeo de DTO de Actualización a Entidad (para actualizar propiedades)
            // Asegúrate de que el código de la venta se mantenga para la actualización
            CreateMap<ActualizarVentaDto, Venta>()
                .ForMember(dest => dest.ven_fecha, opt => opt.MapFrom(src => src.Fecha))
                .ForMember(dest => dest.ven_cli_identificacion, opt => opt.MapFrom(src => src.ClienteIdentificacion))
                .ForMember(dest => dest.ven_punven_nit, opt => opt.MapFrom(src => src.PuntoVentaNit))
                .ForMember(dest => dest.ven_producto, opt => opt.MapFrom(src => src.Producto))
                .ForMember(dest => dest.ven_total, opt => opt.MapFrom(src => src.Total))
                .ForMember(dest => dest.ven_codigo, opt => opt.Ignore()); // El código no se mapea desde el DTO de actualización
        }
    }
}
