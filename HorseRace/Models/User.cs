using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;
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
    private string passwordHash;


    // Constructor
    public User() { }

    public User(string name, string email, UserRole role, string password)
    {
        Id = UserCount + 1;
        Name = name;
        Email = email;
        Role = role;
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        PasswordHash = Convert.ToBase64String(passwordBytes);
    }

    // Getters and setter properties
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; }
    private string PasswordHash { get; set; }

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

    // https://learn.microsoft.com/en-us/dotnet/api/system.convert.frombase64string?view=net-8.0&redirectedfrom=MSDN#System_Convert_FromBase64String_System_String_
    public bool CheckPassword(string email, string password)
    {
        var usr = LoadUsers().FirstOrDefault(u => u.Email == email);
        if (usr != null)
        {
            byte[] attemptedPasswordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(attemptedPasswordBytes) == usr.PasswordHash;
        }

        return false;

    }
    
}