using Kwiz.DataAccess.Data;
using Kwiz.Infrastructure.Repositories;
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
            => options.UseNpgsql(connectionStrings, 
                b => b.MigrationsAssembly("Kwiz.DataAccess")));

        services.AddDbContext<IdentityDbContext>(options
            => options.UseNpgsql(connectionStrings,
                b => b.MigrationsAssembly("Kwiz.DataAccess")));
    }

    public static void ConfigureServices(
        this IServiceCollection services)
    {
        services.AddScoped<IQuizRepository, QuizRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<IQuestionOptionRepository, QuestionOptionRepository>();
        services.AddScoped<ISubmissionRepository, SubmissionRepository>();
    }
}
