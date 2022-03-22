using MoodServiceApi.Entities;
using MoodServiceApi.Models;

namespace MoodServiceApi.Infrastructure.Factories.Interfaces;

public interface IMoodFactory
{
    List<DisplayMoodModel> Build(List<Mood> moods);
}
