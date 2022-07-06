using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SouthWestContractors.Application
{
    public static class ApplicationServicesRegistration
    {
        //using Microsoft.Extensions.DependencyInjection which is part os the
        //FluentValidation.DependencyInjectionExtensions
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());           
            return services;

        }
    }
}
