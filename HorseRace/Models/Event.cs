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
        
        return $"{GetType().Name} - {name} at {Location}. {NumRaces} Race{(NumRaces == 1 ? "" : "s")}.";
    }

    public static List<Event> AllTestEvents()
    {
        // test data
        DateTime now = DateTime.Now;
        List<Race> races = new List<Race>();
        Race r1 = new Race("test", now);
        races.Add(r1);

        List<Event> events = new List<Event>()
        {
            new Event("test event", "here", 1, races)
        };

        return events;
    }
}