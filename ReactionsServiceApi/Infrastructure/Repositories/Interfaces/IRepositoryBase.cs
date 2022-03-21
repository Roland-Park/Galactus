namespace ReactionsServiceApi.Infrastructure.Repositories.Interfaces;

public interface IRepositoryBase
{
    Task<bool> SaveChanges();
}
