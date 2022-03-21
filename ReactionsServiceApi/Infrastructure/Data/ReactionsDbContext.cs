using Microsoft.EntityFrameworkCore;
using ReactionsServiceApi.Entities;

namespace ReactionsServiceApi.Infrastructure.Data;

public class ReactionsDbContext : DbContext
{
    public DbSet<Reaction> Reactions { get; set; }
    public ReactionsDbContext(DbContextOptions<ReactionsDbContext> o) : base(o)
    {
    }
}
