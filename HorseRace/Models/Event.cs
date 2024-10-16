namespace HorseRace.Models;

public class Event
{
    // Instance Fields 
    private string name;
    private string location;
    private int numRaces;
    private List<Race> races;
        
    // Getters and setter properties
    public string Name { get; set; }
    public string Location { get; set; }
    public int NumRaces { get; set; }
    public List<Race> Races { get => races; set => races = value; }
    

    // Constructors
    public Event() { }
    
    public Event(string name, string location, int numRaces, List<Race> races)
    {
        Name = name;
        Location = location;
        NumRaces = numRaces;
        Races = races;
    }
    
    // Methods
    public override string ToString()
    {
        return $"{GetType().Name} - {name} at {Location}. {NumRaces} Races";
    }
}