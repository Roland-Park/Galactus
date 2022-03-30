using ConsequenceServiceApi.Entities;

namespace ConsequenceServiceApi.Infrastructure.Services.AsynchronousData.Interfaces;

public interface IMessageBus
{
    Mood SubscribeToMood();
}
