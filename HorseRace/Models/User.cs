using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace HorseRace.Models;

public class User
{
    private static readonly string UserFilePath = "Data/users.json";

    public static int UserCount = LoadUsers().Any() ? LoadUsers().Count : 0;
    private string email;
    private int id;
    private string name;
    private UserRole role;
    private string password;


    // Constructor
    public User() { }

    public User(string name, string email, UserRole role, string password)
    {
        Id = UserCount + 1;
        Name = name;
        Email = email;
        Role = role;
        Password = password;
    }

    // Getters and setter properties
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    public string Password { get; set; }

    public override string ToString()
    {
        return $"{Role}: {Name} - Email: {Email}";
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
    
    public static User? GetUserById(int id)
    {
        var users = LoadUsers();
        var user = users.FirstOrDefault(u => u.Id == id);

        if (user != null)
        {
            return user;
        }

        return null;
    }

    public static User? GetUserByEmail(string email)
    {
        var users = LoadUsers();
        var user = users.FirstOrDefault(u => u.Email == email);

        if (user != null)
        {
            return user;
        }

        return null;
    }

    public static UserRole? getRoleByAuthenticatedUser(string email)
    {
        User? user = GetUserByEmail(email);
        if (user != null)
        {
            return user.Role;
        }

        return null;
    }

    public static bool IsAuthenticated(string email, string password)
    {
        var user = GetUserByEmail(email);
        if (user != null)
        {
            return user.Password == password;
        }
        return false;
    }
}