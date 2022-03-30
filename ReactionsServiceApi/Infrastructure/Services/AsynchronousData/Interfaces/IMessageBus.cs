using ReactionsServiceApi.Models.Moods;

namespace ReactionsServiceApi.Infrastructure.Services.AsynchronousData.Interfaces;

public interface IMessageBus
{
    void PublishMood(PublishReactionbotMoodModel mood);
}
