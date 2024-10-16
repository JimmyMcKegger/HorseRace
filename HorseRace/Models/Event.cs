using Newtonsoft.Json;

namespace HorseRace.Models;

public class Event
{
    private static readonly string EventFilePath = "data/events.json";
    // find the biggest id and increment from there
    private static int eventCount = LoadEvents().Any() ? LoadEvents().Max(e => e.Id) + 1 : 1;

    // Fields 
    private int id;
    private string name;
    private string location;
    private List<Race> races;

    // Getters and setter properties
    public int Id { get; set; }
    public static int EventCount { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public List<Race> Races { get; set; }
    public int NumRaces => Races.Count;

    // Constructors
    public Event() { }

    public Event(string name, string location, List<Race> races)
    {
        Id = EventCount;
        Name = name;
        Location = location;
        Races = races;
        IncrementEventCount();
    }

    // Methods
    public override string ToString()
    {
        return $"<{GetType().Name}> {Id} '{Name}' in {Location}. {NumRaces} Race{(NumRaces == 1 ? "" : "s")}.";
    }

    private static void IncrementEventCount()
    {
        EventCount++;
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
        if (eventList != null)
        {
            foreach (var e in eventList)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine($"{eventList.Count} events loaded.");
            return eventList;
        }

        return new List<Event>();
        ;
    }
}