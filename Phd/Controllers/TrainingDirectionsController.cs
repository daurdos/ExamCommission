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
    public class TrainingDirectionsController : Controller
    {
        private readonly PhdContext _context;

        public TrainingDirectionsController(PhdContext context)
        {
            _context = context;
        }

        // GET: TrainingDirections
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrainingDirection.ToListAsync());
        }

        // GET: TrainingDirections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDirection = await _context.TrainingDirection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingDirection == null)
            {
                return NotFound();
            }

            return View(trainingDirection);
        }

        // GET: TrainingDirections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrainingDirections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TrainingDirectionCypher,TrainingDirectionCypherName,TrainingDirectionCypherNameKaz,TrainingDirectionCypherNameEng")] TrainingDirection trainingDirection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainingDirection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trainingDirection);
        }

        // GET: TrainingDirections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDirection = await _context.TrainingDirection.FindAsync(id);
            if (trainingDirection == null)
            {
                return NotFound();
            }
            return View(trainingDirection);
        }

        // POST: TrainingDirections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TrainingDirectionCypher,TrainingDirectionCypherName,TrainingDirectionCypherNameKaz,TrainingDirectionCypherNameEng")] TrainingDirection trainingDirection)
        {
            if (id != trainingDirection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainingDirection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingDirectionExists(trainingDirection.Id))
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
            return View(trainingDirection);
        }

        // GET: TrainingDirections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trainingDirection = await _context.TrainingDirection
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trainingDirection == null)
            {
                return NotFound();
            }

            return View(trainingDirection);
        }

        // POST: TrainingDirections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trainingDirection = await _context.TrainingDirection.FindAsync(id);
            _context.TrainingDirection.Remove(trainingDirection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingDirectionExists(int id)
        {
            return _context.TrainingDirection.Any(e => e.Id == id);
        }
    }
}
