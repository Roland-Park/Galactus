using AutoMapper;
using MoodServiceApi.Entities;
using MoodServiceApi.Infrastructure.Factories.Interfaces;
using MoodServiceApi.Models;

namespace MoodServiceApi.Infrastructure.Factories;

public class MoodFactory : IMoodFactory
{
    private readonly IMapper mapper;

    public MoodFactory(IMapper mapper)
    {
        this.mapper = mapper;
    }

    public List<DisplayMoodModel> Build(List<Mood> moods)
    {
        return mapper.Map<List<DisplayMoodModel>>(moods);
    }
}
