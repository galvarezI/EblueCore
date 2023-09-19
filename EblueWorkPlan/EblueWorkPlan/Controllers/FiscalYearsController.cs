using EblueWorkPlan.Models;
using EblueWorkPlan.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class FiscalYearsController : Controller
    {
        private readonly WorkplandbContext _context;

        public FiscalYearsController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: FiscalYears
        public async Task<IActionResult> Index()
        {
            var workplandbContext = _context.FiscalYears.Include(f => f.FiscalYearStatus);
            return View(await workplandbContext.ToListAsync());
        }

        // GET: FiscalYears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FiscalYears == null)
            {
                return NotFound();
            }

            var fiscalYear = await _context.FiscalYears
                .Include(f => f.FiscalYearStatus)
                .FirstOrDefaultAsync(m => m.FiscalYearId == id);
            if (fiscalYear == null)
            {
                return NotFound();
            }

            return View(fiscalYear);
        }

        // GET: FiscalYears/Create
        public IActionResult Create()
        {
            ViewData["FiscalYearStatusId"] = new SelectList(_context.FiscalYearStatuses, "FiscalYearStatusId", "FiscalYearStatusName");
            return View();
        }

        // POST: FiscalYears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*Bind("FiscalYearId,FiscalYearName,FiscalYearNumber,LastUpdate,FiscalYearStatusId")] FiscalYear fiscalYear*/ FiscalYearViewModel fiscalYear)
        {
            if (ModelState.IsValid)
            {
                var fiscalyear = new FiscalYear()
                {
                    FiscalYearName = fiscalYear.FiscalYearName,
                    FiscalYearNumber = fiscalYear.FiscalYearNumber,
                    FiscalYearStatusId = fiscalYear.FiscalYearStatusId,


                };

                _context.Add(fiscalyear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FiscalYearStatusId"] = new SelectList(_context.FiscalYearStatuses, "FiscalYearStatusId", "FiscalYearStatusId");
            return View();
        }

        // GET: FiscalYears/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FiscalYears == null)
            {
                return NotFound();
            }

            var fiscalYear = await _context.FiscalYears.FindAsync(id);
            if (fiscalYear == null)
            {
                return NotFound();
            }
            ViewData["FiscalYearStatusId"] = new SelectList(_context.FiscalYearStatuses, "FiscalYearStatusId", "FiscalYearStatusId", fiscalYear.FiscalYearStatusId);
            return View(fiscalYear);
        }

        // POST: FiscalYears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FiscalYearId,FiscalYearName,FiscalYearNumber,LastUpdate,FiscalYearStatusId")] FiscalYear fiscalYear)
        {
            if (id != fiscalYear.FiscalYearId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fiscalYear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FiscalYearExists(fiscalYear.FiscalYearId))
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
            ViewData["FiscalYearStatusId"] = new SelectList(_context.FiscalYearStatuses, "FiscalYearStatusId", "FiscalYearStatusId", fiscalYear.FiscalYearStatusId);
            return View(fiscalYear);
        }

        // GET: FiscalYears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FiscalYears == null)
            {
                return NotFound();
            }

            var fiscalYear = await _context.FiscalYears
                .Include(f => f.FiscalYearStatus)
                .FirstOrDefaultAsync(m => m.FiscalYearId == id);
            if (fiscalYear == null)
            {
                return NotFound();
            }

            return View(fiscalYear);
        }

        // POST: FiscalYears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FiscalYears == null)
            {
                return Problem("Entity set 'WorkplandbContext.FiscalYears'  is null.");
            }
            var fiscalYear = await _context.FiscalYears.FindAsync(id);
            if (fiscalYear != null)
            {
                _context.FiscalYears.Remove(fiscalYear);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FiscalYearExists(int id)
        {
            return (_context.FiscalYears?.Any(e => e.FiscalYearId == id)).GetValueOrDefault();
        }
    }
}
