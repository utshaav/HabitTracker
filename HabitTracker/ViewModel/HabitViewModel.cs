using HabitTracker.Models;

namespace HabitTracker.ViewModels;
public class HabitViewModel : Habit
{
    public bool IsCompletedToday { get; set; }
    public List<int> LogDisplayIndicators { get; set; } = [0, 0, 0, 0, 0, 0, 0];
}