using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GroupWebProject.Data;
using GroupWebProject.Models;

namespace GroupWebProject.Controllers
{
    public class AdminDashesController : Controller
    {
        private readonly GroupContext _context;

        public AdminDashesController(GroupContext context)
        {
            _context = context;
        }

        // GET: AdminDashes
        public async Task<IActionResult> Index()
        {
              return View(await _context.AdminDash.ToListAsync());
        }

        // GET: AdminDashes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AdminDash == null)
            {
                return NotFound();
            }

            var adminDash = await _context.AdminDash
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminDash == null)
            {
                return NotFound();
            }

            return View(adminDash);
        }

        // GET: AdminDashes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminDashes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] AdminDash adminDash)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adminDash);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adminDash);
        }

        // GET: AdminDashes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AdminDash == null)
            {
                return NotFound();
            }

            var adminDash = await _context.AdminDash.FindAsync(id);
            if (adminDash == null)
            {
                return NotFound();
            }
            return View(adminDash);
        }

        // POST: AdminDashes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] AdminDash adminDash)
        {
            if (id != adminDash.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(adminDash);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminDashExists(adminDash.Id))
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
            return View(adminDash);
        }

        // GET: AdminDashes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AdminDash == null)
            {
                return NotFound();
            }

            var adminDash = await _context.AdminDash
                .FirstOrDefaultAsync(m => m.Id == id);
            if (adminDash == null)
            {
                return NotFound();
            }

            return View(adminDash);
        }

        // POST: AdminDashes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AdminDash == null)
            {
                return Problem("Entity set 'GroupContext.AdminDash'  is null.");
            }
            var adminDash = await _context.AdminDash.FindAsync(id);
            if (adminDash != null)
            {
                _context.AdminDash.Remove(adminDash);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminDashExists(int id)
        {
          return _context.AdminDash.Any(e => e.Id == id);
        }
    }
}
