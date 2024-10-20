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
    }


    // getter and setter
    public List<Horse> Horses { get; set; }


    public void TestOwner()
    {
        var owner1 = new Owner("Jim", "jim@grovej.com");
        var ownerId = owner1.Id;
        var bday = new DateOnly(2022, 10, 20);
        var h = new Horse(1, "Ed", bday, ownerId);

        Console.WriteLine($"Owner: {owner1.Name}, Horses: {string.Join(", ", owner1.Horses)}");
    }
}