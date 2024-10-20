using HorseRace.Models;
using Microsoft.EntityFrameworkCore;

namespace HorseRace.Data;

public class HorseRaceManagementContext : DbContext
{
    public HorseRaceManagementContext(DbContextOptions<HorseRaceManagementContext> options)
        : base(options) { }

    public DbSet<Event> Events { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Race> Races { get; set; }
    public  DbSet<Horse> Horses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
