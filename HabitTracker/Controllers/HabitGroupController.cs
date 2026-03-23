using Microsoft.AspNetCore.Mvc;
using HabitTracker.Models;
using System.Threading.Tasks;
using AutoMapper;

namespace HabitTracker.Controllers;
    public class HabitGroupController: Controller
    {
        private readonly ILogger<HabitGroupController> _logger;
        private readonly HabitContext _db;
        private readonly IMapper _mapper;

        public HabitGroupController(ILogger<HabitGroupController> logger, HabitContext db, IMapper mapper)
        {
            _logger = logger;
            _db = db;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var habitGroups = _db.HabitGroups.ToList();
            return View(habitGroups);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(HabitGroupDTO habitGroup)
        {
            if (ModelState.IsValid)
            {
                var habitGroupEntity = _mapper.Map<HabitGroup>(habitGroup);
                _db.HabitGroups.Add(habitGroupEntity);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(habitGroup);
        }
        // [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var habitGroup = await _db.HabitGroups.FindAsync(id);
            if (habitGroup == null)
            {
                return NotFound();
            }
            _db.HabitGroups.Remove(habitGroup);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
