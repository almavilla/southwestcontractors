using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SouthWestContractors.Application.Contracts.Persistence;
using SouthWestContractors.Persistence.Repositories;

namespace SouthWestContractors.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
         
            services.AddDbContext<SouthWestContractorsDbContext>(options =>
            options.UseSqlServer(configuration
            .GetConnectionString("SouthWestContractorsConnectionString")));
        
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IContractorCategoryRepository, ContractorCategoryRepository>();
            return services;
        }
       

    }
}
