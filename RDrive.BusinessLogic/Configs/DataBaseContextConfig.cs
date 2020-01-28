using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RDrive.DataAccess.DataAccept;
using RDrive.Shared.Constants;

namespace RDrive.BusinessLogic.Configs
{
    public static class DataBaseContextConfig
    {
        public static void InjectDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(AppConstants.LOCALHOST_CONNECTION_STRING_NAME)));
        }
    }
}
