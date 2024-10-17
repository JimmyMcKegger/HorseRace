using Newtonsoft.Json;

namespace HorseRace.Models;

public class Event
{
    private static readonly string EventFilePath = "data/events.json";
    private static int eventCount = 0;

    // Fields 
    private string name;
    private string location;
    private List<Race> races;

    // Getters and setter properties
    public int Id { get; }
    public string Name { get; set; }
    public string Location { get; set; }
    public List<Race> Races { get; set; }
    public int NumRaces => Races.Count;
    public static int EventCount { get; set; }
    
    // Constructors
    public Event() { }

    public Event(string name, string location, List<Race> races)
    {
        IncrementEventCount();
        Id = Id;
        Name = name;
        Location = location;
        Races = races;
    }

    // Methods
    public override string ToString()
    {
        return $"<{GetType().Name}> '{Name}' in {Location}. {NumRaces} Race{(NumRaces == 1 ? "" : "s")}.";
    }

    private static void IncrementEventCount()
    {
        eventCount++;
    }

    public static List<Event> TestEvents()
    {
        var town = new[]
            { "Tallaght", "Mayfield", "Oranmore", "Adare", "Belfast", "Derry", "Dungarvan", "Grange", "Dundalk" };
        var locations = new[]
            { "Dublin", "Cork", "Galway", "Limerick", "Antrim", "Londonderry", "Waterford", "Sligo", "Louth" };
        var events = new List<Event>();

        var testRaces = new List<Race>();
        var raceOne = new Race("race1", DateTime.Now);
        var raceTwo = new Race("race2", DateTime.Now);
        testRaces.Add(raceOne);
        testRaces.Add(raceTwo);

        // TODO: refactor with LINQ
        for (var i = 0; i < locations.Length; i++) events.Add(new Event($"{town[i]} Derby", locations[i], testRaces));

        return events;
    }

    public static void SaveEvents(List<Event> events)
    {
        string jsonString = JsonConvert.SerializeObject(events, Formatting.Indented);
        File.WriteAllText(EventFilePath, jsonString);
    }

    public static List<Event> LoadEvents()
    {
        string allText = File.ReadAllText(EventFilePath);
        var eventList = JsonConvert.DeserializeObject<List<Event>>(allText);
        foreach (var e in eventList)
        {
            Console.WriteLine($"{e.Id} - {e.Name} in {e.Location}.");
        }
        return eventList ?? new List<Event>();
    }
}