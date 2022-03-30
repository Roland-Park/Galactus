using AutoMapper;
using ReactionsServiceApi.Entities;
using ReactionsServiceApi.Infrastructure.Factories.Interfaces;
using ReactionsServiceApi.Models;
using ReactionsServiceApi.Models.Reactions;

namespace ReactionsServiceApi.Infrastructure.Factories;

public class ReactionFactory : IReactionFactory
{
    private readonly IMapper mapper;
    public ReactionFactory(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public Reaction Build(CreateReactionModel model)
    {
        return mapper.Map<Reaction>(model);
    }

    public DisplayReactionModel Build(Reaction reaction)
    {
        return mapper.Map<DisplayReactionModel>(reaction);
    }
}
