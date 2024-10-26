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
    public string Name { get => base.Name; set => base.Name = value; }

    public static List<User> LoadOwners()
    {
        var userJson = LoadUsers();
        if (userJson != null)
        {
            var allOwners = userJson.Where(u => u.Role == UserRole.Owner).ToList();
            Console.WriteLine($"Loaded {allOwners.Count} owners");
            return allOwners;
        }

        return new List<User>();
    }

    public static Owner? GetOwnerById(int id)
    {
        var allOwners = LoadOwners();
        var filteredOwner = allOwners.Where(u => u.Id == id).FirstOrDefault();
        var ownerAsOwner = filteredOwner as Owner;
        Console.WriteLine($"OWNER: {ownerAsOwner}");
        return ownerAsOwner;
    }
}