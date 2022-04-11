using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DI
{
    public static class DIDependency
    {
        public static void AddDIDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapperDependency();
            services.AddContextDependency(configuration);
            services.AddRepositoryDependency();
            services.AddServiceDependency();
        }
    }
}
