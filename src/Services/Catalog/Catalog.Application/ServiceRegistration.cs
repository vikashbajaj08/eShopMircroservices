using Catalog.Application.Behaviour;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterApplicationService(this IServiceCollection services) 
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
