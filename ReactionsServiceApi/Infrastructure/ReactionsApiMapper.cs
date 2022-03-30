using AutoMapper;
using ReactionsServiceApi.Entities;
using ReactionsServiceApi.Models.Moods;
using ReactionsServiceApi.Models.Reactions;

namespace ReactionsServiceApi.Infrastructure;

public class ReactionsApiMapper : Profile
{
    public ReactionsApiMapper()
    {
        CreateMap<CreateReactionModel, Reaction>();
        CreateMap<Reaction, DisplayReactionModel>();

        CreateMap<Mood, PublishReactionbotMoodModel>();
    }
}
