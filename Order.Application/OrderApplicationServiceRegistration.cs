using FluentValidation;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.Commands.CreateCommand;
using Order.Application.Mappings;


namespace Order.Application
{
    public static class OrderApplicationServiceRegistration
    {
        public static IServiceCollection AddOrderApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(OrderApplicationServiceRegistration).Assembly));
            services.AddAutoMapper(typeof(OrderMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateOrderCommandValidator>();

            return services;
        }
    }
}
