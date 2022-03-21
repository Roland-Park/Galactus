using AutoMapper;
using ReactionsServiceApi.Entities;
using ReactionsServiceApi.Models;

namespace ReactionsServiceApi.Infrastructure;

public class ReactionsApiMapper : Profile
{
    public ReactionsApiMapper()
    {
        CreateMap<CreateReactionModel, Reaction>();
        CreateMap<Reaction, DisplayReactionModel>();
    }
}
