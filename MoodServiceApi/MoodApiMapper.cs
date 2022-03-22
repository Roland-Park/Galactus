using AutoMapper;
using MoodServiceApi.Entities;
using MoodServiceApi.Models;

namespace MoodServiceApi;

public class MoodApiMapper : Profile
{
    public MoodApiMapper()
    {
        CreateMap<Mood, DisplayMoodModel>();
    }
}
