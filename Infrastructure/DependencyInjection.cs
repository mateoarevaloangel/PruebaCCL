using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.NetworkInformation;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            //conection string in file json
            services.AddDbContext<AppDBContext>(options =>{
                options.UseNpgsql("Host= localhost; Port=5432; Database=TestServer; Username=postgres; Password=1234");
            });
            
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }

    }
}
