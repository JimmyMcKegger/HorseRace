using HorseRace.Models;
using Microsoft.EntityFrameworkCore;

namespace HorseRace.Data;

public class HorseRaceManagementContext : DbContext
{
    public HorseRaceManagementContext(DbContextOptions<HorseRaceManagementContext> options) : base(options) { }

    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var eventData = Event.LoadEvents();
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Event>().HasData(eventData);
    }
}