using ConsequenceServiceApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsequenceServiceApi.Infrastructure.Data;

public class ConsequenceDbContext : DbContext
{
    public DbSet<Consequence> Consequences { get; set; }
    public ConsequenceDbContext(DbContextOptions<ConsequenceDbContext> o) : base(o)
    {
    }
}
