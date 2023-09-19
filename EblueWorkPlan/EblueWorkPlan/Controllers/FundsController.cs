using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class FundsController : Controller
    {
        private readonly WorkplandbContext _context;

        public FundsController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: Funds
        public async Task<IActionResult> Index()
        {

            ViewBag.LocationItem = new SelectList(_context.Locationns, "LocationId", "LocationName");
            ViewBag.ProjectsItem = new SelectList(_context.Projects, "ProjectId", "ProjectName");
            var workplandbContext = _context.Funds.Include(f => f.Location).Include(f => f.Project);
            return View(await workplandbContext.ToListAsync());
        }

        // GET: Funds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Funds == null)
            {
                return NotFound();
            }

            var fund = await _context.Funds
                .Include(f => f.Location)
                .Include(f => f.Project)
                .FirstOrDefaultAsync(m => m.FundId == id);
            if (fund == null)
            {
                return NotFound();
            }

            return View(fund);
        }

        // GET: Funds/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Locationns, "LocationId", "LocationId");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            return View();
        }

        // POST: Funds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FundId,LocationId,Salaries,Wages,Benefits,Assistant,Materials,Equipment,Travel,Abroad,Subcontracts,Others,ProjectId,Ufisaccount,IndirectCosts")] Fund fund)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fund);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locationns, "LocationId", "LocationId", fund.LocationId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", fund.ProjectId);
            return View(fund);
        }

        // GET: Funds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Funds == null)
            {
                return NotFound();
            }

            var fund = await _context.Funds.FindAsync(id);
            if (fund == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locationns, "LocationId", "LocationId", fund.LocationId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", fund.ProjectId);
            return View(fund);
        }

        // POST: Funds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FundId,LocationId,Salaries,Wages,Benefits,Assistant,Materials,Equipment,Travel,Abroad,Subcontracts,Others,ProjectId,Ufisaccount,IndirectCosts")] Fund fund)
        {
            if (id != fund.FundId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fund);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FundExists(fund.FundId))
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
            ViewData["LocationId"] = new SelectList(_context.Locationns, "LocationId", "LocationId", fund.LocationId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", fund.ProjectId);
            return View(fund);
        }

        // GET: Funds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Funds == null)
            {
                return NotFound();
            }

            var fund = await _context.Funds
                .Include(f => f.Location)
                .Include(f => f.Project)
                .FirstOrDefaultAsync(m => m.FundId == id);
            if (fund == null)
            {
                return NotFound();
            }

            return View(fund);
        }

        // POST: Funds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Funds == null)
            {
                return Problem("Entity set 'WorkplandbContext.Funds'  is null.");
            }
            var fund = await _context.Funds.FindAsync(id);
            if (fund != null)
            {
                _context.Funds.Remove(fund);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FundExists(int id)
        {
            return (_context.Funds?.Any(e => e.FundId == id)).GetValueOrDefault();
        }
    }
}
