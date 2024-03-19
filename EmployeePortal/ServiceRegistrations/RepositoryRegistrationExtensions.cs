using EmployeePortal.Repositories.EmployeesRepository;
using EmployeePortal.Repositories.OfferingsRepository;
using EmployeePortal.Repositories.SkillsRepository;

namespace EmployeePortal.ServiceRegistrations
{
    public static class RepositoryRegistrationExtensions
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISkillsRepository, SkillsRepository>();
            services.AddScoped<IEmployeesRepository, EmployeesRepository>();
            services.AddScoped<IOfferingRepository, OfferingsRepository>();
            return services;
        }
    }
}

