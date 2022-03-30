using ReactionsServiceApi.Entities;
using ReactionsServiceApi.Models.Moods;

namespace ReactionsServiceApi.Infrastructure.Factories.Interfaces;

public interface IMessageBusModelFactory
{
    PublishReactionbotMoodModel Build(Mood mood);
}
