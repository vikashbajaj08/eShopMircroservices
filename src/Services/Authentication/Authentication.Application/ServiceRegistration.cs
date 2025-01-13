using Authentication.Application.Behaviour;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Authentication.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services) 
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(ValidationBehavior<,>).Assembly);
                config.RegisterServicesFromAssembly(typeof(LoggingBehaviour<,>).Assembly);
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>),typeof(LoggingBehaviour<,>));
            return services;
        }
    }
}
