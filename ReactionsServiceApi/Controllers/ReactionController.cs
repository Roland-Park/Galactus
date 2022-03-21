using Microsoft.AspNetCore.Mvc;
using ReactionsServiceApi.Infrastructure.Factories.Interfaces;
using ReactionsServiceApi.Infrastructure.Repositories.Interfaces;
using ReactionsServiceApi.Models;

namespace ReactionsServiceApi.Controllers;
[Route("[controller]")]
[ApiController]
public class ReactionController : ControllerBase
{
    private readonly IReactionFactory reactionFactory;
    private readonly IReactionRepository reactionRepository;
    public ReactionController(IReactionFactory reactionFactory, IReactionRepository reactionRepository)
    {
        this.reactionFactory = reactionFactory;
        this.reactionRepository = reactionRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DisplayReactionModel))]
    public async Task<ActionResult<string>> GetRandom()
    {
        var reaction = await reactionRepository.GetRandomReaction();
        var model = reactionFactory.Build(reaction);
        return Ok(model);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DisplayReactionModel))]
    public async Task<ActionResult<DisplayReactionModel>> GetById(int id)
    {
        var reaction = await reactionRepository.GetReactionById(id);
        var model = reactionFactory.Build(reaction);
        return Ok(model);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateReactionModel))]
    public async Task<ActionResult<DisplayReactionModel>> Post([FromBody] CreateReactionModel model)
    {
        var reaction = reactionFactory.Build(model);
        await reactionRepository.AddReaction(reaction);
        await reactionRepository.SaveChanges();

        return CreatedAtAction(nameof(GetById), new { id = reaction.Id }, reaction);
    }
}
