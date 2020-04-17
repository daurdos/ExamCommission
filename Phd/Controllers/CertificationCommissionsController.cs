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
    public class CertificationCommissionsController : Controller
    {
        private readonly PhdContext _context;

        public CertificationCommissionsController(PhdContext context)
        {
            _context = context;
        }

        // GET: CertificationCommissions
        public async Task<IActionResult> Index()
        {
            return View(await _context.CertificationCommission.ToListAsync());
        }

        // GET: CertificationCommissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificationCommission = await _context.CertificationCommission
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificationCommission == null)
            {
                return NotFound();
            }

            return View(certificationCommission);
        }

        // GET: CertificationCommissions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CertificationCommissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CertificationCommission certificationCommission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certificationCommission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(certificationCommission);
        }

        // GET: CertificationCommissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificationCommission = await _context.CertificationCommission.FindAsync(id);
            if (certificationCommission == null)
            {
                return NotFound();
            }
            return View(certificationCommission);
        }

        // POST: CertificationCommissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CertificationCommission certificationCommission)
        {
            if (id != certificationCommission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificationCommission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificationCommissionExists(certificationCommission.Id))
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
            return View(certificationCommission);
        }

        // GET: CertificationCommissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificationCommission = await _context.CertificationCommission
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certificationCommission == null)
            {
                return NotFound();
            }

            return View(certificationCommission);
        }

        // POST: CertificationCommissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certificationCommission = await _context.CertificationCommission.FindAsync(id);
            _context.CertificationCommission.Remove(certificationCommission);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificationCommissionExists(int id)
        {
            return _context.CertificationCommission.Any(e => e.Id == id);
        }
    }
}
