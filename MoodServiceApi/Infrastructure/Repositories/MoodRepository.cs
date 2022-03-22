using Microsoft.EntityFrameworkCore;
using MoodServiceApi.Entities;
using MoodServiceApi.Infrastructure.Data;
using MoodServiceApi.Infrastructure.Repositories.Interfaces;

namespace MoodServiceApi.Infrastructure.Repositories;

public class MoodRepository : RepositoryBase, IMoodRepository
{
    private readonly MoodDbContext context;
    public MoodRepository(MoodDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task<List<Mood>> GetAllMoods()
    {
        return await context.Moods.ToListAsync();
    }
}
