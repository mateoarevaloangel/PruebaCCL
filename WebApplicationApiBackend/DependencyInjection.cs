using Application;
using Infrastructure;
using Core;

namespace WebApplicationApiBackend
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI()
                .AddCoreDI(configuration);

            return services;
        }
    }
}
