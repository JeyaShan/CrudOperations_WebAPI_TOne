using CrudOperationApi.Domain.Interfaces;
using CrudOperationApi.Infrastructure.Data;
using CrudOperationApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CrudOperationApi.Infrastructure
{
   
        public static class DependencyInjection
        {
            public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString, IConfiguration configuration)
            {
            
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(connectionString));

            
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
            }
        }
    
}
