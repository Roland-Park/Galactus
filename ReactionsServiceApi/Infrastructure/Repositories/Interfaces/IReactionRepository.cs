using ReactionsServiceApi.Entities;

namespace ReactionsServiceApi.Infrastructure.Repositories.Interfaces;

public interface IReactionRepository : IRepositoryBase
{
    Task<Reaction> GetRandomReaction();
    Task<Reaction> AddReaction(Reaction reaction);
    Task<Reaction> GetReactionById(int id);
}
