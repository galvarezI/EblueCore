using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class AnalyticalsController : Controller
    {
        private readonly WorkplandbContext _context;

        public AnalyticalsController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: Analyticals
        public async Task<IActionResult> Index()
        {
            var workplandbContext = _context.Analyticals.Include(a => a.Project);
            return View(await workplandbContext.ToListAsync());
        }

        // GET: Analyticals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Analyticals == null)
            {
                return NotFound();
            }

            var analytical = await _context.Analyticals
                .Include(a => a.Project)
                .FirstOrDefaultAsync(m => m.AnalyticalId == id);
            if (analytical == null)
            {
                return NotFound();
            }

            return View(analytical);
        }

        // GET: Analyticals/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            return View();
        }

        // POST: Analyticals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnalyticalId,AnalysisRequired,NumSamples,ProbableDate,ProjectId")] Analytical analytical)
        {
            if (ModelState.IsValid)
            {
                _context.Add(analytical);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", analytical.ProjectId);
            return View(analytical);
        }

        // GET: Analyticals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Analyticals == null)
            {
                return NotFound();
            }

            var analytical = await _context.Analyticals.FindAsync(id);
            if (analytical == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", analytical.ProjectId);
            return View(analytical);
        }

        // POST: Analyticals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AnalyticalId,AnalysisRequired,NumSamples,ProbableDate,ProjectId")] Analytical analytical)
        {
            if (id != analytical.AnalyticalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(analytical);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnalyticalExists(analytical.AnalyticalId))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", analytical.ProjectId);
            return View(analytical);
        }

        // GET: Analyticals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Analyticals == null)
            {
                return NotFound();
            }

            var analytical = await _context.Analyticals
                .Include(a => a.Project)
                .FirstOrDefaultAsync(m => m.AnalyticalId == id);
            if (analytical == null)
            {
                return NotFound();
            }

            return View(analytical);
        }

        // POST: Analyticals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Analyticals == null)
            {
                return Problem("Entity set 'WorkplandbContext.Analyticals'  is null.");
            }
            var analytical = await _context.Analyticals.FindAsync(id);
            if (analytical != null)
            {
                _context.Analyticals.Remove(analytical);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnalyticalExists(int id)
        {
            return (_context.Analyticals?.Any(e => e.AnalyticalId == id)).GetValueOrDefault();
        }
    }
}
