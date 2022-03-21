using ConsequenceServiceApi.Entities;
using ConsequenceServiceApi.Infrastructure.Factories.Interfaces;
using ConsequenceServiceApi.Infrastructure.Repositories.Interfaces;
using ConsequenceServiceApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsequenceServiceApi.Controllers;
[Route("[controller]")]
[ApiController]
public class ConsequenceController : ControllerBase
{
    private readonly IConsequenceRepository consequenceRepository;
    private readonly IConsequenceFactory consequenceFactory;
    public ConsequenceController(IConsequenceFactory consequenceFactory, IConsequenceRepository consequenceRepository)
    {
        this.consequenceFactory = consequenceFactory;
        this.consequenceRepository = consequenceRepository;
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DisplayConsequenceModel))]
    public async Task<ActionResult<DisplayConsequenceModel>> GetForMoodId(int id)
    {
        var consequence = await consequenceRepository.GetConsequenceForMood((Mood)id);
        var model = consequenceFactory.Build(consequence);
        return Ok(model);
    }
}
