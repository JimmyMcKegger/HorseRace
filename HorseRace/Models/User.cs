namespace HorseRace.Models;

public abstract class User
{
    // Fields
    private int _userId;
    private string name;
    private string email;

    // Getters and setter properties
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    // Constructor
    public User() { }

    public User(string name, string email)
    {
        var rnd = new Random();
        // check database to make sure it's not taken
        UserId = rnd.Next();
        Name = name;
        Email = email;
    }

    // Methods
    public override string ToString()
    {
        return $"{GetType().Name} - Name: {Name} Email: {Email}";
    }
}