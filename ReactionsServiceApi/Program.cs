using ReactionsServiceApi;

var builder = WebApplication.CreateBuilder(args);

var corsPolicy = "reactionServiceCorsPolicy";
builder.ConfigureServices(corsPolicy);

var app = builder.Build();

DbConfig.SeedDb(app);

app.UseCors(corsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
