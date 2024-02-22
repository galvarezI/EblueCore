using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EblueWorkPlan.Models;

namespace EblueWorkPlan.Controllers
{
    public class ThesisProjectsController : Controller
    {
        private readonly WorkplandbContext _context;

        public ThesisProjectsController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: ThesisProjects
        public async Task<IActionResult> Index()
        {
              return View(await _context.ThesisProjects.ToListAsync());
        }

        // GET: ThesisProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ThesisProjects == null)
            {
                return NotFound();
            }

            var thesisProject = await _context.ThesisProjects
                .FirstOrDefaultAsync(m => m.ThesisProjectId == id);
            if (thesisProject == null)
            {
                return NotFound();
            }

            return View(thesisProject);
        }

        // GET: ThesisProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThesisProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ThesisProjectId,OptionName")] ThesisProject thesisProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thesisProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thesisProject);
        }

        // GET: ThesisProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ThesisProjects == null)
            {
                return NotFound();
            }

            var thesisProject = await _context.ThesisProjects.FindAsync(id);
            if (thesisProject == null)
            {
                return NotFound();
            }
            return View(thesisProject);
        }

        // POST: ThesisProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ThesisProjectId,OptionName")] ThesisProject thesisProject)
        {
            if (id != thesisProject.ThesisProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thesisProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThesisProjectExists(thesisProject.ThesisProjectId))
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
            return View(thesisProject);
        }

        // GET: ThesisProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ThesisProjects == null)
            {
                return NotFound();
            }

            var thesisProject = await _context.ThesisProjects
                .FirstOrDefaultAsync(m => m.ThesisProjectId == id);
            if (thesisProject == null)
            {
                return NotFound();
            }

            return View(thesisProject);
        }

        // POST: ThesisProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ThesisProjects == null)
            {
                return Problem("Entity set 'WorkplandbContext.ThesisProjects'  is null.");
            }
            var thesisProject = await _context.ThesisProjects.FindAsync(id);
            if (thesisProject != null)
            {
                _context.ThesisProjects.Remove(thesisProject);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThesisProjectExists(int id)
        {
          return _context.ThesisProjects.Any(e => e.ThesisProjectId == id);
        }
    }
}
