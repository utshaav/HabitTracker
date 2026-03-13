using Microsoft.EntityFrameworkCore;

namespace HabitTracker.Models;

[Index(nameof(HabitId), nameof(LogDate), IsUnique = true)]
public class HabitLog
{    public Guid Id { get; set; }
    public Guid HabitId { get; set; }
    public DateTime LogDate { get; set; }
}