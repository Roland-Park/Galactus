using MoodServiceApi.Entities;
using MoodServiceApi.Infrastructure.Data;

namespace MoodServiceApi;

public class DbConfig
{
    public static void SeedDb(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            Seed(serviceScope.ServiceProvider.GetService<MoodDbContext>());
        }
    }

    private static void Seed(MoodDbContext context)
    {
        if (!context.Moods.Any())
        {
            context.Moods.AddRange(
                new Mood() { Id = 1, Name = "Angry" },
                new Mood() { Id = 2, Name = "Sad" },
                new Mood() { Id = 3, Name = "Happy" },
                new Mood() { Id = 4, Name = "Horny" },
                new Mood() { Id = 5, Name = "Scared" },
                new Mood() { Id = 6, Name = "Anxious" },
                new Mood() { Id = 7, Name = "Accepting" },
                new Mood() { Id = 8, Name = "Terrified" },
                new Mood() { Id = 9, Name = "Embarrassed" },
                new Mood() { Id = 10, Name = "Neutral" },
                new Mood() { Id = 11, Name = "Despairing" }
                );

            context.SaveChanges();
        }
    }
}
