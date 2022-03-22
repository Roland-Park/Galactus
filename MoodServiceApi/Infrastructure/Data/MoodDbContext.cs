using Microsoft.EntityFrameworkCore;
using MoodServiceApi.Entities;

namespace MoodServiceApi.Infrastructure.Data;

public class MoodDbContext : DbContext
{
    public DbSet<Mood> Moods { get; set; }
    public MoodDbContext(DbContextOptions<MoodDbContext> o) : base(o)
    {
    }
}
