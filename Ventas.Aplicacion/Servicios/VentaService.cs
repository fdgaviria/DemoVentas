using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.Aplicacion.DTO;
using Ventas.Infraestructura.Entidades;
using Ventas.Infraestructura.Repositorios;

namespace Ventas.Aplicacion.Servicios
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IMapper _mapper;

        public VentaService(IVentaRepository ventaRepository, IMapper mapper)
        {
            _ventaRepository = ventaRepository ?? throw new ArgumentNullException(nameof(ventaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<VentaDto> GetVentaByCodigoAsync(string codigo)
        {
            var venta = await _ventaRepository.GetByCodigoAsync(codigo);
            return _mapper.Map<VentaDto>(venta);
        }
        public async Task<IEnumerable<VentaDto>> GetAllVentasAsync()
        {
            var ventas = await _ventaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<VentaDto>>(ventas);
        }
        public async Task<bool> CrearVentaAsync(CrearVentaDto ventaDto)
        {
            var venta = _mapper.Map<Venta>(ventaDto);
            return await _ventaRepository.AddAsync(venta);
        }

        public async Task<bool> ActualizarVentaAsync(string codigo, ActualizarVentaDto ventaDto)
        {
            var existingVenta = await _ventaRepository.GetByCodigoAsync(codigo);
            if (existingVenta == null)
            {
                return false;
            }

            _mapper.Map(ventaDto, existingVenta);
            existingVenta.ven_codigo = codigo;

            return await _ventaRepository.UpdateAsync(existingVenta);
        }

        public async Task<bool> EliminarVentaAsync(string codigo)
        {
            return await _ventaRepository.DeleteAsync(codigo);
        }
    }
}
