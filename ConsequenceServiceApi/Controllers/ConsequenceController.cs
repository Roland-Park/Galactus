using ConsequenceServiceApi.Infrastructure.Factories.Interfaces;
using ConsequenceServiceApi.Infrastructure.Repositories.Interfaces;
using ConsequenceServiceApi.Models.Consequences;
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
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DisplayConsequenceModel>))]
    public async Task<ActionResult<DisplayConsequenceModel>> GetAll()
    {
        var consequences = await consequenceRepository.GetAllConsequences();
        var model = consequenceFactory.Build(consequences);
        return Ok(model);
    }
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DisplayConsequenceModel))]
    public async Task<ActionResult<DisplayConsequenceModel>> GetForMoodId(int id)
    {
        var consequence = await consequenceRepository.GetConsequenceForMood(id);
        var model = consequenceFactory.Build(consequence);
        return Ok(model);
    }
}
