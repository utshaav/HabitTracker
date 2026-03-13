using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HabitTracker.Models;
using HabitTracker.ViewModels;

namespace HabitTracker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HabitContext _db;

    public HomeController(ILogger<HomeController> logger, HabitContext db)
    {
        _logger = logger;
        _db = db;
    }

    private (List<int>,bool) GetHabitLogIndicators(Guid habitId)
    {
        var indicators = new List<int> { 0, 0, 0, 0, 0, 0, 0 };
        var logs = _db.HabitLogs.Where(log => log.HabitId == habitId).ToList();
        bool isCompletedToday = logs.Any(log => log.LogDate == DateTime.UtcNow.Date);
        foreach (var log in logs)
        {
            var daysAgo = (DateTime.UtcNow - log.LogDate).Days;
            if (daysAgo >= 0 && daysAgo < indicators.Count)
            {
                indicators[daysAgo] = 1;
            }
            
        }
        return (indicators, isCompletedToday);
    }
    public IActionResult Index()
    {
        var habitViewModels = _db.Habits.Select( habit => new HabitViewModel
            {
                Id = habit.Id,
                HabitTitle = habit.HabitTitle,
                HabitDescription = habit.HabitDescription,
                HabitFrequency = habit.HabitFrequency,
                HabitGracePeriod = habit.HabitGracePeriod
            }).ToList();
            foreach (var habit in habitViewModels)
            {

                var (indicators, isCompletedToday) = GetHabitLogIndicators(habit.Id);
                habit.LogDisplayIndicators = indicators;
                habit.IsCompletedToday = isCompletedToday;
            }

        return View(habitViewModels);
    }

    public IActionResult HabitIndicator(Guid id)
    {
        var indicators = GetHabitLogIndicators(id).Item1;
        return PartialView("_HabitIndicator", indicators);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
