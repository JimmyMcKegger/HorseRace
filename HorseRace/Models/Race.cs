using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HorseRace.Data;

namespace HorseRace.Models;

public class Race
{
    // Fields
    private int id;
    private string name;
    private DateTime startTime;
    private int eventId;
    private HashSet<Horse> horses;

    // Constructors
    public Race() { }

    public Race(string name, DateTime startTime, int eventId)
    {
        Id = Math.Abs((name, startTime).GetHashCode());
        Name = name;
        StartTime = startTime;
        EventId = eventId;
        Horses = new HashSet<Horse>();
    }

    // Getters and setter properties
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }

    [ForeignKey("EventId")]
    public int EventId { get; set; }
    public HashSet<Horse> Horses { get; set; }

    // Methods
    public override string ToString()
    {
        return $"{Name} at: {StartTime}";
    }

    public static Race? GetRaceById(int id)
    {
        var allEvents = Event.LoadEvents();
        foreach (var evnt in allEvents)
        {
            if (evnt.NumRaces > 0)
            {
                foreach (var race in evnt.Races)
                {
                    if (race.Id == id)
                    {
                        return race;
                    }
                }
            }
        }

        return null;
    }

    public string DisplayTime()
    {
        return $"{this.StartTime.ToShortTimeString()} on {this.StartTime.ToShortDateString()}";
    }
}
