using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Phd.Models;

namespace Phd.Controllers
{
    public class RectorsController : Controller
    {
        private readonly PhdContext _context;

        public RectorsController(PhdContext context)
        {
            _context = context;
        }

        // GET: Rectors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rector.ToListAsync());
        }

        // GET: Rectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rector = await _context.Rector
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rector == null)
            {
                return NotFound();
            }

            return View(rector);
        }

        // GET: Rectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rectors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,FullNameKaz,FullNameEng")] Rector rector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rector);
        }

        // GET: Rectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rector = await _context.Rector.FindAsync(id);
            if (rector == null)
            {
                return NotFound();
            }
            return View(rector);
        }

        // POST: Rectors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,FullNameKaz,FullNameEng")] Rector rector)
        {
            if (id != rector.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RectorExists(rector.Id))
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
            return View(rector);
        }

        // GET: Rectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rector = await _context.Rector
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rector == null)
            {
                return NotFound();
            }

            return View(rector);
        }

        // POST: Rectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rector = await _context.Rector.FindAsync(id);
            _context.Rector.Remove(rector);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RectorExists(int id)
        {
            return _context.Rector.Any(e => e.Id == id);
        }
    }
}
