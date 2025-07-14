using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Order.Domain.Interfaces;
using Order.Infrastructure.Data;
using Order.Infrastructure.Repositories;


namespace Order.Infrastructure
{
    public static class OrderInfrastructureServiceRegistration
    {
        public static IServiceCollection AddOrderInfrastructureServices( this IServiceCollection services, string sqlConnectionString)
        {
            services.AddDbContext<OrderDbContext>(options =>
            options.UseSqlServer(sqlConnectionString, builder =>
        builder.MigrationsAssembly(typeof(OrderDbContext).Assembly.FullName)));

            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
