using Microsoft.EntityFrameworkCore;
using MoodServiceApi;
using MoodServiceApi.Infrastructure.Data;
using MoodServiceApi.Infrastructure.Factories;
using MoodServiceApi.Infrastructure.Factories.Interfaces;
using MoodServiceApi.Infrastructure.Repositories;
using MoodServiceApi.Infrastructure.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string dbName = "InMemoryMoodDb";
builder.Services.AddDbContext<MoodDbContext>(o =>
    o.UseInMemoryDatabase(dbName));

builder.Services.AddScoped<IMoodRepository, MoodRepository>();
builder.Services.AddScoped<IMoodFactory, MoodFactory>();

builder.Services.AddAutoMapper((typeof(MoodApiMapper).Assembly));

builder.Services.AddControllers();

var app = builder.Build();

DbConfig.SeedDb(app);

app.UseAuthorization();

app.MapControllers();

app.Run();
