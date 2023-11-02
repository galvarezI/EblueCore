using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class GradAssesController : Controller
    {
        private readonly WorkplandbContext _context;

        public GradAssesController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: GradAsses
        public async Task<IActionResult> Index()
        {

            ViewBag.ProjectsItem = new SelectList(_context.Projects, "ProjectId", "ProjectName");
            ViewBag.RosterItem = new SelectList(_context.Rosters, "RosterId", "RosterName");
            var workplandbContext = _context.GradAsses.Include(g => g.Project);
            return View(await workplandbContext.ToListAsync());
        }

        // GET: GradAsses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GradAsses == null)
            {
                return NotFound();
            }

            var gradAss = await _context.GradAsses
                .Include(g => g.Project)
                .FirstOrDefaultAsync(m => m.Gaid == id);
            if (gradAss == null)
            {
                return NotFound();
            }

            return View(gradAss);
        }

        // GET: GradAsses/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            return View();
        }

        // POST: GradAsses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Gaid,Gname,Thesis,ProjectId,StudentId,Amount,RoleId,StudentName,IsGraduated,IsUndergraduated")] GradAss gradAss)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gradAss);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", gradAss.ProjectId);
            return View(gradAss);
        }

        // GET: GradAsses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GradAsses == null)
            {
                return NotFound();
            }

            var gradAss = await _context.GradAsses.FindAsync(id);
            if (gradAss == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", gradAss.ProjectId);
            return View(gradAss);
        }

        // POST: GradAsses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Gaid,Gname,Thesis,ProjectId,StudentId,Amount,RoleId,StudentName,IsGraduated,IsUndergraduated")] GradAss gradAss)
        {
            if (id != gradAss.Gaid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gradAss);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradAssExists(gradAss.Gaid))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", gradAss.ProjectId);
            return View(gradAss);
        }

        // GET: GradAsses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GradAsses == null)
            {
                return NotFound();
            }

            var gradAss = await _context.GradAsses
                .Include(g => g.Project)
                .FirstOrDefaultAsync(m => m.Gaid == id);
            if (gradAss == null)
            {
                return NotFound();
            }

            return View(gradAss);
        }

        // POST: GradAsses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GradAsses == null)
            {
                return Problem("Entity set 'WorkplandbContext.GradAsses'  is null.");
            }
            var gradAss = await _context.GradAsses.FindAsync(id);
            if (gradAss != null)
            {
                _context.GradAsses.Remove(gradAss);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradAssExists(int id)
        {
            return (_context.GradAsses?.Any(e => e.Gaid == id)).GetValueOrDefault();
        }
    }
}
