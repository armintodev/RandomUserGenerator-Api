using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserGenerator.Api.Data;

namespace UserGenerator.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationContext(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<ApplicationContext>(options => { options.UseSqlServer(connectionString); });
        }

        public static void AddApplicationIdentity(this IServiceCollection service)
        {
            service.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            service.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedAccount = true;
            }).ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "account/login";
                options.LogoutPath = "account/logout";
            });
        }
    }
}