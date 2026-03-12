namespace HabitTracker.Models;
public class HabitLog
{    public Guid Id { get; set; }
    public Guid HabitId { get; set; }
    public DateTime LogDate { get; set; }
}