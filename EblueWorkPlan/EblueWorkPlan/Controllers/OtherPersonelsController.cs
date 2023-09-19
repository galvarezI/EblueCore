using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class OtherPersonelsController : Controller
    {
        private readonly WorkplandbContext _context;

        public OtherPersonelsController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: OtherPersonels
        public async Task<IActionResult> Index()
        {

            ViewBag.LocationItem = new SelectList(_context.Locationns, "LocationId", "LocationName");
            ViewBag.ProjectsItem = new SelectList(_context.Projects, "ProjectId", "ProjectName");
            ViewBag.RosterItem = new SelectList(_context.Rosters, "RosterId", "RosterName");
            var workplandbContext = _context.OtherPersonels.Include(o => o.Location).Include(o => o.Project).Include(o => o.Roster);
            return View(await workplandbContext.ToListAsync());
        }

        // GET: OtherPersonels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OtherPersonels == null)
            {
                return NotFound();
            }

            var otherPersonel = await _context.OtherPersonels
                .Include(o => o.Location)
                .Include(o => o.Project)
                .Include(o => o.Roster)
                .FirstOrDefaultAsync(m => m.Opid == id);
            if (otherPersonel == null)
            {
                return NotFound();
            }

            return View(otherPersonel);
        }

        // GET: OtherPersonels/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Locationns, "LocationId", "LocationId");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId");
            return View();
        }

        // POST: OtherPersonels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Opid,Name,PerTime,ProjectId,LocationId,RosterId,PersonnelManAdded,RoleManAdded")] OtherPersonel otherPersonel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(otherPersonel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locationns, "LocationId", "LocationId", otherPersonel.LocationId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", otherPersonel.ProjectId);
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", otherPersonel.RosterId);
            return View(otherPersonel);
        }

        // GET: OtherPersonels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OtherPersonels == null)
            {
                return NotFound();
            }

            var otherPersonel = await _context.OtherPersonels.FindAsync(id);
            if (otherPersonel == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locationns, "LocationId", "LocationId", otherPersonel.LocationId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", otherPersonel.ProjectId);
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", otherPersonel.RosterId);
            return View(otherPersonel);
        }

        // POST: OtherPersonels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Opid,Name,PerTime,ProjectId,LocationId,RosterId,PersonnelManAdded,RoleManAdded")] OtherPersonel otherPersonel)
        {
            if (id != otherPersonel.Opid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(otherPersonel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtherPersonelExists(otherPersonel.Opid))
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
            ViewData["LocationId"] = new SelectList(_context.Locationns, "LocationId", "LocationId", otherPersonel.LocationId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", otherPersonel.ProjectId);
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", otherPersonel.RosterId);
            return View(otherPersonel);
        }

        // GET: OtherPersonels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OtherPersonels == null)
            {
                return NotFound();
            }

            var otherPersonel = await _context.OtherPersonels
                .Include(o => o.Location)
                .Include(o => o.Project)
                .Include(o => o.Roster)
                .FirstOrDefaultAsync(m => m.Opid == id);
            if (otherPersonel == null)
            {
                return NotFound();
            }

            return View(otherPersonel);
        }

        // POST: OtherPersonels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OtherPersonels == null)
            {
                return Problem("Entity set 'WorkplandbContext.OtherPersonels'  is null.");
            }
            var otherPersonel = await _context.OtherPersonels.FindAsync(id);
            if (otherPersonel != null)
            {
                _context.OtherPersonels.Remove(otherPersonel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtherPersonelExists(int id)
        {
            return (_context.OtherPersonels?.Any(e => e.Opid == id)).GetValueOrDefault();
        }
    }
}
