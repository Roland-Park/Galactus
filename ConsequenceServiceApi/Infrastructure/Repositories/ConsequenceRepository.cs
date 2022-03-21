using ConsequenceServiceApi.Entities;
using ConsequenceServiceApi.Infrastructure.Data;
using ConsequenceServiceApi.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConsequenceServiceApi.Infrastructure.Repositories;

public class ConsequenceRepository : RepositoryBase, IConsequenceRepository
{
    private readonly ConsequenceDbContext context;
    public ConsequenceRepository(ConsequenceDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<Consequence> GetConsequenceForMood(Mood mood)
    {
        var r = new Random();

        var consequences = await context.Consequences.Where(x => x.Mood == mood).ToListAsync();
        if (!consequences.Any())
        {
            return null;
        }

        var consequence = consequences[r.Next(0, consequences.Count - 1)];
        return consequence;
    }
}
