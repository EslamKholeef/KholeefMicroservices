using Identity.Application.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));
            services.AddAutoMapper(typeof(IdentityMappingProfile));

            return services;
        }
    }
}
