using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SouthWestContractors.API
{
    public static class ApiServicesRegistration
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
           
        }
    }
}
