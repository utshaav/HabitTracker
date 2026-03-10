using System.ComponentModel.DataAnnotations;

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
    public string HabitCategory  { get; set; } = "";
    public int HabitGracePeriod { get; set; } = 0;
}