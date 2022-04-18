using HR.Platform.Application.Common.Interfaces;
using HR.Platform.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Platform.Infrastructure.DIExtensions
{
    public static class DBExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            if (Convert.ToBoolean(configuration["UseInMemoryDatabase"]))
            {
                //services.AddDbContext<HRDBContext>(options =>
                //    options.UseInMemoryDatabase("CleanArchitectureDb"));
            }
            else
            {
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                services.AddDbContext<HRDBContext>(options =>
                    options.UseNpgsql(
                        configuration.GetConnectionString("DefaultConnection")));
            }

            services.AddScoped<IHRDbContext>(provider => provider.GetRequiredService<HRDBContext>());
            return services;
        }
    }
}
