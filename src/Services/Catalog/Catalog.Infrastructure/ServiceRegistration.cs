using Catalog.Application.MappingProfile;
using Catalog.Domain.Interface;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterInfrastrucureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CatalogDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("CatalogDatabase"));
            });

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddAutoMapper(typeof(ProductMappingProfile));
            return services;
        }
    }
}
