using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class UsersController : Controller
    {
        private readonly WorkplandbContext _context;
       
        private List<SelectListItem> _rosterItems;
        private List<SelectListItem> _departmentsItems;
        private List<SelectListItem> _porganizationsItems;

        private List<SelectListItem> _fundtypeItems;
        private List<SelectListItem> _commodityItems;
        private List<SelectListItem> _fiscalYearItems;
        private List<SelectListItem> _substationItems;
        private List<SelectListItem> _programAreaItems;
        private List<SelectListItem> _locationsItems;

        public UsersController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var workplandbContext = _context.Users.Include(u => u.Roster);
            return View(await workplandbContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Roster)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterName");
            ViewData["RosterName"] = new SelectList(_context.Rosters, "RosterId", "RosterName");
            var rosters = _context.Rosters.ToList();
            _rosterItems = new List<SelectListItem>();
            foreach (var item in rosters)
            {
                _rosterItems.Add(new SelectListItem
                {
                    Text = item.RosterName,
                    Value = item.RosterId.ToString()
                });
            }
            ViewBag.rosterItems = _rosterItems;
            ViewData["selectedProjectPI"] = _rosterItems;


            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Email,Password,RosterId,IsEnabled")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", user.RosterId);
            ViewData["RosterName"] = new SelectList(_context.Rosters, "RosterId", "RosterName");
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", user.RosterId);
            ViewData["RosterName"] = new SelectList(_context.Rosters, "RosterId", "RosterName");
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Email,Password,RosterId,IsEnabled")] User user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
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
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", user.RosterId);
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .Include(u => u.Roster)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'WorkplandbContext.Users'  is null.");
            }
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
