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
    public class DiplomaFormOnesController : Controller
    {
        private readonly PhdContext _context;

        public DiplomaFormOnesController(PhdContext context)
        {
            _context = context;
        }

        // GET: DiplomaFormOnes
        public async Task<IActionResult> Index()
        {
            var phdContext = _context.DiplomaFormOne.Include(d => d.PhdStudent).Include(d => d.PhdStudentManual);
            return View(await phdContext.ToListAsync());
        }

        // GET: DiplomaFormOnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diplomaFormOne = await _context.DiplomaFormOne
                .Include(d => d.PhdStudent)
                .Include(d => d.PhdStudentManual)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diplomaFormOne == null)
            {
                return NotFound();
            }

            return View(diplomaFormOne);
        }

        // GET: DiplomaFormOnes/Create
        public IActionResult Create()
        {
            ViewData["PhdStudentId"] = new SelectList(_context.PhdStudent, "Id", "FirstName");
            ViewData["PhdStudentManualId"] = new SelectList(_context.PhdStudentManual, "Id", "FirstName");
            return View();
        }

        // POST: DiplomaFormOnes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Damaged,Lost,PhdStudentId,PhdStudentManualId")] DiplomaFormOne diplomaFormOne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(diplomaFormOne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhdStudentId"] = new SelectList(_context.PhdStudent, "Id", "FirstName", diplomaFormOne.PhdStudentId);
            ViewData["PhdStudentManualId"] = new SelectList(_context.PhdStudentManual, "Id", "FirstName", diplomaFormOne.PhdStudentManualId);
            return View(diplomaFormOne);
        }

        // GET: DiplomaFormOnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diplomaFormOne = await _context.DiplomaFormOne.FindAsync(id);
            if (diplomaFormOne == null)
            {
                return NotFound();
            }
            ViewData["PhdStudentId"] = new SelectList(_context.PhdStudent, "Id", "FirstName", diplomaFormOne.PhdStudentId);
            ViewData["PhdStudentManualId"] = new SelectList(_context.PhdStudentManual, "Id", "FirstName", diplomaFormOne.PhdStudentManualId);
            return View(diplomaFormOne);
        }

        // POST: DiplomaFormOnes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Damaged,Lost,PhdStudentId,PhdStudentManualId")] DiplomaFormOne diplomaFormOne)
        {
            if (id != diplomaFormOne.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(diplomaFormOne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiplomaFormOneExists(diplomaFormOne.Id))
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
            ViewData["PhdStudentId"] = new SelectList(_context.PhdStudent, "Id", "FirstName", diplomaFormOne.PhdStudentId);
            ViewData["PhdStudentManualId"] = new SelectList(_context.PhdStudentManual, "Id", "FirstName", diplomaFormOne.PhdStudentManualId);
            return View(diplomaFormOne);
        }

        // GET: DiplomaFormOnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var diplomaFormOne = await _context.DiplomaFormOne
                .Include(d => d.PhdStudent)
                .Include(d => d.PhdStudentManual)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (diplomaFormOne == null)
            {
                return NotFound();
            }

            return View(diplomaFormOne);
        }

        // POST: DiplomaFormOnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var diplomaFormOne = await _context.DiplomaFormOne.FindAsync(id);
            _context.DiplomaFormOne.Remove(diplomaFormOne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiplomaFormOneExists(int id)
        {
            return _context.DiplomaFormOne.Any(e => e.Id == id);
        }
    }
}
