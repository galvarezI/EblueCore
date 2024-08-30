using EblueWorkPlan.Migrations;
using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class RostersController : Controller
    {
        private readonly WorkplandbContext _context;
        //private readonly AddIdntityDB _idntityDB;
        private readonly UserManager<IdentityUser> userManager;

        public RostersController(WorkplandbContext context/* AddIdntityDB identityDB*/ /*UserManager<IdentityUser> userManager*/)
        {
            _context = context;
            //_idntityDB = identityDB;
            //this.userManager = userManager;
        }

        // GET: Rosters
        public async Task<IActionResult> Index()
        {

            
            return _context.Rosters != null ?
                        View(await _context.Rosters.ToListAsync()) :
                        Problem("Entity set 'WorkplandbContext.Rosters'  is null.");


        }

        // GET: Rosters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rosters == null)
            {
                return NotFound();
            }

            var roster = await _context.Rosters
                .FirstOrDefaultAsync(m => m.RosterId == id);
            if (roster == null)
            {
                return NotFound();
            }

            return View(roster);
        }

        // GET: Rosters/Create
        public IActionResult Create()
        {

            ViewBag.DepartmentItem = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.LocationItem = new SelectList(_context.Locationns, "LocationId", "LocationName");
            ViewBag.RoleItem = new SelectList(_context.Roles, "RolesId", "Rname");
            return View();
        }

        // POST: Rosters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RosterId,RosterSegSoc,RosterName,DepartmentId,LocationId,CanBePi,RoleId")] Roster roster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }



            return View(roster);
        }

        // GET: Rosters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rosters == null)
            {
                return NotFound();
            }

            var roster = await _context.Rosters.FindAsync(id);
            if (roster == null)
            {
                return NotFound();
            }

            ViewBag.DepartmentItem = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.LocationItem = new SelectList(_context.Locationns, "LocationId", "LocationName");
            ViewBag.RoleItem = new SelectList(_context.Roles, "RolesId", "Rname");
            return View(roster);
        }

        // POST: Rosters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RosterId,RosterSegSoc,RosterName,DepartmentId,LocationId,CanBePi,RoleId")] Roster roster)
        {
            if (id != roster.RosterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RosterExists(roster.RosterId))
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
            return View(roster);
        }

        // GET: Rosters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rosters == null)
            {
                return NotFound();
            }

            var roster = await _context.Rosters
                .FirstOrDefaultAsync(m => m.RosterId == id);
            if (roster == null)
            {
                return NotFound();
            }
            ViewBag.DepartmentItem = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewBag.LocationItem = new SelectList(_context.Locationns, "LocationId", "LocationName");
            ViewBag.RoleItem = new SelectList(_context.Roles, "RolesId", "Rname");
            return View(roster);
        }

        // POST: Rosters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rosters == null)
            {
                return Problem("Entity set 'WorkplandbContext.Rosters'  is null.");
            }
            var roster = await _context.Rosters.FindAsync(id);
            if (roster != null)
            {
                _context.Rosters.Remove(roster);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RosterExists(int id)
        {
            return (_context.Rosters?.Any(e => e.RosterId == id)).GetValueOrDefault();
        }
    }
}
