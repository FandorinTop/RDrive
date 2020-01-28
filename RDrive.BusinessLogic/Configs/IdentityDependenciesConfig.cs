using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using RDrive.DataAccess.DataAccept;
using RDrive.Entities.Entities;
using RDrive.Shared.Constants;

namespace RDrive.BusinessLogic.Configs
{
    public static class IdentityDependenciesConfig
    {
        public static void InjectApplicationIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<AppUser, ApplicationRole>()
                 .AddEntityFrameworkStores<ApplicationDbContext>()
                 .AddDefaultTokenProviders();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(2);

                options.Cookie.Name = AppConstants.APPLICATION_COOKIE_NAME;

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/";
                options.SlidingExpiration = true;
            });
        }
    }
}
