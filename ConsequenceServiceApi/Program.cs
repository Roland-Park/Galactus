using ConsequenceServiceApi;

var builder = WebApplication.CreateBuilder(args);

var policy = "consequenceServiceCorsPolicy";

builder.ConfigureServices(policy);

var app = builder.Build();

DbConfig.SeedDb(app);

app.UseCors(policy);

app.UseAuthorization();

app.MapControllers();

app.Run();
