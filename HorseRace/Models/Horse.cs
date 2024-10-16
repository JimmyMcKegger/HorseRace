namespace HorseRace.Models;

public class Horse
{
    // Fields
    private string id;
    private string name;
    private DateOnly dob;


    // Getters and setter properties
    public string Id { get; }
    public string Name { get; set; }
    private DateOnly DateOfBirth { get; }


    // Constructor
    public Horse(string id, string name, DateOnly dob)
    {
        Id = id;
        Name = name;
        DateOfBirth = dob;


    }


    // Methods

}