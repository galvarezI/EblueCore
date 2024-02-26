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
    public class GradOptionsController : Controller
    {
        private readonly WorkplandbContext _context;

        public GradOptionsController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: GradOptions
        public async Task<IActionResult> Index()
        {
              return View(await _context.GradOptions.ToListAsync());
        }

        // GET: GradOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GradOptions == null)
            {
                return NotFound();
            }

            var gradOption = await _context.GradOptions
                .FirstOrDefaultAsync(m => m.GradoptionId == id);
            if (gradOption == null)
            {
                return NotFound();
            }

            return View(gradOption);
        }

        // GET: GradOptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GradOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GradoptionId,GradOptionName")] GradOption gradOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gradOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gradOption);
        }

        // GET: GradOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GradOptions == null)
            {
                return NotFound();
            }

            var gradOption = await _context.GradOptions.FindAsync(id);
            if (gradOption == null)
            {
                return NotFound();
            }
            return View(gradOption);
        }

        // POST: GradOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GradoptionId,GradOptionName")] GradOption gradOption)
        {
            if (id != gradOption.GradoptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gradOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradOptionExists(gradOption.GradoptionId))
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
            return View(gradOption);
        }

        // GET: GradOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GradOptions == null)
            {
                return NotFound();
            }

            var gradOption = await _context.GradOptions
                .FirstOrDefaultAsync(m => m.GradoptionId == id);
            if (gradOption == null)
            {
                return NotFound();
            }

            return View(gradOption);
        }

        // POST: GradOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GradOptions == null)
            {
                return Problem("Entity set 'WorkplandbContext.GradOptions'  is null.");
            }
            var gradOption = await _context.GradOptions.FindAsync(id);
            if (gradOption != null)
            {
                _context.GradOptions.Remove(gradOption);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradOptionExists(int id)
        {
          return _context.GradOptions.Any(e => e.GradoptionId == id);
        }
    }
}
