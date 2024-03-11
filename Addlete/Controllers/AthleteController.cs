using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Addlete.Models;
using produkto.DataConnection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Addlete.Controllers
{
    public class AthleteController : Controller
    {
        private readonly MySqlDbContext _context;

        public AthleteController(MySqlDbContext context)
        {
            _context = context;
        }

        // GET: Athlete
        public async Task<IActionResult> Index()
        {
            var athletes = await _context.Athletes.Include(a => a.Coach).ToListAsync();
            return View(athletes);
        }


        // GET: Athlete/Create
        public IActionResult Create()
        {
            ViewBag.Coaches = new SelectList(_context.Coaches.ToList(), "coach_id", "coach_name");
            return View();
        }

        // POST: Athlete/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("athlete_id,athlete_name,sport,coach_id,email")] Athlete athlete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(athlete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(athlete);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athlete = await _context.Athletes.FindAsync(id);
            if (athlete == null)
            {
                return NotFound();
            }

            ViewBag.Coaches = new SelectList(_context.Coaches.ToList(), "coach_id", "coach_name", athlete.coach_id);
            return View(athlete);
        }

        // POST: Athlete/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("athlete_id,athlete_name,sport,coach_id,email")] Athlete athlete)
        {
            if (id != athlete.athlete_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(athlete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AthleteExists(athlete.athlete_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(athlete);
        }

        // GET: Athlete/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var athlete = await _context.Athletes
                .FirstOrDefaultAsync(m => m.athlete_id == id);
            if (athlete == null)
            {
                return NotFound();
            }

            return View(athlete);
        }

        // POST: Athlete/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var athlete = await _context.Athletes.FindAsync(id);
            _context.Athletes.Remove(athlete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AthleteExists(int id)
        {
            return _context.Athletes.Any(e => e.athlete_id == id);
        }
    }
}
