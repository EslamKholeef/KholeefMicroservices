using Identity.Domain.Entities;
using Identity.Domain.Interfaces;
using Identity.Infrastructure.Dtata;
using Identity.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Identity.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string sqlConnectionString)
        {
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(sqlConnectionString));

            services.AddIdentity<AppUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
