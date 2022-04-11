using AutoMapper;
using Domain.Common.Enums;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class ReporteService : IReporteService
    {
        private readonly IMovimientoRepository _MovimientoRepository;
        public ReporteService(IMovimientoRepository movimientoRepository)
        {
            _MovimientoRepository = movimientoRepository;
        }
        public async Task<IEnumerable<EstadoCuenta>> GetEstadoCuenta(MovimientoRangoQuery query)
        {
            var movimientos = await _MovimientoRepository.GetAll(query);
            return movimientos.Select(x => new EstadoCuenta
            {
                Fecha = x.Fecha,
                Cliente = x.Cuenta.Cliente.Nombre,
                ClienteId = x.Cuenta.ClienteId,
                Cuenta = x.Cuenta.NumeroCuenta,
                CuentaId = x.CuentaId,
                Estado = x.Estado.Value,
                Movimiento = x.Valor,
                SaldoInicial = x.Saldo + -x.Valor,
                SaldoDisponible = x.Saldo,
                TipoCuenta = ((TipoCuenta)x.Cuenta.TipoCuenta).GetString()
            });
        }
    }
}
