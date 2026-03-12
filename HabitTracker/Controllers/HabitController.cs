using Microsoft.AspNetCore.Mvc;
using HabitTracker.Models;
using System.Threading.Tasks;

namespace HabitTracker.Controllers;
    public class HabitController: Controller
    {
        private readonly ILogger<HabitController> _logger;
        private readonly HabitContext _db;
        public HabitController(ILogger<HabitController> logger, HabitContext db)
        {
            _logger = logger;
            _db = db;
        }
        public IActionResult Index()
        {
            var habits = _db.Habits.ToList();
            return View(habits);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Habit habit)
        {
            if (ModelState.IsValid)
            {
                _db.Habits.Add(habit);
                await _db.SaveChangesAsync();  
                return RedirectToAction("Index");
            }
            return View(habit);
        }
        // [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var habit = await _db.Habits.FindAsync(id);
            if (habit == null)
            {
                return NotFound();
            }
            _db.Habits.Remove(habit);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<bool> MarkAsCompleted(Guid id)
        {
            try
            {
                _db.HabitLogs.Add(new HabitLog
                {
                    Id = Guid.NewGuid(),
                    HabitId = id,
                    LogDate = DateTime.UtcNow
                });
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking habit as completed");
                return false;
            }
            
        }
    }
