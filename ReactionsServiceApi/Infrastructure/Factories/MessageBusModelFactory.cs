using AutoMapper;
using ReactionsServiceApi.Entities;
using ReactionsServiceApi.Infrastructure.Factories.Interfaces;
using ReactionsServiceApi.Models.Moods;

namespace ReactionsServiceApi.Infrastructure.Factories;

public class MessageBusModelFactory : IMessageBusModelFactory
{
    private readonly IMapper mapper;
    public MessageBusModelFactory(IMapper mapper)
    {
        this.mapper = mapper;
    }
    public PublishReactionbotMoodModel Build(Mood mood)
    {
        return mapper.Map<PublishReactionbotMoodModel>(mood);
    }
}
