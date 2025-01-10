using Authentication.Application.Repositories;
using Authentication.Infrastructure.Data;
using Authentication.Infrastructure.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterInfrastructureService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AuthenticationDbContext>(option =>{
                option.UseSqlServer(configuration.GetConnectionString("AuthenticationDatabase"));
            });

            services.AddScoped<IUserRepository, UserRepository>();

            //AutoMapper
            services.AddAutoMapper(typeof(Authentication.Application.MappingProfile.UserMappingProfile));
            return services;
        }
    }
}
