using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Phd.Models;

namespace Phd.Controllers
{
     
    public class StudentsController : BaseController
    {
        public StudentsController(UserManager<User> userManager, SignInManager<User> signInManager, PhdContext context) : base(userManager, signInManager, context)
        {
        }

        [Authorize(Roles = "moderator, user, admin, Ученый секретарь, Член диссовета")]
        // GET: Students
        public async Task<IActionResult> Index()
        {
            
            var phdContext = Context.Student.Include(s => s.CertificationCommission).Include(s => s.Faculty);
            ViewBag.UserId = UserManager.GetUserId(HttpContext.User);

            if (IsAdmin())
            {
                return View(await phdContext.ToListAsync());
            }
            else
            {

                return View(await phdContext.Where(x => x.CertificationCommissionId == GetUser().CertificationCommissionId).ToListAsync());
            }
          
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await Context.Student
                .Include(s => s.CertificationCommission)
                .Include(s => s.Faculty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            List<Faculty> facultyList = new List<Faculty>();
            facultyList = (from faculty in Context.Faculty
                            select faculty).ToList();
            facultyList.Insert(0, new Faculty { Id = 0, Name = "Выбрать" });
            ViewBag.ListOfFaculty = facultyList;

            List<CertificationCommission> certificationCommissionList = new List<CertificationCommission>();
            certificationCommissionList = (from cert in Context.CertificationCommission
                                           select cert).ToList();
            certificationCommissionList.Insert(0, new CertificationCommission { Id = 0, Name = "Выбрать" });
            ViewBag.ListOfСertificationCommission = certificationCommissionList;







            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FName,MName,LName,FacultyId,CertificationCommissionId")] Student student)
        {
            if (ModelState.IsValid)
            {
                Context.Add(student);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CertificationCommissionId"] = new SelectList(Context.Set<CertificationCommission>(), "Id", "Id", student.CertificationCommissionId);
            ViewData["FacultyId"] = new SelectList(Context.Set<Faculty>(), "Id", "Id", student.FacultyId);
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await Context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["CertificationCommissionId"] = new SelectList(Context.Set<CertificationCommission>(), "Id", "Id", student.CertificationCommissionId);
            ViewData["FacultyId"] = new SelectList(Context.Set<Faculty>(), "Id", "Id", student.FacultyId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FName,MName,LName,FacultyId,CertificationCommissionId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(student);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewData["CertificationCommissionId"] = new SelectList(Context.Set<CertificationCommission>(), "Id", "Id", student.CertificationCommissionId);
            ViewData["FacultyId"] = new SelectList(Context.Set<Faculty>(), "Id", "Id", student.FacultyId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await Context.Student
                .Include(s => s.CertificationCommission)
                .Include(s => s.Faculty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await Context.Student.FindAsync(id);
            Context.Student.Remove(student);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return Context.Student.Any(e => e.Id == id);
        }






        public IActionResult CreateGrade(int studentId, string userId )
        {
            var grades = Context.Grade.ToList();
            var condition = grades != null && grades.Any(x => x.UserId == userId && x.StudentId == studentId);
            if (!condition)
            {
                ViewBag.StudentId = studentId;
                ViewBag.UserId = UserManager.GetUserId(HttpContext.User);
            }

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGrade([Bind("Value,StudentId,UserId")] Grade grade)
        {

            
            if (ModelState.IsValid)
            {

                Context.Update(grade);
                await Context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            return View(grade);








        }












    }
}
