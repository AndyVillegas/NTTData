using AutoMapper;
using Domain.Dtos.Cuentas;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository _CuentaRepository;
        private readonly IMapper _mapper;
        public CuentaService(ICuentaRepository CuentaRepository,
            IMapper mapper)
        {
            _CuentaRepository = CuentaRepository;
            _mapper = mapper;
        }
        public async Task<Cuenta> Create(CreateCuentaDto create)
        {
            var entity = _mapper.Map<Domain.Entities.Cuenta>(create);
            entity.Saldo = entity.SaldoInicial;
            _CuentaRepository.Create(entity);
            await _CuentaRepository.Save();
            return _mapper.Map<Cuenta>(entity);
        }

        public async Task Delete(int id)
        {
            await _CuentaRepository.Delete(id);
            await _CuentaRepository.Save();
        }

        public async Task<Cuenta> Get(int id)
        {
            var model = await _CuentaRepository.Get(id);
            return _mapper.Map<Cuenta>(model);
        }

        public async Task<IEnumerable<Cuenta>> GetAll()
        {
            var Cuentas = await _CuentaRepository.GetAll();
            return _mapper.Map<IEnumerable<Cuenta>>(Cuentas);
        }

        public async Task Update(int id, UpdateCuentaDto update)
        {
            var model = await _CuentaRepository.Get(id);
            _mapper.Map(update, model);
            _CuentaRepository.Update(model);
            await _CuentaRepository.Save();
        }
    }
}
