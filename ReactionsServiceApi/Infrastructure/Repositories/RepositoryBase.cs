using ReactionsServiceApi.Infrastructure.Data;

namespace ReactionsServiceApi.Infrastructure.Repositories;

public abstract class RepositoryBase
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
