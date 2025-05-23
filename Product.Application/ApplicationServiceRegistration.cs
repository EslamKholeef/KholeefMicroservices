using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Commands.CreateCommand;
using Product.Application.Commands.UpdateCommand;
using Product.Application.Helpers;

namespace Product.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));
            services.AddAutoMapper(typeof(ProductMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateProductCommandValidator>();

            return services;
        }
    }
}
