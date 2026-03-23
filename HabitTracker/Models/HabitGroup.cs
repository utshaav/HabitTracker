using System.Text.Json.Serialization;

namespace HabitTracker.Models;

public class HabitGroup
{
    public int HabitGroupId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }


    // Navigation (One-to-Many)
    [JsonIgnore] // Need to change this later and use DTOs to avoid circular references
    public ICollection<Habit> Habits { get; set; }
}

public class HabitGroupDTO
{
    public int HabitGroupId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public string Color { get; set; }
}