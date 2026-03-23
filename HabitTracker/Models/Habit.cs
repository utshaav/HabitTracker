using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HabitTracker.Models;
public class Habit
{
    public Guid Id { get; set; }
    [Required]
    public string HabitTitle { get; set; }
    [Required]
    public string HabitDescription { get; set; }
    [Required]
    public DateTime HabitStartDate { get; set; }
    public string HabitFrequency { get; set; }
    public int HabitGracePeriod { get; set; } = 0;


    // Foreign Key
    public int HabitGroupId { get; set; }

    // Navigation Property
    [JsonIgnore] // Need to change this later and use DTOs to avoid circular references
    public HabitGroup HabitGroup { get; set; }

    // One-to-Many
    [JsonIgnore] // Need to change this later and use DTOs to avoid circular references
    public ICollection<HabitLog> HabitLogs { get; set; }
}

public class HabitDTO
{
    public Guid Id { get; set; }
    public string HabitTitle { get; set; }
    public string HabitDescription { get; set; }
    public DateTime HabitStartDate { get; set; }
    public string HabitFrequency { get; set; }
    public int HabitGracePeriod { get; set; }
    public int HabitGroupId { get; set; }
}