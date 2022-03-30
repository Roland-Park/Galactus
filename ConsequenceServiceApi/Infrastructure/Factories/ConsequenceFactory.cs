using AutoMapper;
using ConsequenceServiceApi.Entities;
using ConsequenceServiceApi.Infrastructure.Factories.Interfaces;
using ConsequenceServiceApi.Models.Consequences;

namespace ConsequenceServiceApi.Infrastructure.Factories;

public class ConsequenceFactory : IConsequenceFactory
{
    private readonly IMapper mapper;
    public ConsequenceFactory(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public DisplayConsequenceModel Build(Consequence consequence)
    {
        var model = mapper.Map<DisplayConsequenceModel>(consequence);
        return model;
    }

    public List<DisplayConsequenceModel> Build(List<Consequence> consequences)
    {
        var model = mapper.Map<List<DisplayConsequenceModel>>(consequences);
        return model;
    }
}
