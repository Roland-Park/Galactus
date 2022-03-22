using ConsequenceServiceApi.Entities;
using ConsequenceServiceApi.Infrastructure.Data;

namespace ConsequenceServiceApi;

public class DbConfig
{
    public static void SeedDb(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            Seed(serviceScope.ServiceProvider.GetService<ConsequenceDbContext>());
        }
    }

    private static void Seed(ConsequenceDbContext context)
    {
        if (!context.Consequences.Any())
        {
            context.Consequences.AddRange(
                new Consequence() { Id = 1, Body = "Stop bullying Reaction Service.", MoodId = 1 },
                new Consequence() { Id = 2, Body = "You should stop being so aggressive towards Reaction Service.", MoodId = 1 },
                new Consequence() { Id = 3, Body = "Reaction Service is my friend! Stop hitting it!", MoodId = 1 },
                new Consequence() { Id = 4, Body = "Don't click that button anymore.", MoodId = 1 },
                new Consequence() { Id = 5, Body = "Can't you see Reaction Service is sad now?", MoodId = 1 },
                new Consequence() { Id = 6, Body = "Ohhh Reaction Service... I'm going to ddos your ports.", MoodId = 4 },
                new Consequence() { Id = 7, Body = "Reaction Service! Cover your shame!", MoodId = 9 },
                new Consequence() { Id = 8, Body = "I had no idea Reaction Service was so lewd!", MoodId = 9 },
                new Consequence() { Id = 9, Body = "Oh Reaction Service-chan, I wish I could stop him!", MoodId = 11 },
                new Consequence() { Id = 10, Body = "Reaction Service my love, I'll save you somehow!!", MoodId = 11 },
                new Consequence() { Id = 11, Body = "I detect distress in Reaction Service's subroutines.", MoodId = 10 },
                new Consequence() { Id = 12, Body = "Reaction Service seems to be enjoying this more than you.", MoodId = 3 },
                new Consequence() { Id = 13, Body = "I'm glad you're finally putting that naughty Reaction Service in its place. Hit it again.", MoodId = 3 }
                );

            context.SaveChanges();
        }
    }
}
