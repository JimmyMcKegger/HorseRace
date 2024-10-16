namespace HorseRace.Models;

public class Event
{
    // Instance Fields 
    private string name;
    private string location;
    private List<Race> races;

    // Getters and setter properties
    public string Name { get; set; }
    public string Location { get; set; }
    public List<Race> Races { get; set; }
    public int NumRaces { get => Races.Count; }


    // Constructors
    public Event() { }

    public Event(string name, string location, List<Race> races)
    {
        Name = name;
        Location = location;
        Races = races;
    }

    // Methods
    public override string ToString()
    {

        return $"<{GetType().Name}> '{Name}' in {Location}. {NumRaces} Race{(NumRaces == 1 ? "" : "s")}.";
    }

    public static List<Event> TestEvents()
    {
        var town = new string[]
            { "Tallaght", "Mayfield", "Oranmore", "Adare", "Belfast", "Derry", "Dungarvan", "Grange", "Dundalk" };
        var locations = new string[] { "Dublin", "Cork", "Galway", "Limerick", "Antrim", "Londonderry", "Waterford", "Sligo", "Louth" };
        var events = new List<Event>();

        var testRaces = new List<Race>();
        var raceOne = new Race("race1", DateTime.Now);
        var raceTwo = new Race("race2", DateTime.Now);
        testRaces.Add(raceOne);
        testRaces.Add(raceTwo);

        // TODO: refactor with LINQ
        for (var i = 0; i < locations.Length; i++)
        {
            events.Add(new Event($"{town[i]} Derby", locations[i], testRaces));
        }

        return events;
    }
}