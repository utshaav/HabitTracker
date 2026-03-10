using Microsoft.AspNetCore.Mvc;
using HabitTracker.Models;

namespace HabitTracker.Controllers;
    public class HabitController: Controller
    {
        private readonly ILogger<HabitController> _logger;
        public HabitController(ILogger<HabitController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Habit habit)
        {
            if (ModelState.IsValid)
            {
                // Save the habit to the database
                return RedirectToAction("Index");
            }
            return View(habit);
        }
    }
