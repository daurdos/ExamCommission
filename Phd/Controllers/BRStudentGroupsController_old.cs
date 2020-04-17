using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Phd.Models;

namespace Phd.Controllers
{
    public class BRStudentGroupsController_old : BaseController
    {
        public BRStudentGroupsController_old(UserManager<User> userManager, SignInManager<User> signInManager, PhdContext context) : base(userManager, signInManager, context)
        {
        }

        // GET: BRStudentGroups
        public async Task<IActionResult> Index()
        {
            //var navigationBRStudentGroups = Context.BRStudentGroup.Include(b => b.BRExamCommission).Include(b=>b.BRStudent).Include(b=>b.BRExamCommission);
            //ViewBag.UserId = UserManager.GetUserId(HttpContext.User);
            //if (IsAdmin())
            //{
            //    return View(await navigationBRStudentGroups.ToListAsync());
            //}
            //else
            //{

            //    return View(await navigationBRStudentGroups.Where(x => x.BRExamCommissionId == GetUser().BRExamCommissionId).ToListAsync());
            //}
            return View();
        }

        // GET: BRStudentGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudentGroup = await Context.BRStudentGroup
                .Include(b => b.BRExamCommission)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bRStudentGroup == null)
            {
                return NotFound();
            }

            return View(bRStudentGroup);
        }

        // GET: BRStudentGroups/Create
        public IActionResult Create()
        {
            ViewData["BRExamCommissionId"] = new SelectList(Context.BRExamCommission, "Id", "Id");
            return View();
        }

        // POST: BRStudentGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BRExamCommissionId")] BRStudentGroup bRStudentGroup)
        {
            if (ModelState.IsValid)
            {
                Context.Add(bRStudentGroup);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRExamCommissionId"] = new SelectList(Context.BRExamCommission, "Id", "Id", bRStudentGroup.BRExamCommissionId);
            return View(bRStudentGroup);
        }

        // GET: BRStudentGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudentGroup = await Context.BRStudentGroup.FindAsync(id);
            if (bRStudentGroup == null)
            {
                return NotFound();
            }
            ViewData["BRExamCommissionId"] = new SelectList(Context.BRExamCommission, "Id", "Id", bRStudentGroup.BRExamCommissionId);
            return View(bRStudentGroup);
        }

        // POST: BRStudentGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BRExamCommissionId")] BRStudentGroup bRStudentGroup)
        {
            if (id != bRStudentGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(bRStudentGroup);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BRStudentGroupExists(bRStudentGroup.Id))
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
            ViewData["BRExamCommissionId"] = new SelectList(Context.BRExamCommission, "Id", "Id", bRStudentGroup.BRExamCommissionId);
            return View(bRStudentGroup);
        }

        // GET: BRStudentGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bRStudentGroup = await Context.BRStudentGroup
                .Include(b => b.BRExamCommission)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bRStudentGroup == null)
            {
                return NotFound();
            }

            return View(bRStudentGroup);
        }





        public IActionResult CreateStudent(int id)
        {
            ViewBag.Id = id;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStudent([Bind("Name,BRStudentGroupId")] BRStudent bRStudent)
        {
            if (ModelState.IsValid)
            {
                Context.Add(bRStudent);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bRStudent);
        }


        public IActionResult GetStudents(int? id)
        {

            var allStudents = Context.BRStudent.ToList();
            var studentsByGroup = (from student in allStudents
                          where student.BRStudentGroupId == id
                          select student).ToList();
            return View(studentsByGroup);
        }












        // POST: BRStudentGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bRStudentGroup = await Context.BRStudentGroup.FindAsync(id);
            Context.BRStudentGroup.Remove(bRStudentGroup);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BRStudentGroupExists(int id)
        {
            return Context.BRStudentGroup.Any(e => e.Id == id);
        }
    }
}
