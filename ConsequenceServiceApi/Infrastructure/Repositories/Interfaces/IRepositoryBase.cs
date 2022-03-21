namespace ConsequenceServiceApi.Infrastructure.Repositories.Interfaces;

public interface IRepositoryBase
{
    Task<bool> SaveChanges();
}
