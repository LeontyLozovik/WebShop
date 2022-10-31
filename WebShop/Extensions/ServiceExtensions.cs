using Identity.Model;
using Isentity.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.ApplicationContext;
using Repository.Interfaces;

namespace WebShop.Extensions
{
    public static class ServiceExtensions
    {
        public static WebApplicationBuilder AddDataBase(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<RepositoryContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnector")));
            return builder;
        }

        public static WebApplicationBuilder ConfigureRepositoryManager(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
            return builder;
        }

        public static WebApplicationBuilder AddIdentity(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<IdentityRepositoryContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnector")))
                .AddIdentity<AppUser, AppRole>(config =>
                {
                    config.Password.RequireNonAlphanumeric = false;
                    config.Password.RequireLowercase = false;
                    config.Password.RequireUppercase = false;
                    config.Password.RequireDigit = false;
                    config.Password.RequiredLength = 5;
                })
                .AddEntityFrameworkStores<IdentityRepositoryContext>();
            return builder;
        }
    }
}
