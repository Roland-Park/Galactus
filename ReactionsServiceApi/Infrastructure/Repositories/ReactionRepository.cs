using Microsoft.EntityFrameworkCore;
using ReactionsServiceApi.Entities;
using ReactionsServiceApi.Infrastructure.Data;
using ReactionsServiceApi.Infrastructure.Repositories.Interfaces;

namespace ReactionsServiceApi.Infrastructure.Repositories;

public class ReactionRepository : RepositoryBase, IReactionRepository
{
    private readonly ReactionsDbContext context;
    public ReactionRepository(ReactionsDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<Reaction> AddReaction(Reaction reaction)
    {
        if(reaction == null || string.IsNullOrWhiteSpace(reaction.Body))
        {
            return null;
        }

        await context.AddAsync(reaction);
        return reaction;
    }

    public async Task<Reaction> GetRandomReaction()
    {
        var r = new Random();

        var reactions = await context.Reactions.ToListAsync();
        if (!reactions.Any())
        {
            return null;
        } 

        return reactions[r.Next(0, reactions.Count - 1)];
    }

    public async Task<Reaction> GetReactionById(int id)
    {
        return await context.Reactions.FirstOrDefaultAsync(x => x.Id == id);
    }
}
