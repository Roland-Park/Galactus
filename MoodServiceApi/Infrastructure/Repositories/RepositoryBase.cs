using MoodServiceApi.Infrastructure.Data;
using MoodServiceApi.Infrastructure.Repositories.Interfaces;

namespace MoodServiceApi.Infrastructure.Repositories;

public abstract class RepositoryBase : IRepositoryBase
{
    private readonly MoodDbContext context;
    public RepositoryBase(MoodDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> SaveChanges()
    {
        return (await context.SaveChangesAsync() >= 0);
    }
}
