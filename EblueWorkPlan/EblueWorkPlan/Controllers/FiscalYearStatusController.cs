using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class FiscalYearStatusController : Controller
    {
        private readonly WorkplandbContext _context;

        public FiscalYearStatusController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: FiscalYearStatus
        public async Task<IActionResult> Index()
        {
            return _context.FiscalYearStatuses != null ?
                        View(await _context.FiscalYearStatuses.ToListAsync()) :
                        Problem("Entity set 'WorkplandbContext.FiscalYearStatuses'  is null.");
        }

        // GET: FiscalYearStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FiscalYearStatuses == null)
            {
                return NotFound();
            }

            var fiscalYearStatus = await _context.FiscalYearStatuses
                .FirstOrDefaultAsync(m => m.FiscalYearStatusId == id);
            if (fiscalYearStatus == null)
            {
                return NotFound();
            }

            return View(fiscalYearStatus);
        }

        // GET: FiscalYearStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FiscalYearStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FiscalYearStatusId,FiscalYearStatusName")] FiscalYearStatus fiscalYearStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fiscalYearStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fiscalYearStatus);
        }

        // GET: FiscalYearStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FiscalYearStatuses == null)
            {
                return NotFound();
            }

            var fiscalYearStatus = await _context.FiscalYearStatuses.FindAsync(id);
            if (fiscalYearStatus == null)
            {
                return NotFound();
            }
            return View(fiscalYearStatus);
        }

        // POST: FiscalYearStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FiscalYearStatusId,FiscalYearStatusName")] FiscalYearStatus fiscalYearStatus)
        {
            if (id != fiscalYearStatus.FiscalYearStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fiscalYearStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiscalYearStatusExists(fiscalYearStatus.FiscalYearStatusId))
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
            return View(fiscalYearStatus);
        }

        // GET: FiscalYearStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FiscalYearStatuses == null)
            {
                return NotFound();
            }

            var fiscalYearStatus = await _context.FiscalYearStatuses
                .FirstOrDefaultAsync(m => m.FiscalYearStatusId == id);
            if (fiscalYearStatus == null)
            {
                return NotFound();
            }

            return View(fiscalYearStatus);
        }

        // POST: FiscalYearStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FiscalYearStatuses == null)
            {
                return Problem("Entity set 'WorkplandbContext.FiscalYearStatuses'  is null.");
            }
            var fiscalYearStatus = await _context.FiscalYearStatuses.FindAsync(id);
            if (fiscalYearStatus != null)
            {
                _context.FiscalYearStatuses.Remove(fiscalYearStatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiscalYearStatusExists(int id)
        {
            return (_context.FiscalYearStatuses?.Any(e => e.FiscalYearStatusId == id)).GetValueOrDefault();
        }
    }
}
