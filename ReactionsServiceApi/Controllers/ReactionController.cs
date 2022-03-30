using Microsoft.AspNetCore.Mvc;
using ReactionsServiceApi.Entities;
using ReactionsServiceApi.Infrastructure.Factories.Interfaces;
using ReactionsServiceApi.Infrastructure.Repositories.Interfaces;
using ReactionsServiceApi.Infrastructure.Services.AsynchronousData.Interfaces;
using ReactionsServiceApi.Infrastructure.Services.SynchronousData.Interfaces;
using ReactionsServiceApi.Models;
using ReactionsServiceApi.Models.Reactions;

namespace ReactionsServiceApi.Controllers;
[Route("[controller]")]
[ApiController]
public class ReactionController : ControllerBase
{
    private readonly IReactionFactory reactionFactory;
    private readonly IReactionRepository reactionRepository;
    private readonly IServicesHttpClient httpClient;
    private readonly IMessageBus messageBus;
    private readonly IMessageBusModelFactory messageBusModelFactory;
    public ReactionController(IReactionFactory reactionFactory, IReactionRepository reactionRepository, IServicesHttpClient httpClient, IMessageBus messageBus, IMessageBusModelFactory messageBusModelFactory)
    {
        this.reactionFactory = reactionFactory;
        this.reactionRepository = reactionRepository;
        this.httpClient = httpClient;
        this.messageBus = messageBus;
        this.messageBusModelFactory = messageBusModelFactory;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DisplayReactionModel))]
    public async Task<ActionResult<string>> GetRandom()
    {
        var moods = await httpClient.GetMoods();
        var reaction = await reactionRepository.GetRandomReaction();
        var reactionModel = reactionFactory.Build(reaction);

        if(moods != null && moods.Count > 0)
        {
            var botMood = moods.FirstOrDefault(x => x.Id == reaction.MoodId);
            PublishMood(botMood);
        }

        return Ok(reactionModel);
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

    private void PublishMood(Mood mood)
    {
        var botMoodModel = messageBusModelFactory.Build(mood);
        messageBus.PublishMood(botMoodModel);
    }
}
