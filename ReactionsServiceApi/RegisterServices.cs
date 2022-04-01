using Microsoft.EntityFrameworkCore;
using ReactionsServiceApi.Infrastructure;
using ReactionsServiceApi.Infrastructure.Configs;
using ReactionsServiceApi.Infrastructure.Data;
using ReactionsServiceApi.Infrastructure.Factories;
using ReactionsServiceApi.Infrastructure.Factories.Interfaces;
using ReactionsServiceApi.Infrastructure.Repositories;
using ReactionsServiceApi.Infrastructure.Repositories.Interfaces;
using ReactionsServiceApi.Infrastructure.Services.AsynchronousData;
using ReactionsServiceApi.Infrastructure.Services.AsynchronousData.Interfaces;
using ReactionsServiceApi.Infrastructure.Services.SynchronousData;
using ReactionsServiceApi.Infrastructure.Services.SynchronousData.Interfaces;

namespace ReactionsServiceApi;

public static class RegisterServices
{
    public static void ConfigureServices(this WebApplicationBuilder builder, string corsPolicyName)
    {
        string dbName = "InMemoryReactionDb";

        ConfigureCors(builder, corsPolicyName);
        ConfigureDatabaseContext(builder, dbName);
        ConfigureDependencyInjection(builder);
        ConfigureAppSettingsConfigs(builder);

        builder.Services.AddAutoMapper((typeof(ReactionsApiMapper).Assembly));
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
        builder.Services.AddDbContext<ReactionsDbContext>(o =>
            o.UseInMemoryDatabase(dbName));
    }

    private static void ConfigureDependencyInjection(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IReactionRepository, ReactionRepository>();
        builder.Services.AddScoped<IReactionFactory, ReactionFactory>();
        builder.Services.AddScoped<IMessageBusModelFactory, MessageBusModelFactory>();

        builder.Services.AddHttpClient<IServicesHttpClient, ServicesHttpClient>();

        builder.Services.AddSingleton<IMessageBus, RabbitMqMessageBus>();
    }

    private static void ConfigureAppSettingsConfigs(WebApplicationBuilder builder)
    {
        builder.Services.Configure<RabbitMQConfig>(builder.Configuration.GetSection("RabbitMQConfig"));
    }
}
