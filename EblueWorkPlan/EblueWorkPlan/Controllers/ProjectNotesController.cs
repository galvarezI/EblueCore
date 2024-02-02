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
    public class ProjectNotesController : Controller
    {
        private readonly WorkplandbContext _context;

        public ProjectNotesController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: ProjectNotes
        public async Task<IActionResult> Index()
        {
            var workplandbContext = _context.ProjectNotes.Include(p => p.Project).Include(p => p.Roster).Include(p => p.User);
            return View(await workplandbContext.ToListAsync());
        }

        // GET: ProjectNotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectNotes == null)
            {
                return NotFound();
            }

            var projectNote = await _context.ProjectNotes
                .Include(p => p.Project)
                .Include(p => p.Roster)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProjectNotesId == id);
            if (projectNote == null)
            {
                return NotFound();
            }

            return View(projectNote);
        }

        // GET: ProjectNotes/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Users, "UserId", "UserId");
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: ProjectNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectNotesId,Comment,LastUpdate,UserId,ProjectId,RosterId,Username")] ProjectNote projectNote)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectNote);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Users, "UserId", "UserId", projectNote.ProjectId);
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", projectNote.RosterId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", projectNote.UserId);
            return View(projectNote);
        }

        // GET: ProjectNotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectNotes == null)
            {
                return NotFound();
            }

            var projectNote = await _context.ProjectNotes.FindAsync(id);
            if (projectNote == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Users, "UserId", "UserId", projectNote.ProjectId);
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", projectNote.RosterId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", projectNote.UserId);
            return View(projectNote);
        }

        // POST: ProjectNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProjectNotesId,Comment,LastUpdate,UserId,ProjectId,RosterId,Username")] ProjectNote projectNote)
        {
            if (id != projectNote.ProjectNotesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectNote);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectNoteExists(projectNote.ProjectNotesId))
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
            ViewData["ProjectId"] = new SelectList(_context.Users, "UserId", "UserId", projectNote.ProjectId);
            ViewData["RosterId"] = new SelectList(_context.Rosters, "RosterId", "RosterId", projectNote.RosterId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", projectNote.UserId);
            return View(projectNote);
        }

        // GET: ProjectNotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectNotes == null)
            {
                return NotFound();
            }

            var projectNote = await _context.ProjectNotes
                .Include(p => p.Project)
                .Include(p => p.Roster)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.ProjectNotesId == id);
            if (projectNote == null)
            {
                return NotFound();
            }

            return View(projectNote);
        }

        // POST: ProjectNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectNotes == null)
            {
                return Problem("Entity set 'WorkplandbContext.ProjectNotes'  is null.");
            }
            var projectNote = await _context.ProjectNotes.FindAsync(id);
            if (projectNote != null)
            {
                _context.ProjectNotes.Remove(projectNote);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectNoteExists(int id)
        {
          return _context.ProjectNotes.Any(e => e.ProjectNotesId == id);
        }
    }
}
