using AutoMapper;
using ConsequenceServiceApi.Entities;
using ConsequenceServiceApi.Infrastructure.Factories.Interfaces;
using ConsequenceServiceApi.Models;

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
}
