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
    public class FieldOptionsController : Controller
    {
        private readonly WorkplandbContext _context;

        public FieldOptionsController(WorkplandbContext context)
        {
            _context = context;
        }

        // GET: FieldOptions
        public async Task<IActionResult> Index()
        {
              return View(await _context.FieldOptions.ToListAsync());
        }

        // GET: FieldOptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FieldOptions == null)
            {
                return NotFound();
            }

            var fieldOption = await _context.FieldOptions
                .FirstOrDefaultAsync(m => m.FieldoptionId == id);
            if (fieldOption == null)
            {
                return NotFound();
            }

            return View(fieldOption);
        }

        // GET: FieldOptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FieldOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FieldoptionId,OptionName")] FieldOption fieldOption)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fieldOption);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fieldOption);
        }

        // GET: FieldOptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FieldOptions == null)
            {
                return NotFound();
            }

            var fieldOption = await _context.FieldOptions.FindAsync(id);
            if (fieldOption == null)
            {
                return NotFound();
            }
            return View(fieldOption);
        }

        // POST: FieldOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FieldoptionId,OptionName")] FieldOption fieldOption)
        {
            if (id != fieldOption.FieldoptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fieldOption);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldOptionExists(fieldOption.FieldoptionId))
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
            return View(fieldOption);
        }

        // GET: FieldOptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FieldOptions == null)
            {
                return NotFound();
            }

            var fieldOption = await _context.FieldOptions
                .FirstOrDefaultAsync(m => m.FieldoptionId == id);
            if (fieldOption == null)
            {
                return NotFound();
            }

            return View(fieldOption);
        }

        // POST: FieldOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FieldOptions == null)
            {
                return Problem("Entity set 'WorkplandbContext.FieldOptions'  is null.");
            }
            var fieldOption = await _context.FieldOptions.FindAsync(id);
            if (fieldOption != null)
            {
                _context.FieldOptions.Remove(fieldOption);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FieldOptionExists(int id)
        {
          return _context.FieldOptions.Any(e => e.FieldoptionId == id);
        }
    }
}
