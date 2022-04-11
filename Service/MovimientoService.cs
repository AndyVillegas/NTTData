using AutoMapper;
using Domain.Common.Enums;
using Domain.Dtos.Movimientos;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository _MovimientoRepository;
        private readonly ICuentaRepository _CuentaRepository;
        private readonly IParametroRepository _ParametroRepository;
        private readonly IMapper _mapper;
        public MovimientoService(IMovimientoRepository movimientoRepository,
            ICuentaRepository cuentaRepository,
            IParametroRepository parametroRepository,
            IMapper mapper)
        {
            _MovimientoRepository = movimientoRepository;
            _ParametroRepository = parametroRepository;
            _CuentaRepository = cuentaRepository;
            _mapper = mapper;
        }
        public async Task<Movimiento> Create(CreateMovimientoDto create)
        {
            var cuenta = await _CuentaRepository.Get(create.CuentaId);
            var movimiento = _mapper.Map<Domain.Entities.Movimiento>(create);
            if (create.TipoMovimiento == TipoMovimiento.Debito)
            {
                var parametro = _ParametroRepository.Get();
                if ((cuenta.Saldo - create.Valor) <= 0) throw new Domain.Exceptions.SaldoNoDisponibleException();
                var totalDiario = await GetTotalRetiroDiario(cuenta.Id);
                if((totalDiario + create.Valor) > parametro.LimiteDiarioRetiro) throw new Domain.Exceptions.CupoDiarioExcedidoException();
                movimiento.Valor = -movimiento.Valor;
            }
            cuenta.Saldo += movimiento.Valor;
            movimiento.Saldo = cuenta.Saldo;
            movimiento.Fecha = System.DateTime.Now;
            _MovimientoRepository.Create(movimiento);
            _CuentaRepository.Update(cuenta);
            await _MovimientoRepository.Save();
            return _mapper.Map<Movimiento>(movimiento);
        }

        public async Task Delete(int id)
        {
            await _MovimientoRepository.Delete(id);
            await _MovimientoRepository.Save();
        }

        public async Task<Movimiento> Get(int id)
        {
            var model = await _MovimientoRepository.Get(id);
            return _mapper.Map<Movimiento>(model);
        }

        public async Task<IEnumerable<Movimiento>> GetAll()
        {
            var Movimientos = await _MovimientoRepository.GetAll();
            return _mapper.Map<IEnumerable<Movimiento>>(Movimientos);
        }

        public async Task Update(int id, UpdateMovimientoDto update)
        {
            var model = await _MovimientoRepository.Get(id);
            _mapper.Map(update, model);
            _MovimientoRepository.Update(model);
            await _MovimientoRepository.Save();
        }
        private async Task<decimal> GetTotalRetiroDiario(int cuentaId)
        {
            var movimientos = await _MovimientoRepository.GetAll(new Domain.Queries.MovimientoQuery
            {
                CuentaId = cuentaId,
                Fecha = System.DateTime.Now
            });
            return movimientos.Where(e => e.Valor < 0).Sum(m => m.Valor);
        }
    }
}
