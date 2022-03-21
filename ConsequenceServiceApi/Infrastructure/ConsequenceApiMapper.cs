using AutoMapper;
using ConsequenceServiceApi.Entities;
using ConsequenceServiceApi.Models;

namespace ConsequenceServiceApi.Infrastructure;

public class ConsequenceApiMapper : Profile
{
    public ConsequenceApiMapper()
    {
        CreateMap<Consequence, DisplayConsequenceModel>();
    }
}
