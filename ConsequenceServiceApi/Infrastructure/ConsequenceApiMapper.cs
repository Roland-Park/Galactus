using AutoMapper;
using ConsequenceServiceApi.Entities;
using ConsequenceServiceApi.Models.Consequences;
using ConsequenceServiceApi.Models.Moods;

namespace ConsequenceServiceApi.Infrastructure;

public class ConsequenceApiMapper : Profile
{
    public ConsequenceApiMapper()
    {
        CreateMap<Consequence, DisplayConsequenceModel>();
        CreateMap<SubscribeReactionbotMoodModel, Mood>();
    }
}
