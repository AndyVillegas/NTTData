using AutoMapper;
using Domain.Dtos.Clientes;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository clienteRepository,
            IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public async Task<Cliente> Create(CreateClienteDto create)
        {
            var entity = _mapper.Map<Domain.Entities.Cliente>(create);
            _clienteRepository.Create(entity);
            await _clienteRepository.Save();
            return _mapper.Map<Cliente>(entity);
        }

        public async Task Delete(int id)
        {
            await _clienteRepository.Delete(id);
            await _clienteRepository.Save();
        }

        public async Task<Cliente> Get(int id)
        {
            var model = await _clienteRepository.Get(id);
            return _mapper.Map<Cliente>(model);
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            var clientes = await _clienteRepository.GetAll();
            return _mapper.Map<IEnumerable<Cliente>>(clientes);
        }

        public async Task Update(int id, UpdateClienteDto update)
        {
            var model = await _clienteRepository.Get(id);
            _mapper.Map(update, model);
            _clienteRepository.Update(model);
            await _clienteRepository.Save();
        }
    }
}
