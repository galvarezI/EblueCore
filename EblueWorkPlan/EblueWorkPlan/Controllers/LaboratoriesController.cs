using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class LaboratoriesController : Controller
    {
        private readonly WorkplandbContext _context;

        public LaboratoriesController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: Laboratories
        public async Task<IActionResult> Index()
        {
            var workplandbContext = _context.Laboratories.Include(l => l.Project);
            return View(await workplandbContext.ToListAsync());
        }

        // GET: Laboratories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Laboratories == null)
            {
                return NotFound();
            }

            var laboratory = await _context.Laboratories
                .Include(l => l.Project)
                .FirstOrDefaultAsync(m => m.LabId == id);
            if (laboratory == null)
            {
                return NotFound();
            }

            return View(laboratory);
        }

        // GET: Laboratories/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            return View();
        }

        // POST: Laboratories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LabId,Areq,NoSamples,SamplesDate,ProjectId")] Laboratory laboratory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laboratory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Project = new SelectList(_context.Projects, "ProjectId", "ProjectNumber");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", laboratory.ProjectId);
            return View(laboratory);
        }

        // GET: Laboratories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Laboratories == null)
            {
                return NotFound();
            }

            var laboratory = await _context.Laboratories.FindAsync(id);
            if (laboratory == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", laboratory.ProjectId);
            return View(laboratory);
        }

        // POST: Laboratories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LabId,Areq,NoSamples,SamplesDate,ProjectId")] Laboratory laboratory)
        {
            if (id != laboratory.LabId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laboratory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaboratoryExists(laboratory.LabId))
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
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", laboratory.ProjectId);
            return View(laboratory);
        }

        // GET: Laboratories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Laboratories == null)
            {
                return NotFound();
            }

            var laboratory = await _context.Laboratories
                .Include(l => l.Project)
                .FirstOrDefaultAsync(m => m.LabId == id);
            if (laboratory == null)
            {
                return NotFound();
            }

            return View(laboratory);
        }

        // POST: Laboratories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Laboratories == null)
            {
                return Problem("Entity set 'WorkplandbContext.Laboratories'  is null.");
            }
            var laboratory = await _context.Laboratories.FindAsync(id);
            if (laboratory != null)
            {
                _context.Laboratories.Remove(laboratory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaboratoryExists(int id)
        {
            return (_context.Laboratories?.Any(e => e.LabId == id)).GetValueOrDefault();
        }
    }
}
