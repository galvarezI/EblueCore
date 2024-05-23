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
    public class ProjectStatusController : Controller
    {
        private readonly WorkplandbContext _context;

        public ProjectStatusController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: ProjectStatus
        public async Task<IActionResult> Index()
        {
              return View(await _context.ProjectStatuses.ToListAsync());
        }

        // GET: ProjectStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectStatuses == null)
            {
                return NotFound();
            }

            var projectStatus = await _context.ProjectStatuses
                .FirstOrDefaultAsync(m => m.ProjectStatusId == id);
            if (projectStatus == null)
            {
                return NotFound();
            }

            return View(projectStatus);
        }

        // GET: ProjectStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectstatusId,StatusNumber,StatusName")] ProjectStatus projectStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectStatus);
        }

        // GET: ProjectStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectStatuses == null)
            {
                return NotFound();
            }

            var projectStatus = await _context.ProjectStatuses.FindAsync(id);
            if (projectStatus == null)
            {
                return NotFound();
            }
            return View(projectStatus);
        }

        // POST: ProjectStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectstatusId,StatusNumber,StatusName")] ProjectStatus projectStatus)
        {
            if (id != projectStatus.ProjectStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectStatusExists(projectStatus.ProjectStatusId))
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
            return View(projectStatus);
        }

        // GET: ProjectStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectStatuses == null)
            {
                return NotFound();
            }

            var projectStatus = await _context.ProjectStatuses
                .FirstOrDefaultAsync(m => m.ProjectStatusId == id);
            if (projectStatus == null)
            {
                return NotFound();
            }

            return View(projectStatus);
        }

        // POST: ProjectStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectStatuses == null)
            {
                return Problem("Entity set 'WorkplandbContext.ProjectStatuses'  is null.");
            }
            var projectStatus = await _context.ProjectStatuses.FindAsync(id);
            if (projectStatus != null)
            {
                _context.ProjectStatuses.Remove(projectStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectStatusExists(int id)
        {
          return _context.ProjectStatuses.Any(e => e.ProjectStatusId == id);
        }
    }
}
