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
    public class DisCouncilChairmenController : Controller
    {
        private readonly PhdContext _context;

        public DisCouncilChairmenController(PhdContext context)
        {
            _context = context;
        }

        // GET: DisCouncilChairmen
        public async Task<IActionResult> Index()
        {
            var phdContext = _context.DisCouncilChairman.Include(d => d.DisCouncil);
            return View(await phdContext.ToListAsync());
        }

        // GET: DisCouncilChairmen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disCouncilChairman = await _context.DisCouncilChairman
                .Include(d => d.DisCouncil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disCouncilChairman == null)
            {
                return NotFound();
            }

            return View(disCouncilChairman);
        }

        // GET: DisCouncilChairmen/Create
        public IActionResult Create()
        {
            ViewData["DisCouncilId"] = new SelectList(_context.DisCouncil, "Id", "CouncilChairman");
            return View();
        }

        // POST: DisCouncilChairmen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FullName,FullNameKaz,FullNameEng,DisCouncilId")] DisCouncilChairman disCouncilChairman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disCouncilChairman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisCouncilId"] = new SelectList(_context.DisCouncil, "Id", "CouncilChairman", disCouncilChairman.DisCouncilId);
            return View(disCouncilChairman);
        }

        // GET: DisCouncilChairmen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disCouncilChairman = await _context.DisCouncilChairman.FindAsync(id);
            if (disCouncilChairman == null)
            {
                return NotFound();
            }
            ViewData["DisCouncilId"] = new SelectList(_context.DisCouncil, "Id", "CouncilChairman", disCouncilChairman.DisCouncilId);
            return View(disCouncilChairman);
        }

        // POST: DisCouncilChairmen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,FullNameKaz,FullNameEng,DisCouncilId")] DisCouncilChairman disCouncilChairman)
        {
            if (id != disCouncilChairman.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disCouncilChairman);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisCouncilChairmanExists(disCouncilChairman.Id))
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
            ViewData["DisCouncilId"] = new SelectList(_context.DisCouncil, "Id", "CouncilChairman", disCouncilChairman.DisCouncilId);
            return View(disCouncilChairman);
        }

        // GET: DisCouncilChairmen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disCouncilChairman = await _context.DisCouncilChairman
                .Include(d => d.DisCouncil)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disCouncilChairman == null)
            {
                return NotFound();
            }

            return View(disCouncilChairman);
        }

        // POST: DisCouncilChairmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disCouncilChairman = await _context.DisCouncilChairman.FindAsync(id);
            _context.DisCouncilChairman.Remove(disCouncilChairman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisCouncilChairmanExists(int id)
        {
            return _context.DisCouncilChairman.Any(e => e.Id == id);
        }
    }
}
