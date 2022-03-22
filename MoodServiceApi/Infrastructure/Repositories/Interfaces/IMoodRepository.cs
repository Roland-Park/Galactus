using MoodServiceApi.Entities;

namespace MoodServiceApi.Infrastructure.Repositories.Interfaces;

public interface IMoodRepository : IRepositoryBase
{
    Task<List<Mood>> GetAllMoods();
}
