using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class ProgramAreasController : Controller
    {
        private readonly WorkplandbContext _context;

        public ProgramAreasController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: ProgramAreas
        public async Task<IActionResult> Index()
        {
            return _context.ProgramAreas != null ?
                        View(await _context.ProgramAreas.ToListAsync()) :
                        Problem("Entity set 'WorkplandbContext.ProgramAreas'  is null.");
        }

        // GET: ProgramAreas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProgramAreas == null)
            {
                return NotFound();
            }

            var programArea = await _context.ProgramAreas
                .FirstOrDefaultAsync(m => m.ProgramAreaId == id);
            if (programArea == null)
            {
                return NotFound();
            }

            return View(programArea);
        }

        // GET: ProgramAreas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgramAreas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProgramAreaId,ProgramAreaName,ProgramAreaOldId,RosterProgragmaticCoordinatorId")] ProgramArea programArea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(programArea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(programArea);
        }

        // GET: ProgramAreas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProgramAreas == null)
            {
                return NotFound();
            }

            var programArea = await _context.ProgramAreas.FindAsync(id);
            if (programArea == null)
            {
                return NotFound();
            }
            return View(programArea);
        }

        // POST: ProgramAreas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProgramAreaId,ProgramAreaName,ProgramAreaOldId,RosterProgragmaticCoordinatorId")] ProgramArea programArea)
        {
            if (id != programArea.ProgramAreaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programArea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramAreaExists(programArea.ProgramAreaId))
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
            return View(programArea);
        }

        // GET: ProgramAreas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProgramAreas == null)
            {
                return NotFound();
            }

            var programArea = await _context.ProgramAreas
                .FirstOrDefaultAsync(m => m.ProgramAreaId == id);
            if (programArea == null)
            {
                return NotFound();
            }

            return View(programArea);
        }

        // POST: ProgramAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProgramAreas == null)
            {
                return Problem("Entity set 'WorkplandbContext.ProgramAreas'  is null.");
            }
            var programArea = await _context.ProgramAreas.FindAsync(id);
            if (programArea != null)
            {
                _context.ProgramAreas.Remove(programArea);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramAreaExists(int id)
        {
            return (_context.ProgramAreas?.Any(e => e.ProgramAreaId == id)).GetValueOrDefault();
        }
    }
}
