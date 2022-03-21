using ReactionsServiceApi.Entities;
using ReactionsServiceApi.Models;

namespace ReactionsServiceApi.Infrastructure.Factories.Interfaces;

public interface IReactionFactory
{
    Reaction Build(CreateReactionModel model);
    DisplayReactionModel Build(Reaction reaction);
}
