using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Addlete.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using produkto.DataConnection;

namespace Addlete.Controllers
{
    public class InjuryReportController : Controller
    {
        private readonly MySqlDbContext _context;

        public InjuryReportController(MySqlDbContext context)
        {
            _context = context;
        }

        // GET: InjuryReport
        public async Task<IActionResult> Index()
        {
            var injuryReports = await _context.Injury_Reports.Include(ir => ir.Athlete).ToListAsync();
            return View(injuryReports);
        }

        // GET: InjuryReport/Create
        public IActionResult Create()
        {
            ViewBag.Athletes = new SelectList(_context.Athletes.ToList(), "athlete_id", "athlete_name");
            return View();
        }


        // POST: InjuryReport/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("athlete_id,injury_description,date_reported")] Injury_Reports injuryReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(injuryReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(injuryReport);
        }

        // GET: InjuryReport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injuryReport = await _context.Injury_Reports.FindAsync(id);
            if (injuryReport == null)
            {
                return NotFound();
            }

            ViewBag.Athletes = new SelectList(_context.Athletes.ToList(), "athlete_id", "athlete_name", injuryReport.athlete_id);
            return View(injuryReport);
        }

        // POST: InjuryReport/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("report_id,athlete_id,injury_description,date_reported")] Injury_Reports injuryReport)
        {
            if (id != injuryReport.report_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(injuryReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InjuryReportExists(injuryReport.report_id))
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
            return View(injuryReport);
        }

        // GET: InjuryReport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injuryReport = await _context.Injury_Reports.Include(ir => ir.Athlete).FirstOrDefaultAsync(ir => ir.report_id == id);
            if (injuryReport == null)
            {
                return NotFound();
            }

            return View(injuryReport);
        }

        // POST: InjuryReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var injuryReport = await _context.Injury_Reports.FindAsync(id);
            _context.Injury_Reports.Remove(injuryReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InjuryReportExists(int id)
        {
            return _context.Injury_Reports.Any(ir => ir.report_id == id);
        }
    }
}
