using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
namespace HorseRace.Models;

public class Horse
{
    private static readonly string HorseFilePath = "Data/horses.json";
    // Fields
    private DateOnly dob;
    private int id;
    private string name;
    private int ownerId;

    // Constructor
    public Horse() { }
    public Horse(string name, DateOnly dob, int ownerId)
    {
        Id = Math.Abs((name, dob, ownerId).GetHashCode()); ;
        Name = name;
        DateOfBirth = dob;
        OwnerId = ownerId;
    }


    // Getters and setter properties
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public int OwnerId { get; set; }


    // Methods
    public override string ToString()
    {
        return $"{Name}";
    }

    public static void SaveHorses(List<Horse> horses)
    {
        var jsonString = JsonConvert.SerializeObject(horses, Formatting.Indented);
        File.WriteAllText(HorseFilePath, jsonString);
    }

    public static List<Horse> AllHorses()
    {
        var allHorses = File.ReadAllText(HorseFilePath);
        var horseList = JsonConvert.DeserializeObject<List<Horse>>(allHorses);
        if (horseList != null)
        {
            var filteredHorses =
                horseList.OrderBy(e => e.Id).ToList();

            return filteredHorses;
        }
        return new List<Horse>();
    }

    public static List<Horse> LoadUserHorses(int id)
    {
        var allHorses = AllHorses();
        var user = User.GetUserById(id);

        if (user != null)
        {
            allHorses = allHorses.Where(h => h.OwnerId == id).ToList();

            if (allHorses != null)
            {
                return allHorses;
            }
        }
        return new List<Horse>();
    }
    public static void AddNew(Horse newHorse)
    {
        var allHorses = AllHorses();
        allHorses.Add(newHorse);
        SaveHorses(allHorses);
    }
}