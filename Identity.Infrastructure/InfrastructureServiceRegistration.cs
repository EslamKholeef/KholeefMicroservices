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

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                //Eslam: Password validation rules
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;

                //Eslam: Email/UserName validation rules
                options.User.RequireUniqueEmail = true;
                //Eslam: We can allow specific characters in UserName if needed
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ "; //Eslam: Last One Is Space
            })
            .AddEntityFrameworkStores<IdentityDbContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
