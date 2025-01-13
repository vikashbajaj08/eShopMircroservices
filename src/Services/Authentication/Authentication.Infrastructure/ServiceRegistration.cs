using Authentication.Application.Repositories;
using Authentication.Infrastructure.Data;
using Authentication.Infrastructure.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Extensions.Logging;


namespace Authentication.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterInfrastructureService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AuthenticationDbContext>(option =>{
                option.UseSqlServer(configuration.GetConnectionString("AuthenticationDatabase"));
            });

            Log.Logger = new LoggerConfiguration().
                ReadFrom.Configuration(configuration).CreateLogger();

            services.AddScoped<IUserRepository, UserRepository>();

            //AutoMapper
            services.AddAutoMapper(typeof(Authentication.Application.MappingProfile.UserMappingProfile));
            return services;
        }
    }
}
