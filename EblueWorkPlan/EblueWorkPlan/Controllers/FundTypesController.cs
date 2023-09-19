using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class FundTypesController : Controller
    {
        private readonly WorkplandbContext _context;

        public FundTypesController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: FundTypes
        public async Task<IActionResult> Index()
        {
            return _context.FundTypes != null ?
                        View(await _context.FundTypes.ToListAsync()) :
                        Problem("Entity set 'WorkplandbContext.FundTypes'  is null.");
        }

        // GET: FundTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FundTypes == null)
            {
                return NotFound();
            }

            var fundType = await _context.FundTypes
                .FirstOrDefaultAsync(m => m.FundTypeId == id);
            if (fundType == null)
            {
                return NotFound();
            }

            return View(fundType);
        }

        // GET: FundTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FundTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FundTypeId,FundTypeName,IsFederal,IsState")] FundType fundType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fundType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fundType);
        }

        // GET: FundTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FundTypes == null)
            {
                return NotFound();
            }

            var fundType = await _context.FundTypes.FindAsync(id);
            if (fundType == null)
            {
                return NotFound();
            }
            return View(fundType);
        }

        // POST: FundTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FundTypeId,FundTypeName,IsFederal,IsState")] FundType fundType)
        {
            if (id != fundType.FundTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fundType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FundTypeExists(fundType.FundTypeId))
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
            return View(fundType);
        }

        // GET: FundTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FundTypes == null)
            {
                return NotFound();
            }

            var fundType = await _context.FundTypes
                .FirstOrDefaultAsync(m => m.FundTypeId == id);
            if (fundType == null)
            {
                return NotFound();
            }

            return View(fundType);
        }

        // POST: FundTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FundTypes == null)
            {
                return Problem("Entity set 'WorkplandbContext.FundTypes'  is null.");
            }
            var fundType = await _context.FundTypes.FindAsync(id);
            if (fundType != null)
            {
                _context.FundTypes.Remove(fundType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FundTypeExists(int id)
        {
            return (_context.FundTypes?.Any(e => e.FundTypeId == id)).GetValueOrDefault();
        }
    }
}
