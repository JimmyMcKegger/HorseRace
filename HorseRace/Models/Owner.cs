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
            return allOwners;
        }

        return new List<User>();
    }

    public static List<Owner> LoadOwnersAsOwners()
    {
        List<User> allOwnersAsUsers = LoadOwners();
        List<Owner> allOwnersAsOwners = new List<Owner>();
        foreach (User o in allOwnersAsUsers)
        {
            Console.WriteLine(o);
            allOwnersAsOwners.Add(o as Owner);
        }

        return allOwnersAsOwners;
    }


    public void TestOwner()
    {
        var owner1 = new Owner("Jim", "jim@grovej.com");
        var ownerId = owner1.Id;
        var bday = new DateOnly(2022, 10, 20);
        var h = new Horse(1, "Ed", bday, ownerId);

        Console.WriteLine($"Owner: {owner1.Name}, Horses: {string.Join(", ", owner1.Horses)}");
    }

    public static Owner? GetOwnerById(int id)
    {
        var userJson = LoadOwners();
        // cast User as Owner
        var owner = userJson.Where(u => u.Id == id).FirstOrDefault() as Owner;

        return owner;
    }
}