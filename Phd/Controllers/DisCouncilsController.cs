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
    public class DisCouncilsController : Controller
    {
        private readonly PhdContext _context;

        public DisCouncilsController(PhdContext context)
        {
            _context = context;
        }

        // GET: DisCouncils
        public async Task<IActionResult> Index()
        {
            return View(await _context.DisCouncil.ToListAsync());
        }

        // GET: DisCouncils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disCouncil = await _context.DisCouncil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disCouncil == null)
            {
                return NotFound();
            }

            return View(disCouncil);
        }

        // GET: DisCouncils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DisCouncils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderNumber,CouncilChairman,CouncilSecretary,CouncilMember,DefenceDate")] DisCouncil disCouncil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(disCouncil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disCouncil);
        }

        // GET: DisCouncils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disCouncil = await _context.DisCouncil.FindAsync(id);
            if (disCouncil == null)
            {
                return NotFound();
            }
            return View(disCouncil);
        }

        // POST: DisCouncils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderNumber,CouncilChairman,CouncilSecretary,CouncilMember,DefenceDate")] DisCouncil disCouncil)
        {
            if (id != disCouncil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disCouncil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisCouncilExists(disCouncil.Id))
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
            return View(disCouncil);
        }

        // GET: DisCouncils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disCouncil = await _context.DisCouncil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disCouncil == null)
            {
                return NotFound();
            }

            return View(disCouncil);
        }

        // POST: DisCouncils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disCouncil = await _context.DisCouncil.FindAsync(id);
            _context.DisCouncil.Remove(disCouncil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisCouncilExists(int id)
        {
            return _context.DisCouncil.Any(e => e.Id == id);
        }
    }
}
