using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ventas.Aplicacion.DTOs;
using Ventas.Infraestructura.Repositorios;

namespace Ventas.Aplicacion.Servicios
{
    public class PuntoDeVentaService : IPuntoDeVentaService
    {
        private readonly IPuntoDeVentaRepository _puntoDeVentaRepository;
        private readonly IMapper _mapper;

        public PuntoDeVentaService(IPuntoDeVentaRepository puntoDeVentaRepository, IMapper mapper)
        {
            _puntoDeVentaRepository = puntoDeVentaRepository ?? throw new ArgumentNullException(nameof(puntoDeVentaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<PuntoDeVentaDto>> GetAllPuntosDeVentaAsync()
        {
            var puntosDeVenta = await _puntoDeVentaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PuntoDeVentaDto>>(puntosDeVenta);
        }
    }
}