using Microsoft.EntityFrameworkCore;
using ReactionsServiceApi;
using ReactionsServiceApi.Infrastructure;
using ReactionsServiceApi.Infrastructure.Data;
using ReactionsServiceApi.Infrastructure.Factories;
using ReactionsServiceApi.Infrastructure.Factories.Interfaces;
using ReactionsServiceApi.Infrastructure.Repositories;
using ReactionsServiceApi.Infrastructure.Repositories.Interfaces;
using ReactionsServiceApi.Infrastructure.Services;
using ReactionsServiceApi.Infrastructure.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var policy = "cors";
builder.Services.AddCors(opt =>
{
    opt.AddPolicy(policy,
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

string dbName = "InMemoryReactionDb";
builder.Services.AddDbContext<ReactionsDbContext>(o =>
    o.UseInMemoryDatabase(dbName));


builder.Services.AddScoped<IReactionRepository, ReactionRepository>();
builder.Services.AddScoped<IReactionFactory, ReactionFactory>();
builder.Services.AddHttpClient<IServicesHttpClient, ServicesHttpClient>();

builder.Services.AddAutoMapper((typeof(ReactionsApiMapper).Assembly));

builder.Services.AddControllers();

var app = builder.Build();
DbConfig.SeedDb(app);

app.UseCors(policy);

app.UseAuthorization();

app.MapControllers();

app.Run();
