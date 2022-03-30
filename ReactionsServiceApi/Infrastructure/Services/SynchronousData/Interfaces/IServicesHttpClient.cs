using ReactionsServiceApi.Entities;

namespace ReactionsServiceApi.Infrastructure.Services.SynchronousData.Interfaces;

public interface IServicesHttpClient
{
    Task<List<Mood>> GetMoods();
}
