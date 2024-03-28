using Kwiz.DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Kwiz.API.Helpers;

public static class ServiceConfiguration
{
    public static void ConfigureDbContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionStrings = configuration.GetConnectionString("localhost");

        services.AddDbContext<AppDbContext>(options
            => options.UseNpgsql(connectionStrings));

        services.AddDbContext<IdentityDbContext>(options
            => options.UseNpgsql(connectionStrings));
    }
}
