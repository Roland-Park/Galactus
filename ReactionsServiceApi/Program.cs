﻿using Microsoft.EntityFrameworkCore;
using ReactionsServiceApi;
using ReactionsServiceApi.Infrastructure;
using ReactionsServiceApi.Infrastructure.Data;
using ReactionsServiceApi.Infrastructure.Factories;
using ReactionsServiceApi.Infrastructure.Factories.Interfaces;
using ReactionsServiceApi.Infrastructure.Repositories;
using ReactionsServiceApi.Infrastructure.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string dbName = "InMemoryReactionDb";
builder.Services.AddDbContext<ReactionsDbContext>(o =>
    o.UseInMemoryDatabase(dbName));


builder.Services.AddScoped<IReactionRepository, ReactionRepository>();
builder.Services.AddScoped<IReactionFactory, ReactionFactory>();

builder.Services.AddAutoMapper((typeof(ReactionsApiMapper).Assembly));

builder.Services.AddControllers();

var app = builder.Build();
DbConfig.SeedDb(app);

app.UseAuthorization();

app.MapControllers();

app.Run();
