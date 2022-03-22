using ConsequenceServiceApi.Entities;

namespace ConsequenceServiceApi.Infrastructure.Repositories.Interfaces;

public interface IConsequenceRepository : IRepositoryBase
{
    Task<Consequence> GetConsequenceForMood(int moodId);
}
