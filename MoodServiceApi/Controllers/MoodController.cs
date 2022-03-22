using Microsoft.AspNetCore.Mvc;
using MoodServiceApi.Infrastructure.Factories.Interfaces;
using MoodServiceApi.Infrastructure.Repositories.Interfaces;
using MoodServiceApi.Models;

namespace MoodServiceApi.Controllers;
[Route("[controller]")]
[ApiController]
public class MoodController : ControllerBase
{
    private readonly IMoodRepository moodRepository;
    private readonly IMoodFactory moodFactory;

    public MoodController(IMoodRepository moodRepository, IMoodFactory moodFactory)
    {
        this.moodRepository = moodRepository;
        this.moodFactory = moodFactory;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<DisplayMoodModel>))]
    public async Task<ActionResult<List<DisplayMoodModel>>> Get()
    {
        var moods = await moodRepository.GetAllMoods();
        var model = moodFactory.Build(moods);
        Console.WriteLine("SENDING MOODS...");
        return Ok(model);
    }
}
