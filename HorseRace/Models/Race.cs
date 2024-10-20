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

    // Constructors
    public Race() { }

    public Race(string name, DateTime startTime, int eventId)
    {
        Id = Math.Abs((name, startTime).GetHashCode());
        Name = name;
        StartTime = startTime;
        EventId = eventId;
    }

    // Getters and setter properties
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public List<Horse> Horses { get; set; }
    [ForeignKey("EventId")]
    public int EventId { get; set; }

    // Methods
    public override string ToString()
    {
        return $"{Name} at: {StartTime}";
    }
}
