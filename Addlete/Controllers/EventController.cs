using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Addlete.Models;
using produkto.DataConnection;

namespace Addlete.Controllers
{
    public class EventController : Controller
    {
        private readonly MySqlDbContext _context;

        public EventController(MySqlDbContext context)
        {
            _context = context;
        }

        // GET: Event/Index
        public IActionResult Index()
        {
            return View(_context.Events.ToList());
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        [HttpPost]
        public IActionResult Create(Event newEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(newEvent);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(newEvent);
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _context.Events.FirstOrDefault(e => e.Id == id);
            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var @event = _context.Events.Find(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.Events.Remove(@event);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
