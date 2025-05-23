using Microsoft.Extensions.DependencyInjection;
using Product.Application.Helpers;

namespace Product.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));
            services.AddAutoMapper(typeof(ProductMappingProfile));

            return services;
        }
    }
}
