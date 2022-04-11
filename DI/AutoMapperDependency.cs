using Microsoft.Extensions.DependencyInjection;
using Service.Profiles;

namespace DI
{
    public static class AutoMapperDependency
    {
        public static void AddAutoMapperDependency(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(ClienteProfile),
                typeof(MovimientoProfile),
                typeof(CuentaProfile)
                );
        }
    }
}
