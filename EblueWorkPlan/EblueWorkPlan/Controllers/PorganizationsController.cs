using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class PorganizationsController : Controller
    {
        private readonly WorkplandbContext _context;

        public PorganizationsController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: Porganizations
        public async Task<IActionResult> Index()
        {
            return _context.Porganizations != null ?
                        View(await _context.Porganizations.ToListAsync()) :
                        Problem("Entity set 'WorkplandbContext.Porganizations'  is null.");
        }

        // GET: Porganizations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Porganizations == null)
            {
                return NotFound();
            }

            var porganization = await _context.Porganizations
                .FirstOrDefaultAsync(m => m.PorganizationId == id);
            if (porganization == null)
            {
                return NotFound();
            }

            return View(porganization);
        }

        // GET: Porganizations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Porganizations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PorganizationId,PorganizationName")] Porganization porganization)
        {
            if (ModelState.IsValid)
            {
                _context.Add(porganization);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(porganization);
        }

        // GET: Porganizations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Porganizations == null)
            {
                return NotFound();
            }

            var porganization = await _context.Porganizations.FindAsync(id);
            if (porganization == null)
            {
                return NotFound();
            }
            return View(porganization);
        }

        // POST: Porganizations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PorganizationId,PorganizationName")] Porganization porganization)
        {
            if (id != porganization.PorganizationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(porganization);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PorganizationExists(porganization.PorganizationId))
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
            return View(porganization);
        }

        // GET: Porganizations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Porganizations == null)
            {
                return NotFound();
            }

            var porganization = await _context.Porganizations
                .FirstOrDefaultAsync(m => m.PorganizationId == id);
            if (porganization == null)
            {
                return NotFound();
            }

            return View(porganization);
        }

        // POST: Porganizations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Porganizations == null)
            {
                return Problem("Entity set 'WorkplandbContext.Porganizations'  is null.");
            }
            var porganization = await _context.Porganizations.FindAsync(id);
            if (porganization != null)
            {
                _context.Porganizations.Remove(porganization);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PorganizationExists(int id)
        {
            return (_context.Porganizations?.Any(e => e.PorganizationId == id)).GetValueOrDefault();
        }
    }
}
