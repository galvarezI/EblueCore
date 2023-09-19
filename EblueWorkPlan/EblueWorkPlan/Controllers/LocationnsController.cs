using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class LocationnsController : Controller
    {
        private readonly WorkplandbContext _context;

        public LocationnsController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: Locationns
        public async Task<IActionResult> Index()
        {
            return _context.Locationns != null ?
                        View(await _context.Locationns.ToListAsync()) :
                        Problem("Entity set 'WorkplandbContext.Locationns'  is null.");
        }

        // GET: Locationns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Locationns == null)
            {
                return NotFound();
            }

            var locationn = await _context.Locationns
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (locationn == null)
            {
                return NotFound();
            }

            return View(locationn);
        }

        // GET: Locationns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locationns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocationId,LocationName,LocationOldId,FundsVar")] Locationn locationn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locationn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locationn);
        }

        // GET: Locationns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Locationns == null)
            {
                return NotFound();
            }

            var locationn = await _context.Locationns.FindAsync(id);
            if (locationn == null)
            {
                return NotFound();
            }
            return View(locationn);
        }

        // POST: Locationns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocationId,LocationName,LocationOldId,FundsVar")] Locationn locationn)
        {
            if (id != locationn.LocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locationn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocationnExists(locationn.LocationId))
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
            return View(locationn);
        }

        // GET: Locationns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Locationns == null)
            {
                return NotFound();
            }

            var locationn = await _context.Locationns
                .FirstOrDefaultAsync(m => m.LocationId == id);
            if (locationn == null)
            {
                return NotFound();
            }

            return View(locationn);
        }

        // POST: Locationns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Locationns == null)
            {
                return Problem("Entity set 'WorkplandbContext.Locationns'  is null.");
            }
            var locationn = await _context.Locationns.FindAsync(id);
            if (locationn != null)
            {
                _context.Locationns.Remove(locationn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocationnExists(int id)
        {
            return (_context.Locationns?.Any(e => e.LocationId == id)).GetValueOrDefault();
        }
    }
}
