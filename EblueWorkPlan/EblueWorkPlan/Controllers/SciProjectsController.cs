using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class SciProjectsController : Controller
    {
        private readonly WorkplandbContext _context;

        public SciProjectsController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: SciProjects
        public async Task<IActionResult> Index()
        {
            ViewBag.Roster = new SelectList(_context.Rosters.Where(r => r.CanBePi == true), "RosterID", "RosterName");
            ViewBag.Roster2 = new SelectList(_context.Rosters, "RosterID", "RosterName");
            ViewBag.Roster = new SelectList(_context.Rosters.Where(r => r.CanBePi == true), "RosterID", "RosterPI");
            ViewBag.Project = new SelectList(_context.Projects, "ProjectID", "ProjectNumber");
            var workplandbContext = _context.SciProjects.Include(s => s.Project).Include(s => s.Roster);
            return View(await workplandbContext.ToListAsync());
        }

        // GET: SciProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SciProjects == null)
            {
                return NotFound();
            }

            var sciProject = await _context.SciProjects
                .Include(s => s.Project)
                .Include(s => s.Roster)
                .FirstOrDefaultAsync(m => m.SciId == id);
            if (sciProject == null)
            {
                return NotFound();
            }

            return View(sciProject);
        }

        // GET: SciProjects/Create
        public IActionResult Create()

        {
            ViewBag.Roster = new SelectList(_context.Rosters.Where(r => r.CanBePi == true), "RosterID", "RosterName");
            ViewBag.Roster2 = new SelectList(_context.Rosters, "RosterID", "RosterName");
            ViewData["ProjectId"] = new SelectList(_context.Rosters, "RosterId", "RosterId");
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId");
            return View();
        }

        // POST: SciProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SciId,RosterId,Roles,Credits,Tr,Ca,Ah,AdHonorem,ProjectId")] SciProject sciProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sciProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Roster = new SelectList(_context.Rosters.Where(r => r.CanBePi == true), "RosterID", "RosterName");
            ViewBag.Roster2 = new SelectList(_context.Rosters, "RosterID", "RosterName");
            ViewData["ProjectId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", sciProject.ProjectId);
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", sciProject.RosterId);
            return View(sciProject);
        }

        // GET: SciProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SciProjects == null)
            {
                return NotFound();
            }

            var sciProject = await _context.SciProjects.FindAsync(id);
            if (sciProject == null)
            {
                return NotFound();
            }

            ViewBag.Roster = new SelectList(_context.Rosters.Where(r => r.CanBePi == true), "RosterID", "RosterName");
            ViewBag.Roster2 = new SelectList(_context.Rosters, "RosterID", "RosterName");
            ViewData["ProjectId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", sciProject.ProjectId);
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", sciProject.RosterId);
            return View(sciProject);
        }

        // POST: SciProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SciId,RosterId,Roles,Credits,Tr,Ca,Ah,AdHonorem,ProjectId")] SciProject sciProject)
        {
            if (id != sciProject.SciId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sciProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SciProjectExists(sciProject.SciId))
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

            ViewBag.Roster = new SelectList(_context.Rosters.Where(r => r.CanBePi == true), "RosterID", "RosterName");
            ViewBag.Roster2 = new SelectList(_context.Rosters, "RosterID", "RosterName");
            ViewData["ProjectId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", sciProject.ProjectId);
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", sciProject.RosterId);
            return View(sciProject);
        }

        // GET: SciProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SciProjects == null)
            {
                return NotFound();
            }

            var sciProject = await _context.SciProjects
                .Include(s => s.Project)
                .Include(s => s.Roster)
                .FirstOrDefaultAsync(m => m.SciId == id);
            if (sciProject == null)
            {
                return NotFound();
            }

            return View(sciProject);
        }

        // POST: SciProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SciProjects == null)
            {
                return Problem("Entity set 'WorkplandbContext.SciProjects'  is null.");
            }
            var sciProject = await _context.SciProjects.FindAsync(id);
            if (sciProject != null)
            {
                _context.SciProjects.Remove(sciProject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SciProjectExists(int id)
        {
            return (_context.SciProjects?.Any(e => e.SciId == id)).GetValueOrDefault();
        }
    }
}
