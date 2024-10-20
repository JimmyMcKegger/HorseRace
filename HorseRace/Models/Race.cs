namespace HorseRace.Models;

public class Race
{
    // Fields
    private string name;
    private DateTime startTime;

    // Getters and setter properties
    public string Name { get; set; }
    public DateTime StartTime { get; set; }

    // Constructors
    public Race() { }

    public Race(string name, DateTime startTime)
    {
        Name = name;
        StartTime = startTime;
    }

    // Methods
    public override string ToString()
    {
        return $"{Name} at: {StartTime}";
    }
}