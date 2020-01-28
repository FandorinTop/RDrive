using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RDrive.BusinessLogic.Fabrics;
using RDrive.BusinessLogic.Fabrics.Interface;
using RDrive.BusinessLogic.Helpers;
using RDrive.BusinessLogic.Helpers;
using RDrive.BusinessLogic.Helpers.Interfaces;
using RDrive.BusinessLogic.Mappers;
using RDrive.BusinessLogic.Mappers.Interfaces;
using RDrive.BusinessLogic.Providers;
using RDrive.BusinessLogic.Providers.Interfaces;
using RDrive.BusinessLogic.Services;
using RDrive.BusinessLogic.Services.Interfaces;
using RDrive.DataAccess.Interfaces;
using RDrive.DataAccess.Repositories;
using RDrive.Entities.Entities;
namespace RDrive.BusinessLogic.Configs
{
    public static class DependenciesConfig
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            #region Register Managers
            services.AddTransient<RoleManager<ApplicationRole>>();
            services.AddTransient<UserManager<AppUser>>();
            services.AddTransient<SignInManager<AppUser>>();
            #endregion

            #region Providers
            services.AddSingleton<IEmailProvider, EmailProvider>();
            #endregion

            #region Mappers
            services.AddTransient<IAccountMapper, AccountMapper>();
            services.AddTransient<IDriverMapper, DriverMapper>();
            #endregion

            #region Helpers
            services.AddTransient<IDateParseHelper, DateParseHelper>();
            #endregion

            #region Repositories
            services.AddTransient<IDriverRepository, DriverRepositories>();
            #endregion

            #region Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAdminService, AdminService>();
            #endregion

            #region Register Fabrics
            services.AddTransient<IMenuItemsFabric, MenuItemsFabric>();
            #endregion
        }
    }
}
