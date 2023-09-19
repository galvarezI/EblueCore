using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class CommoditiesController : Controller
    {
        private readonly WorkplandbContext _context;

        public CommoditiesController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: Commodities
        public async Task<IActionResult> Index()
        {
            return _context.Commodities != null ?
                        View(await _context.Commodities.ToListAsync()) :
                        Problem("Entity set 'WorkplandbContext.Commodities'  is null.");
        }

        // GET: Commodities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Commodities == null)
            {
                return NotFound();
            }

            var commodity = await _context.Commodities
                .FirstOrDefaultAsync(m => m.CommId == id);
            if (commodity == null)
            {
                return NotFound();
            }

            return View(commodity);
        }

        // GET: Commodities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Commodities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommId,CommName")] Commodity commodity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commodity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(commodity);
        }

        // GET: Commodities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Commodities == null)
            {
                return NotFound();
            }

            var commodity = await _context.Commodities.FindAsync(id);
            if (commodity == null)
            {
                return NotFound();
            }
            return View(commodity);
        }

        // POST: Commodities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommId,CommName")] Commodity commodity)
        {
            if (id != commodity.CommId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commodity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommodityExists(commodity.CommId))
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
            return View(commodity);
        }

        // GET: Commodities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Commodities == null)
            {
                return NotFound();
            }

            var commodity = await _context.Commodities
                .FirstOrDefaultAsync(m => m.CommId == id);
            if (commodity == null)
            {
                return NotFound();
            }

            return View(commodity);
        }

        // POST: Commodities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Commodities == null)
            {
                return Problem("Entity set 'WorkplandbContext.Commodities'  is null.");
            }
            var commodity = await _context.Commodities.FindAsync(id);
            if (commodity != null)
            {
                _context.Commodities.Remove(commodity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommodityExists(int id)
        {
            return (_context.Commodities?.Any(e => e.CommId == id)).GetValueOrDefault();
        }
    }
}
