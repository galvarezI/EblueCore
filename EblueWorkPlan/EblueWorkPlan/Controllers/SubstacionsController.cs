using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class SubstacionsController : Controller
    {
        private readonly WorkplandbContext _context;

        public SubstacionsController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: Substacions
        public async Task<IActionResult> Index()
        {
            return _context.Substacions != null ?
                        View(await _context.Substacions.ToListAsync()) :
                        Problem("Entity set 'WorkplandbContext.Substacions'  is null.");
        }

        // GET: Substacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Substacions == null)
            {
                return NotFound();
            }

            var substacion = await _context.Substacions
                .FirstOrDefaultAsync(m => m.SubstationId == id);
            if (substacion == null)
            {
                return NotFound();
            }

            return View(substacion);
        }

        // GET: Substacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Substacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubstationId,SubStationName")] Substacion substacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(substacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(substacion);
        }

        // GET: Substacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Substacions == null)
            {
                return NotFound();
            }

            var substacion = await _context.Substacions.FindAsync(id);
            if (substacion == null)
            {
                return NotFound();
            }
            return View(substacion);
        }

        // POST: Substacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubstationId,SubStationName")] Substacion substacion)
        {
            if (id != substacion.SubstationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(substacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubstacionExists(substacion.SubstationId))
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
            return View(substacion);
        }

        // GET: Substacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Substacions == null)
            {
                return NotFound();
            }

            var substacion = await _context.Substacions
                .FirstOrDefaultAsync(m => m.SubstationId == id);
            if (substacion == null)
            {
                return NotFound();
            }

            return View(substacion);
        }

        // POST: Substacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Substacions == null)
            {
                return Problem("Entity set 'WorkplandbContext.Substacions'  is null.");
            }
            var substacion = await _context.Substacions.FindAsync(id);
            if (substacion != null)
            {
                _context.Substacions.Remove(substacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubstacionExists(int id)
        {
            return (_context.Substacions?.Any(e => e.SubstationId == id)).GetValueOrDefault();
        }
    }
}
