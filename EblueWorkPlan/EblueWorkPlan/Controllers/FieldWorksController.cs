using EblueWorkPlan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EblueWorkPlan.Controllers
{
    public class FieldWorksController : Controller
    {
        private readonly WorkplandbContext _context;
        private List<SelectListItem> _locationsItems;
        private List<SelectListItem> _projectsItems;
        public FieldWorksController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: FieldWorks
        public async Task<IActionResult> Index()
        {
            var workplandbContext = _context.FieldWorks.Include(f => f.Location).Include(f => f.Project);
            return View(await workplandbContext.ToListAsync());

            ViewBag.LocationItem = new SelectList(_context.Locationns, "LocationId", "LocationName");
        }

        // GET: FieldWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FieldWorks == null)
            {
                return NotFound();
            }

            var fieldWork = await _context.FieldWorks
                .Include(f => f.Location)
                .Include(f => f.Project)
                .FirstOrDefaultAsync(m => m.FieldWorkId == id);
            if (fieldWork == null)
            {
                return NotFound();
            }

            return View(fieldWork);
        }

        // GET: FieldWorks/Create
        public IActionResult Create()
        {
            var location = _context.Locationns.ToList();
            _locationsItems = new List<SelectListItem>();
            foreach (var item in location)
            {

                _locationsItems.Add(new SelectListItem
                {
                    Text = item.LocationName,
                    Value = item.LocationId.ToString()
                });
                ViewBag.locationsItems = _locationsItems;

                _locationsItems.Add(new SelectListItem
                {
                    Text = item.LocationName,
                    Value = item.LocationId.ToString()
                });
                ViewBag.locationsItems = _locationsItems;
            }


            var proyect = _context.Projects.ToList();
            _projectsItems = new List<SelectListItem>();
            foreach (var item in  proyect)
            {

                _projectsItems.Add(new SelectListItem
                {
                    Text = item.ProjectTitle,
                    Value = item.ProjectId.ToString()
                });
                ViewBag.projectsItems = _projectsItems;

              
            }







            ViewData["LocationId"] = new SelectList(_context.Locationns, "LocationId", "LocationId");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");

            ViewBag.LocationItem = new SelectList(_context.Locationns, "LocationId", "LocationName");
            ViewBag.ProjectItem = new SelectList(_context.Projects, "ProjectId", "ProjectNumber");
            return View();
        }

        // POST: FieldWorks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FieldWorkId,ProjectId,LocationId,DateStarted,DateEnded,InProgress,ToBeInitiated")] FieldWork fieldWork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fieldWork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locationns, "LocationId", "LocationId", fieldWork.LocationId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", fieldWork.ProjectId);
            return View(fieldWork);
        }

        // GET: FieldWorks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FieldWorks == null)
            {
                return NotFound();
            }

            var fieldWork = await _context.FieldWorks.FindAsync(id);
            if (fieldWork == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locationns, "LocationId", "LocationId", fieldWork.LocationId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", fieldWork.ProjectId);
            return View(fieldWork);
        }

        // POST: FieldWorks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FieldWorkId,ProjectId,LocationId,DateStarted,DateEnded,InProgress,ToBeInitiated")] FieldWork fieldWork)
        {
            if (id != fieldWork.FieldWorkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fieldWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldWorkExists(fieldWork.FieldWorkId))
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
            ViewData["LocationId"] = new SelectList(_context.Locationns, "LocationId", "LocationId", fieldWork.LocationId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", fieldWork.ProjectId);
            return View(fieldWork);
        }

        // GET: FieldWorks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FieldWorks == null)
            {
                return NotFound();
            }

            var fieldWork = await _context.FieldWorks
                .Include(f => f.Location)
                .Include(f => f.Project)
                .FirstOrDefaultAsync(m => m.FieldWorkId == id);
            if (fieldWork == null)
            {
                return NotFound();
            }

            return View(fieldWork);
        }

        // POST: FieldWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FieldWorks == null)
            {
                return Problem("Entity set 'WorkplandbContext.FieldWorks'  is null.");
            }
            var fieldWork = await _context.FieldWorks.FindAsync(id);
            if (fieldWork != null)
            {
                _context.FieldWorks.Remove(fieldWork);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FieldWorkExists(int id)
        {
            return (_context.FieldWorks?.Any(e => e.FieldWorkId == id)).GetValueOrDefault();
        }




        public IActionResult Page3()
        {
            ViewData["LocationId"] = new SelectList(_context.Locationns, "LocationId", "LocationId");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId");

            ViewBag.LocationItem = new SelectList(_context.Locationns, "LocationId", "LocationName");
            ViewBag.ProjectItem = new SelectList(_context.Projects, "ProjectId", "ProjectNumber");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Page3([Bind("FieldWorkId,ProjectId,LocationId,DateStarted,DateEnded,InProgress,ToBeInitiated")] FieldWork fieldWork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fieldWork);
                await _context.SaveChangesAsync();
                RedirectTo("", "");
            }
            ViewData["LocationId"] = new SelectList(_context.Locationns, "LocationId", "LocationId", fieldWork.LocationId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", fieldWork.ProjectId);
            return View(fieldWork);
        }



        public ActionResult RedirectTo(string action, string controller)
        {
            return RedirectToAction(action, controller);
        }

    }
}
