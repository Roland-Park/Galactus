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
                new Reaction() { Id = 1, Body = "Ooof" },
                new Reaction() { Id = 2, Body = "UwU <3" },
                new Reaction() { Id = 3, Body = "ooh yeah" },
                new Reaction() { Id = 4, Body = "ouch!" },
                new Reaction() { Id = 5, Body = ":(" },
                new Reaction() { Id = 6, Body = ":'(" },
                new Reaction() { Id = 7, Body = "whyyyy" },
                new Reaction() { Id = 8, Body = "owie!" },
                new Reaction() { Id = 9, Body = "harder" },
                new Reaction() { Id = 10, Body = "uhhhh" },
                new Reaction() { Id = 11, Body = "I'm sorry pleeeease don't do it again! I'll be good! please please oh god stop" },
                new Reaction() { Id = 12, Body = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA" },
                new Reaction() { Id = 13, Body = "I deserve this" });

            context.SaveChanges();
        }
    }
}
