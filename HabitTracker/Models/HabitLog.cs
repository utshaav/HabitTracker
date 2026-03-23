using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Models;

[Index(nameof(HabitId), nameof(LogDate), IsUnique = true)]
public class HabitLog
{   
    public Guid HabitLogId { get; set; }

    // Foreign Key
    public Guid HabitId { get; set; }

    public DateOnly LogDate { get; set; }

    // Navigation Property
    [JsonIgnore] // Need to change this later and use DTOs to avoid circular references
    public Habit Habit { get; set; }
}

public class HabitLogDTO
{
    public Guid HabitLogId { get; set; }
    public Guid HabitId { get; set; }
    public DateOnly LogDate { get; set; }
}