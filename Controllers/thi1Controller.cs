using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using demothi.Data;
using demothi.Models;

namespace demothi.Controllers
{
    public class thi1Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public thi1Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: thi1
        public async Task<IActionResult> Index()
        {
            return View(await _context.thi1.ToListAsync());
        }

        // GET: thi1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thi1 = await _context.thi1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thi1 == null)
            {
                return NotFound();
            }

            return View(thi1);
        }

        // GET: thi1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: thi1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age")] thi1 thi1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thi1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thi1);
        }

        // GET: thi1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thi1 = await _context.thi1.FindAsync(id);
            if (thi1 == null)
            {
                return NotFound();
            }
            return View(thi1);
        }

        // POST: thi1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age")] thi1 thi1)
        {
            if (id != thi1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thi1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!thi1Exists(thi1.Id))
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
            return View(thi1);
        }

        // GET: thi1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thi1 = await _context.thi1
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thi1 == null)
            {
                return NotFound();
            }

            return View(thi1);
        }

        // POST: thi1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thi1 = await _context.thi1.FindAsync(id);
            if (thi1 != null)
            {
                _context.thi1.Remove(thi1);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool thi1Exists(int id)
        {
            return _context.thi1.Any(e => e.Id == id);
        }
    }
}
