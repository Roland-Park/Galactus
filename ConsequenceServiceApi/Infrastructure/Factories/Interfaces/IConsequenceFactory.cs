using ConsequenceServiceApi.Entities;
using ConsequenceServiceApi.Models;

namespace ConsequenceServiceApi.Infrastructure.Factories.Interfaces;

public interface IConsequenceFactory
{
    DisplayConsequenceModel Build(Consequence consequence);
}
