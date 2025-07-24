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
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            // Mapeo de Entidad a DTO
            CreateMap<Cliente, ClienteDto>()
                .ForMember(dest => dest.Identificacion, opt => opt.MapFrom(src => src.cli_identificacion))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.cli_nombre))
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.cli_telefono))
                .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.cli_direccion));

            // Mapeo de DTO de Registro a Entidad
            CreateMap<RegistrarClienteDto, Cliente>()
                .ForMember(dest => dest.cli_identificacion, opt => opt.MapFrom(src => src.Identificacion))
                .ForMember(dest => dest.cli_nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.cli_telefono, opt => opt.MapFrom(src => src.Telefono))
                .ForMember(dest => dest.cli_direccion, opt => opt.MapFrom(src => src.Direccion));
        }
    }
}
