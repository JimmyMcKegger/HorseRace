namespace HorseRace.Models;

public class Owner : User
{
    // Fields
    private List<Horse> horses;

    // constructor
    public Owner() { }

    public Owner(string name, string email)
    {
        Name = name;
        Email = email;
        Horses = new List<Horse>();
        Role = UserRole.Owner;
    }


    // getter and setter
    public List<Horse> Horses { get; set; }

    public static List<User> LoadOwners()
    {
        var userJson = LoadUsers();
        if (userJson != null)
        {
            var allOwners = userJson.Where(u => u.Role == UserRole.Owner).ToList();
            return allOwners;
        }

        return new List<User>();
    }


    public void TestOwner()
    {
        var owner1 = new Owner("Jim", "jim@grovej.com");
        var ownerId = owner1.Id;
        var bday = new DateOnly(2022, 10, 20);
        var h = new Horse(1, "Ed", bday, ownerId);

        Console.WriteLine($"Owner: {owner1.Name}, Horses: {string.Join(", ", owner1.Horses)}");
    }
}