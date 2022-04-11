using Api.Controllers;
using AutoMapper;
using Domain.Interfaces.Repositories;
using Moq;
using NUnit.Framework;
using Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestApi
{
    public class Tests
    {
        IMapper _mapper;
        Domain.Models.Parametro parametro;
        Domain.Entities.Cuenta cuenta;
        Mock<IMovimientoRepository> movimientoRepositoryMock;
        Mock<IParametroRepository> parametroRepositoryMock;
        Mock<ICuentaRepository> cuentaRepositoryMock;
        IEnumerable<Domain.Entities.Movimiento> movimientos;
        MovimientoService service;

        [SetUp]
        public void Setup()
        {
            parametro = new Domain.Models.Parametro
            {
                LimiteDiarioRetiro = 1000
            };
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Service.Profiles.MovimientoProfile());
            });
            _mapper = mappingConfig.CreateMapper();
            parametroRepositoryMock = new Mock<IParametroRepository>();
            parametroRepositoryMock.Setup(x => x.Get()).Returns(parametro);
            cuenta = new Domain.Entities.Cuenta
            {
                Id = 1,
                Saldo = 300
            };
            cuentaRepositoryMock = new Mock<ICuentaRepository>();
            cuentaRepositoryMock.Setup(x => x.Get(1)).Returns(Task.FromResult(cuenta));
            movimientos = new List<Domain.Entities.Movimiento>
            {
                new Domain.Entities.Movimiento{
                    Valor = 100
                },
                new Domain.Entities.Movimiento{
                    Valor = 300
                },
            };
            movimientoRepositoryMock = new Mock<IMovimientoRepository>();
            movimientoRepositoryMock.Setup(x => x.GetAll(new Domain.Queries.MovimientoQuery
            {
                CuentaId = 1,
                Fecha = System.DateTime.Now.Date
            })).Returns(Task.FromResult(movimientos));
            service = new MovimientoService(
                movimientoRepositoryMock.Object,
                cuentaRepositoryMock.Object,
                parametroRepositoryMock.Object,
                _mapper);
        }

        [Test]
        public void TestCreateMovimiento_Credito()
        {
            var controller = new MovimientosController(service);
            var response = controller.Post(new Domain.Dtos.Movimientos.CreateMovimientoDto
            {
                CuentaId = 1,
                TipoMovimiento = Domain.Common.Enums.TipoMovimiento.Credito,
                Valor = 100,
            });
            var movimiento = response.Result;
            Assert.AreEqual(movimiento.Saldo, 400);
        }

        [Test]
        public void TestCreateMovimiento_Debito()
        {
            var controller = new MovimientosController(service);
            var response = controller.Post(new Domain.Dtos.Movimientos.CreateMovimientoDto
            {
                CuentaId = 1,
                TipoMovimiento = Domain.Common.Enums.TipoMovimiento.Debito,
                Valor = 100,
            });
            var movimiento = response.Result;
            Assert.AreEqual(movimiento.Saldo, 200);
        }

        [Test]
        public void TestCreateMovimiento_SaldoNoDisponible()
        {
            Func<Task> mDelegate = async () => {
                var controller = new MovimientosController(service);
                await controller.Post(new Domain.Dtos.Movimientos.CreateMovimientoDto
                {
                    CuentaId = 1,
                    TipoMovimiento = Domain.Common.Enums.TipoMovimiento.Debito,
                    Valor = 1000,
                });
            };
            Assert.That(mDelegate, Throws.InstanceOf(typeof(Domain.Exceptions.SaldoNoDisponibleException)));
        }

        [Test]
        public void TestCreateMovimiento_CupoExcedido()
        {
            cuenta.Saldo = 2000;
            Func<Task> mDelegate = async () => {
                var controller = new MovimientosController(service);
                await controller.Post(new Domain.Dtos.Movimientos.CreateMovimientoDto
                {
                    CuentaId = 1,
                    TipoMovimiento = Domain.Common.Enums.TipoMovimiento.Debito,
                    Valor = 1500,
                });
            };
            Assert.That(mDelegate, Throws.InstanceOf(typeof(Domain.Exceptions.CupoDiarioExcedidoException)));
        }
    }
}