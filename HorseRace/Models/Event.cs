using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace HorseRace.Models;

public class Event
{
    private static readonly string EventFilePath = "Data/events.json";

    // find the biggest id and increment from there
    private static int eventCount = LoadEvents().Any() ? LoadEvents().Count : 0;

    // Fields 
    private int id;
    private string location;
    private string name;
    private List<Race> races;

    // Constructors
    public Event() { }

    public Event(string name, string location, int numRaces = 0)
    {
        Id = EventCount;
        Name = name;
        Location = location;
        races = new List<Race>();
        if (numRaces > 0)
        {
            Race race;
            for (int i = 0; i < numRaces; i++)
            {
                race = new Race($"Race {i + 1}", DateTime.Now, EventCount);
                races.Add(race);
            }
        }
        Races = races;
        IncrementEventCount();
    }

    // Getters and setter properties
    [Key]
    public int Id { get; set; }

    private static int EventCount
    {
        get => eventCount;
        set => eventCount = eventCount + value;
    }

    public string Name { get; set; }
    public string Location { get; set; }
    public List<Race> Races { get; set; }

    public int NumRaces
    {
        get => Races.Count;
        set
        {
            if (value > Races.Count)
                for (var i = Races.Count; i < value; i++)
                    Races.Add(new Race($"Race {i + 1}", DateTime.Now, this.Id));
            else if (value < Races.Count)
                Races.RemoveRange(value - 1, 1);
        }
    }


    // Methods
    private static void IncrementEventCount()
    {
        EventCount++;
    }

    public override string ToString()
    {
        return $"{Id}. '{Name}' in {Location}. {NumRaces} Race{(NumRaces == 1 ? "" : "s")}.";
    }

    public static void AddNew(Event newEvent)
    {
        var allEvents = LoadEvents();
        allEvents.Add(newEvent);
        SaveEvents(allEvents);
    }

    public static void SaveEvents(List<Event> events)
    {
        var jsonString = JsonConvert.SerializeObject(events, Formatting.Indented);
        File.WriteAllText(EventFilePath, jsonString);
    }


    public static List<Event> LoadEvents()
    {
        var allText = File.ReadAllText(EventFilePath);
        var eventList = JsonConvert.DeserializeObject<List<Event>>(allText);
        if (eventList != null)
        {
            var sortedEvents =
                eventList.OrderBy(e => e.Id).ToList();

            // foreach (var e in eventList) Console.WriteLine(e);
            return sortedEvents;
        }

        return new List<Event>();
    }

    public static Event? GetEventById(int id)
    {
        var evnt = LoadEvents().FirstOrDefault(e => e.Id == id);
        if (evnt != null)
        {
            Console.WriteLine($"returning event: {evnt}");
            return evnt;
        }

        Console.WriteLine("No events found.");
        return null;
    }
}