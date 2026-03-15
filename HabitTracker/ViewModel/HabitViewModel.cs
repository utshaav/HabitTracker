using HabitTracker.Models;

namespace HabitTracker.ViewModels;
public class HabitViewModel : Habit
{
    public bool IsCompletedToday { get; set; }
    public List<int> LogDisplayIndicators { get; set; } = [0, 0, 0, 0, 0, 0, 0];
    public int GetCurrentStreak()
    {
        int streak = 0;
        for (int i = 0; i < LogDisplayIndicators.Count; i++)
        {
            if (LogDisplayIndicators[i] == 1)
            {
                streak++;
            }
            else
            {
                break;
            }
        }
        return streak;
    }
}