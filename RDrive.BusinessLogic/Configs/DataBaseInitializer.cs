using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using RDrive.DataAccess.DataAccept;
using RDrive.Entities.Entities;
using RDrive.Shared.Constants;


namespace RDrive.BusinessLogic.Configs
{
    public static class DataBaseInitializer
    {
        public async static Task InitializeDB(this IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

            IdentityResult roleResult;

            bool adminRoleCheck = await roleManager.RoleExistsAsync(AppConstants.SUPER_ADMIN_ROLE);
            if (!adminRoleCheck)
            {
                roleResult = await roleManager.CreateAsync(new ApplicationRole(AppConstants.SUPER_ADMIN_ROLE));
                await CreateAdminUser(userManager);
            }

            bool userRoleCheck = await roleManager.RoleExistsAsync(AppConstants.CLIENT_ROLE);
            if (!userRoleCheck)
            {
                roleResult = await roleManager.CreateAsync(new ApplicationRole(AppConstants.CLIENT_ROLE));
            }

            bool driverRoleCheck = await roleManager.RoleExistsAsync(AppConstants.DRIVER_ROLE);
            if (!driverRoleCheck)
            {
                roleResult = await roleManager.CreateAsync(new ApplicationRole(AppConstants.DRIVER_ROLE));
            }

            bool localAdminRoleCheck = await roleManager.RoleExistsAsync(AppConstants.ADMIN_ROLE);
            if (!localAdminRoleCheck)
            {
                roleResult = await roleManager.CreateAsync(new ApplicationRole(AppConstants.ADMIN_ROLE));
            }
        }
        private async static Task CreateAdminUser(UserManager<AppUser> userManager)
        {
            var email = "admin@admin.com";
            var password = "Admin123!";

            var user = new AppUser();
            user.UserName = "Admin";
            user.NormalizedEmail = email.ToUpper();
            user.NormalizedUserName = email.ToUpper();
            user.Email = email;
            user.EmailConfirmed = true;
            user.FirstName = "FAdmin";
            user.LastName = "LAdmin";
            user.MiddleName = "MADMIN";
            user.BirthDate = new DateTime(2000, 5, 6);
            user.AddressLine = "AddressLine 11 11 11";
            user.PhoneNumber = "+380556688777";
            user.EmailConfirmed = true;

            await userManager.CreateAsync(user, password);
            AppUser applicationUser = await userManager.FindByEmailAsync(user.NormalizedEmail);

            await userManager.AddToRoleAsync(applicationUser, AppConstants.SUPER_ADMIN_ROLE);
        }
    }
}
