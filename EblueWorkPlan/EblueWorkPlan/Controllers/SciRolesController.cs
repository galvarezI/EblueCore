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
    public class SciRolesController : Controller
    {
        private readonly WorkplandbContext _context;

        public SciRolesController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: SciRoles
        public async Task<IActionResult> Index()
        {
              return View(await _context.SciRoles.ToListAsync());
        }

        // GET: SciRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SciRoles == null)
            {
                return NotFound();
            }

            var sciRole = await _context.SciRoles
                .FirstOrDefaultAsync(m => m.SciRolesId == id);
            if (sciRole == null)
            {
                return NotFound();
            }

            return View(sciRole);
        }

        // GET: SciRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SciRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SciRolesId,SciRoleName")] SciRole sciRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sciRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sciRole);
        }

        // GET: SciRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SciRoles == null)
            {
                return NotFound();
            }

            var sciRole = await _context.SciRoles.FindAsync(id);
            if (sciRole == null)
            {
                return NotFound();
            }
            return View(sciRole);
        }

        // POST: SciRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SciRolesId,SciRoleName")] SciRole sciRole)
        {
            if (id != sciRole.SciRolesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sciRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SciRoleExists(sciRole.SciRolesId))
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
            return View(sciRole);
        }

        // GET: SciRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SciRoles == null)
            {
                return NotFound();
            }

            var sciRole = await _context.SciRoles
                .FirstOrDefaultAsync(m => m.SciRolesId == id);
            if (sciRole == null)
            {
                return NotFound();
            }

            return View(sciRole);
        }

        // POST: SciRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SciRoles == null)
            {
                return Problem("Entity set 'WorkplandbContext.SciRoles'  is null.");
            }
            var sciRole = await _context.SciRoles.FindAsync(id);
            if (sciRole != null)
            {
                _context.SciRoles.Remove(sciRole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SciRoleExists(int id)
        {
          return _context.SciRoles.Any(e => e.SciRolesId == id);
        }
    }
}
