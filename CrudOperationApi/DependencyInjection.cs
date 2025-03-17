using Microsoft.OpenApi.Models;

namespace CrudOperationApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            // client connection time enable with specific URLS
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigin",
            //        builder => builder.WithOrigins("http://localhost:4200")
            //                          .AllowAnyHeader()
            //                          .AllowAnyMethod());
            //});
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
    }
}
