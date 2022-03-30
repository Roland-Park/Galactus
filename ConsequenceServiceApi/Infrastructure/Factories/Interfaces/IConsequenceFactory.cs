using ConsequenceServiceApi.Entities;
using ConsequenceServiceApi.Models.Consequences;

namespace ConsequenceServiceApi.Infrastructure.Factories.Interfaces;

public interface IConsequenceFactory
{
    DisplayConsequenceModel Build(Consequence consequence);
    List<DisplayConsequenceModel> Build(List<Consequence> consequences);
}
