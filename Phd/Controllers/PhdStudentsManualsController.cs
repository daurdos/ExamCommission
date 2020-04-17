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
    public class PhdStudentsManualsController : Controller
    {
        private readonly PhdContext _context;

        public PhdStudentsManualsController(PhdContext context)
        {
            _context = context;
        }

        // GET: PhdStudentsManuals
        public async Task<IActionResult> Index()
        {
            var phdContext = _context.PhdStudentManual.Include(p => p.DisCouncil).Include(p => p.Major).Include(p => p.Rector).Include(p => p.TrainingDirection);
            return View(await phdContext.ToListAsync());
        }

        // GET: PhdStudentsManuals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phdStudentManual = await _context.PhdStudentManual
                .Include(p => p.DisCouncil)
                .Include(p => p.Major)
                .Include(p => p.Rector)
                .Include(p => p.TrainingDirection)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phdStudentManual == null)
            {
                return NotFound();
            }

            return View(phdStudentManual);
        }

        // GET: PhdStudentsManuals/Create
        public IActionResult Create()
        {
            ViewData["DisCouncilId"] = new SelectList(_context.DisCouncil, "Id", "CouncilChairman");
            ViewData["MajorId"] = new SelectList(_context.Major, "Id", "Id");
            ViewData["RectorId"] = new SelectList(_context.Set<Rector>(), "Id", "Id");
            ViewData["TrainingDirectionId"] = new SelectList(_context.TrainingDirection, "Id", "Id");
            return View();
        }

        // POST: PhdStudentsManuals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstName,MiddleName,LastNameKaz,FirstNameKaz,MiddleNameKaz,LastNameEng,FirstNameEng,MiddleNameEng,RectorId,ThesisNameRus,ThesisNameKaz,ThesisNameEng,ThesisComDate,ComMemberNumberTotal,ComMemberNumberSpecific,MajorId,TrainingDirectionId,DisCouncilId")] PhdStudentManual phdStudentManual)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phdStudentManual);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisCouncilId"] = new SelectList(_context.DisCouncil, "Id", "CouncilChairman", phdStudentManual.DisCouncilId);
            ViewData["MajorId"] = new SelectList(_context.Major, "Id", "Id", phdStudentManual.MajorId);
            ViewData["RectorId"] = new SelectList(_context.Set<Rector>(), "Id", "Id", phdStudentManual.RectorId);
            ViewData["TrainingDirectionId"] = new SelectList(_context.TrainingDirection, "Id", "Id", phdStudentManual.TrainingDirectionId);
            return View(phdStudentManual);
        }

        // GET: PhdStudentsManuals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phdStudentManual = await _context.PhdStudentManual.FindAsync(id);
            if (phdStudentManual == null)
            {
                return NotFound();
            }
            ViewData["DisCouncilId"] = new SelectList(_context.DisCouncil, "Id", "CouncilChairman", phdStudentManual.DisCouncilId);
            ViewData["MajorId"] = new SelectList(_context.Major, "Id", "Id", phdStudentManual.MajorId);
            ViewData["RectorId"] = new SelectList(_context.Set<Rector>(), "Id", "Id", phdStudentManual.RectorId);
            ViewData["TrainingDirectionId"] = new SelectList(_context.TrainingDirection, "Id", "Id", phdStudentManual.TrainingDirectionId);
            return View(phdStudentManual);
        }

        // POST: PhdStudentsManuals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName,MiddleName,LastNameKaz,FirstNameKaz,MiddleNameKaz,LastNameEng,FirstNameEng,MiddleNameEng,RectorId,ThesisNameRus,ThesisNameKaz,ThesisNameEng,ThesisComDate,ComMemberNumberTotal,ComMemberNumberSpecific,MajorId,TrainingDirectionId,DisCouncilId")] PhdStudentManual phdStudentManual)
        {
            if (id != phdStudentManual.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phdStudentManual);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhdStudentManualExists(phdStudentManual.Id))
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
            ViewData["DisCouncilId"] = new SelectList(_context.DisCouncil, "Id", "CouncilChairman", phdStudentManual.DisCouncilId);
            ViewData["MajorId"] = new SelectList(_context.Major, "Id", "Id", phdStudentManual.MajorId);
            ViewData["RectorId"] = new SelectList(_context.Set<Rector>(), "Id", "Id", phdStudentManual.RectorId);
            ViewData["TrainingDirectionId"] = new SelectList(_context.TrainingDirection, "Id", "Id", phdStudentManual.TrainingDirectionId);
            return View(phdStudentManual);
        }

        // GET: PhdStudentsManuals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phdStudentManual = await _context.PhdStudentManual
                .Include(p => p.DisCouncil)
                .Include(p => p.Major)
                .Include(p => p.Rector)
                .Include(p => p.TrainingDirection)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phdStudentManual == null)
            {
                return NotFound();
            }

            return View(phdStudentManual);
        }

        // POST: PhdStudentsManuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phdStudentManual = await _context.PhdStudentManual.FindAsync(id);
            _context.PhdStudentManual.Remove(phdStudentManual);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhdStudentManualExists(int id)
        {
            return _context.PhdStudentManual.Any(e => e.Id == id);
        }
    }
}
