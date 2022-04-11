using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Service;

namespace DI
{
    public static class ServiceDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<ICuentaService, CuentaService>();
            services.AddScoped<IMovimientoService, MovimientoService>();
            services.AddScoped<IReporteService, ReporteService>();
        }
    }
}
