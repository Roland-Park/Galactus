using ConsequenceServiceApi;
using ConsequenceServiceApi.Infrastructure;
using ConsequenceServiceApi.Infrastructure.Data;
using ConsequenceServiceApi.Infrastructure.Factories;
using ConsequenceServiceApi.Infrastructure.Factories.Interfaces;
using ConsequenceServiceApi.Infrastructure.Repositories;
using ConsequenceServiceApi.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string dbName = "InMemoryConsequenceDb";
builder.Services.AddDbContext<ConsequenceDbContext>(o =>
    o.UseInMemoryDatabase(dbName));


builder.Services.AddScoped<IConsequenceRepository, ConsequenceRepository>();
builder.Services.AddScoped<IConsequenceFactory, ConsequenceFactory>();

builder.Services.AddAutoMapper((typeof(ConsequenceApiMapper).Assembly));

builder.Services.AddControllers();

var app = builder.Build();
DbConfig.SeedDb(app);

app.UseAuthorization();

app.MapControllers();

app.Run();