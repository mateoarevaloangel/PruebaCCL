using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection services, IConfiguration configuration)
        {
            

            return services;
        }
    }
}
