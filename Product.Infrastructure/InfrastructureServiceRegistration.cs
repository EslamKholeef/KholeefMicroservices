using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Product.Domain.Interfaces;
using Product.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IMongoClient>(sp => new MongoClient(connectionString));

            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
