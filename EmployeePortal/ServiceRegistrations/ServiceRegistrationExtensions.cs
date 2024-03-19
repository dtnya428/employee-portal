using EmployeePortal.Services.EmployeesService;
using EmployeePortal.Services.OfferingsService;
using EmployeePortal.Services.SkillsServices;

namespace EmployeePortal.ServiceRegistrations
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ISkillsService, SkillsService>();
            services.AddScoped<IEmployeesService, EmployeesService>();
            services.AddScoped<IOfferingsService, OfferingsService>();
            return services;
        }
    }
}

