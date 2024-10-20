namespace HorseRace.Models;

public class Race
{
    // Fields
    private string name;
    private DateTime startTime;

    // Constructors
    public Race() { }

    public Race(string name, DateTime startTime)
    {
        Name = name;
        StartTime = startTime;
    }

    // Getters and setter properties
    public string Name { get; set; }
    public DateTime StartTime { get; set; }

    public List<Horse> Horses { get; set; }

    // Methods
    public override string ToString()
    {
        return $"{Name} at: {StartTime}";
    }
}