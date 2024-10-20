using System.ComponentModel.DataAnnotations;

namespace HorseRace.Models;

public class Horse
{
    // Fields
    private DateOnly dob;
    private int id;
    private string name;
    private int ownerId;


    // Constructor
    public Horse() {}
    public Horse(int id, string name, DateOnly dob, int ownerId)
    {
        Id = id;
        Name = name;
        DateOfBirth = dob;
        OwnerId = ownerId;
    }
    


    // Getters and setter properties
    [Key]
    public int Id { get; set;  }
    public string Name { get; set; }
    private DateOnly DateOfBirth { get; set; }
    private int OwnerId { get; set; }


    // Methods
    public override string ToString()
    {
        return $"{Name}";
    }
}