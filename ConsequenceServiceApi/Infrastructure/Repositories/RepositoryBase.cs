using ConsequenceServiceApi.Infrastructure.Data;

namespace ConsequenceServiceApi.Infrastructure.Repositories;

public class RepositoryBase
{
    private readonly ConsequenceDbContext context;
    public RepositoryBase(ConsequenceDbContext context)
    {
        this.context = context;
    }

    public async Task<bool> SaveChanges()
    {
        return (await context.SaveChangesAsync() >= 0);
    }
}
