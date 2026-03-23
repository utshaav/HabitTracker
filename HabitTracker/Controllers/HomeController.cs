using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HabitTracker.Models;
using HabitTracker.ViewModels;
using AutoMapper;

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

   private (List<int> Indicators, bool IsCompletedToday) GetHabitLogIndicators(Guid habitId)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var startDate = today.AddDays(-6);

        var logs = _db.HabitLogs
            .Where(log => log.HabitId == habitId && log.LogDate >= startDate)
            .Select(log => log.LogDate)
            .ToList();

        var indicators = new List<int> { 0, 0, 0, 0, 0, 0, 0 };

        bool isCompletedToday = false;

        int todayDayNumber = today.DayNumber;

        foreach (var logDate in logs)
        {
            int index = todayDayNumber - logDate.DayNumber;

            if (index == 0)
                isCompletedToday = true;

            if (index >= 0 && index < 7)
                indicators[index] = 1;
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
