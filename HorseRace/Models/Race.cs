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

    public static void UpdateRaceInEvents(Race updatedRace)
    {
        var allEvents = Event.LoadEvents();
        var EventWithRace = Event.GetIndexOfEvent(updatedRace.EventId);
        
        var currentEvent = allEvents[EventWithRace];
        for (int i = 0; i < currentEvent.Races.Count; i++)
        {
            if (currentEvent.Races[i].Id == updatedRace.Id)
            {
                currentEvent.Races[i] = updatedRace;
                Console.WriteLine($"{currentEvent.Races[i]} updated");
            }
        }
        
        Event.UpdateEvents(currentEvent);
    }

    public static void AddHorse(int RaceId, int HorseId)
    {
        var race = GetRaceById(RaceId);
        if (race != null)
        {
            Console.WriteLine($"RACE: {race.Name}");
            var horse = Horse.GetHorseById(HorseId);
            if (race.Horses == null)
            {
                race.horses = new HashSet<Horse> { horse };
                Console.WriteLine($"Hashset created with {horse.Name} added");
            }
            else
            {
                race.Horses.Add(horse);
                Console.WriteLine($"Horse {horse.Name} added");
            }
            UpdateRaceInEvents(race);
        }
        
       
    }
}
