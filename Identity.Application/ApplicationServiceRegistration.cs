using FluentValidation;
using Identity.Application.Commands.LoginCommand;
using Identity.Application.Commands.RegisterCommand;
using Identity.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationServiceRegistration).Assembly));

            services.AddValidatorsFromAssemblyContaining<RegisterUserCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<LoginUserCommandValidator>();


            services.AddAutoMapper(typeof(IdentityMappingProfile));

            return services;
        }
    }
}
