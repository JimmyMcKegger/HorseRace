namespace HorseRace.Models;

public class Manager : User
{
    // Methods
    // TODO: CreateEvent methods
    // public Event CreateEvent(string location, int numRaces)
    // public Event CreateEvent(string name, string location, int numRaces)

    // TODO: UpdateEvent methods
    // public Event UpdateEvent(string location, int numRaces)

    public static List<User> LoadManagers()
    {
        var userJson = LoadUsers();
        if (userJson != null)
        {
            var allManagers = userJson.Where(u => u.Role == UserRole.Manager).ToList();
            return allManagers;
        }

        return new List<User>();
    }

    public static Manager? GetManagerById(int id)
    {
        var userJson = LoadManagers();
        // cast User as Manager
        var manager = userJson.Where(u => u.Id == id).FirstOrDefault() as Manager;

        return manager;
    }
}