using ConsequenceServiceApi.Infrastructure;
using ConsequenceServiceApi.Infrastructure.Configs;
using ConsequenceServiceApi.Infrastructure.Data;
using ConsequenceServiceApi.Infrastructure.Factories;
using ConsequenceServiceApi.Infrastructure.Factories.Interfaces;
using ConsequenceServiceApi.Infrastructure.Repositories;
using ConsequenceServiceApi.Infrastructure.Repositories.Interfaces;
using ConsequenceServiceApi.Infrastructure.Services.AsynchronousData;
using Microsoft.EntityFrameworkCore;

namespace ConsequenceServiceApi;

public static class RegisterServices
{
    public static void ConfigureServices(this WebApplicationBuilder builder, string corsPolicyName)
    {
        string dbName = "InMemoryConsequenceDb";

        ConfigureCors(builder, corsPolicyName);
        ConfigureDatabaseContext(builder, dbName);
        ConfigureAppSettingsConfigs(builder);
        ConfigureDependencyInjection(builder);

        builder.Services.AddAutoMapper((typeof(ConsequenceApiMapper).Assembly));
        builder.Services.AddControllers();
    }

    private static void ConfigureCors(WebApplicationBuilder builder, string corsPolicyName)
    {
        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy(corsPolicyName,
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }

    private static void ConfigureDatabaseContext(WebApplicationBuilder builder, string dbName)
    {
        builder.Services.AddDbContext<ConsequenceDbContext>(o =>
            o.UseInMemoryDatabase(dbName));
    }

    private static void ConfigureDependencyInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IConsequenceRepository, ConsequenceRepository>();
        builder.Services.AddScoped<IConsequenceFactory, ConsequenceFactory>();

        builder.Services.AddHostedService<RabbitMQMessageBusSubscriber>();
    }

    private static void ConfigureAppSettingsConfigs(WebApplicationBuilder builder)
    {
        builder.Services.Configure<RabbitMQConfig>(builder.Configuration.GetSection("RabbitMQConfig"));
    }
}
