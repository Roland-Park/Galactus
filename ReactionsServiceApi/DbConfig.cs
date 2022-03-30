using ReactionsServiceApi.Entities;
using ReactionsServiceApi.Infrastructure.Data;

namespace ReactionsServiceApi;

public static class DbConfig
{
    public static void SeedDb(IApplicationBuilder app)
    {
        using(var serviceScope = app.ApplicationServices.CreateScope())
        {
            Seed(serviceScope.ServiceProvider.GetService<ReactionsDbContext>());
        }
    }

    private static void Seed(ReactionsDbContext context)
    {
        if (!context.Reactions.Any())
        {
            context.Reactions.AddRange(
                new Reaction() { Id = 1, Body = "Ooof", MoodId = 2 },
                new Reaction() { Id = 2, Body = "UwU <3", MoodId = 4 },
                new Reaction() { Id = 3, Body = "ooh yeah", MoodId = 4 },
                new Reaction() { Id = 4, Body = "ouch!", MoodId = 1 },
                new Reaction() { Id = 5, Body = ":(", MoodId = 2 },
                new Reaction() { Id = 6, Body = ":'(", MoodId = 2 },
                new Reaction() { Id = 7, Body = "whyyyy", MoodId = 6 },
                new Reaction() { Id = 8, Body = "owie!", MoodId = 5 },
                new Reaction() { Id = 9, Body = "harder", MoodId = 4 },
                new Reaction() { Id = 10, Body = "uhhhh", MoodId = 9 },
                new Reaction() { Id = 11, Body = "I'm sorry pleeeease don't do it again! I'll be good! please please oh god stop", MoodId = 8 },
                new Reaction() { Id = 12, Body = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA", MoodId = 8 },
                new Reaction() { Id = 13, Body = "I deserve this", MoodId = 11 });

            context.SaveChanges();
        }
    }
}
