using ConsequenceServiceApi.Entities;
using Microsoft.AspNetCore.Mvc;

// Could probably be its own microservice if we wanted. Got a bit lazy with this one
namespace ConsequenceServiceApi.Controllers;
[Route("[controller]")]
[ApiController]
public class MoodController : ControllerBase
{

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Mood>))]
    public ActionResult<List<Mood>> Get()
    {
        var moods = Enum.GetNames(typeof(Mood)).ToList();
        return Ok(moods);
    }
}
