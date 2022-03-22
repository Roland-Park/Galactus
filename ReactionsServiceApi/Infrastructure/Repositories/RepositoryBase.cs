using ReactionsServiceApi.Infrastructure.Data;
using ReactionsServiceApi.Infrastructure.Repositories.Interfaces;

namespace ReactionsServiceApi.Infrastructure.Repositories;

public abstract class RepositoryBase : IRepositoryBase
{
    private readonly ReactionsDbContext context;
    public RepositoryBase(ReactionsDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> SaveChanges()
    {
        return (await context.SaveChangesAsync() >= 0);
    }
}
