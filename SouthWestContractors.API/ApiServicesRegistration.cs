using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SouthWestContractors.API.Services;
using SouthWestContractors.Application.Contracts;
using System;
using System.Reflection;

namespace SouthWestContractors.API
{
    public static class ApiServicesRegistration
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddHttpContextAccessor();
            services.AddScoped<ILoggedInUserService, LoggedInUserService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            return services;
           
        }
    }
}
