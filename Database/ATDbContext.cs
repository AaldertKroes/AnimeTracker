using AnimeTracker.Database.DTO;
using Microsoft.EntityFrameworkCore;

namespace AnimeTracker.Database;

public class ATDbContext : DbContext
{
    public DbSet<AnimeDTO> Anime { get; set; }
    public DbSet<MovieDTO> Movies { get; set; }
    public DbSet<ListSelfDTO> ListSelf { get; set; }
    public DbSet<ListTogetherDTO> ListTogether { get; set; }
    public DbSet<QueueSelfDTO> QueueSelf { get; set; }
    public DbSet<QueueTogetherDTO> QueueTogether { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        object value = optionsBuilder.UseSqlite("Data Source=Database/AnimeTrackerDb.db");
    }
}
