using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SouthWestContractors.Application.Contracts.Infrastructure;
using SouthWestContractors.Application.Models.Mail;
using SouthWestContractors.Infrastructure.Mail;

namespace SouthWestContractors.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
