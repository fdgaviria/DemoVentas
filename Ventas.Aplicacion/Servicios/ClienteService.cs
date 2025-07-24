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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> RegistrarClienteAsync(RegistrarClienteDto clienteDto)
        {
            var cliente = _mapper.Map<Cliente>(clienteDto);
            return await _clienteRepository.AddAsync(cliente);
        }

        public async Task<IEnumerable<ClienteDto>> GetAllClientesAsync()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClienteDto>>(clientes);
        }

        public async Task<ClienteDto> GetClienteByIdentificacionAsync(string identificacion)
        {
            var cliente = await _clienteRepository.GetByIdentificacionAsync(identificacion);
            return _mapper.Map<ClienteDto>(cliente);
        }
    }
}
