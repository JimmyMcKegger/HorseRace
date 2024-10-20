using Newtonsoft.Json;

namespace HorseRace.Models;

public abstract class User
{
    private static readonly string UserFilePath = "Data/users.json";

    public static int UserCount = LoadUsers().Any() ? LoadUsers().Count : 0;
    private string email;
    private int id;
    private string name;


    // Constructor
    public User() { }

    public User(string name, string email)
    {
        Id = UserCount + 1;
        Name = name;
        Email = email;
    }

    // Getters and setter properties
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public override string ToString()
    {
        return $"{GetType().Name} - Name: {Name} Email: {Email}";
    }

    public static void SaveUsers(List<User> users)
    {
        var json = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(UserFilePath, json);
    }

    public static List<User> LoadUsers()
    {
        var userJson = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(UserFilePath));

        if (userJson != null)
        {
            var allSortedUsers =
                userJson.OrderBy(u => u.Id).ToList();

            return allSortedUsers;
        }

        return new List<User>();
    }
}