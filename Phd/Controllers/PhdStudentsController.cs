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

    public class PhdStudentsController : BaseController
    {
        public PhdStudentsController(UserManager<User> userManager, SignInManager<User> signInManager, PhdContext context) : base(userManager, signInManager, context)
        {
        }

        [Authorize(Roles = "moderator, user, admin, Ученый секретарь, Член диссовета")]
        // GET: PhdStudents

        public async Task<IActionResult> Index(string majorCode,  string searchString)
        {

            /*
            if (IsAdmin())
            {
                return View(await Context.PhdStudent.Include(p => p.Major).Include(p => p.TrainingDirection).ToListAsync());
            }
            else
            {

                return View(await Context.PhdStudent.Where(x => x.Dis
                Id == GetUser().DisCouncilId).Include(p => p.Major).Include(p => p.TrainingDirection).ToListAsync());
            }
            */

            var students = Context.PhdStudent.Include(p => p.Major).Include(p => p.TrainingDirection).AsEnumerable();


            /*
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper()));
            }
            */


            if (!String.IsNullOrEmpty(searchString))
            {
                students = from s in students
                           where s.LastName.ToUpper().Contains(searchString.ToUpper())
                           //orderby s  // если с этой строкой,
                                        // то выдает ошибку
                                        // ArgumentException: At least one object must implement IComparable.
                           select s;
            }
            

            else if (!String.IsNullOrEmpty(majorCode))
            {
                students = students.Where(s => s.Major.MajorCypher == majorCode);
            }


            if (IsAdmin())
            {
                return View(students.ToList());
            }
            else
            {

                return View(students.Where(x => x.DisCouncilId == GetUser().DisCouncilId).ToList());
            }




            //var phdStudents = await _context.PhdStudent.Include(p => p.Major).ToListAsync();


            /*
            IQueryable<string> codeQuery = from m in _context.PhdStudent
                                           orderby m.MajorCode
                                           select m.MajorCode;

            // запрос на поиск по строке
                var phdStudents = from m in _context.PhdStudent
                         select m;



            ///////////////////

            if (!string.IsNullOrEmpty(majorCode))
            {
                phdStudents = phdStudents.Where(x => x.MajorCode == majorCode);
            }

            var majorCodeVM = new MajorCodeViewModel
            {
                Cyphers = new SelectList(await codeQuery.Distinct().ToListAsync()),
                PhdStudents = await phdStudents.ToListAsync()
            };

            return View(majorCodeVM);
            */

        }



        [Authorize(Roles = "moderator, user, admin, Ученый секретарь, Член диссовета")]
        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }





        [Authorize(Roles = "moderator, user, admin, Ученый секретарь, Член диссовета")]
        // GET: PhdStudents/Details/5
        public async Task<IActionResult> Details(int id)
        {   /*
            if (id == null)
            {
                return NotFound();
            }
            */
            var phdStudent = await Context.PhdStudent.Include(p => p.Vote).Include(p => p.Major).Include(p => p.TrainingDirection).FirstOrDefaultAsync(p => p.Id == id);
            //var phdStudent = await _context.PhdStudent.FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.Id = id;

            if (phdStudent == null)
            {
                return NotFound();
            }

            //return View(phdStudent);


            return View(new StudentReportViewModel
            {

                PhdId = phdStudent.Id,
                FName = phdStudent.FirstName,
                LName = phdStudent.LastName,
                MName = phdStudent.MiddleName,
                PositiveVoteQuantity = phdStudent.Vote.Where(xx => xx.Voice == "1").Count(),
                NegativeVoteQuantity = phdStudent.Vote.Where(xx => xx.Voice == "0").Count(),
                OverallVoteQuantity = phdStudent.Vote.Where(xx => xx.PhdStudentId == id).Count(),
                MajName = phdStudent.Major.MajorCypherName,
                MajCode = phdStudent.Major.MajorCypher,
                TrainingDirectionCypher = phdStudent.TrainingDirection.TrainingDirectionCypher,
                TrainingDirectionCypherName = phdStudent.TrainingDirection.TrainingDirectionCypherName,
                DisNameRus = phdStudent.ThesisNameRus,
                ReleaseDate = phdStudent.ThesisComDate,
                MemberNumberTotal = phdStudent.ComMemberNumberTotal,
                MemberNumberSpecific = phdStudent.ComMemberNumberSpecific
             
            });
        }

        [Authorize(Roles = "moderator, admin, Ученый секретарь")]
        // GET: PhdStudents/Create
        public async Task<IActionResult> Create()
        {
            List<Major> majorList = new List<Major>();
            List<TrainingDirection> trainingDirectionList = new List<TrainingDirection>();

            majorList = (from major in Context.Major
                            select major).ToList();

            majorList.Insert(0, new Major { Id = 0, MajorCypher = "Выбрать" });

            ViewBag.ListOfMajor = majorList;

            trainingDirectionList = (from trainingDirection in Context.TrainingDirection
                                     select trainingDirection).ToList();

            trainingDirectionList.Insert(0, new TrainingDirection { Id = 0, TrainingDirectionCypher = "Выбрать" });

            ViewBag.ListOfTrainingDirection = trainingDirectionList;

            return View();



            /*
            IQueryable<string> codeQuery = from m in _context.PhdStudent
                                           orderby m.MajorCode
                                           select m.MajorCode;

            var majorCodeVM = new MajorCodeViewModel
            {
                Codes = new SelectList(await codeQuery.Distinct().ToListAsync()),
            };

            return View(majorCodeVM);
            */
        }

        // POST: PhdStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = "moderator, admin, Ученый секретарь")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstName,MiddleName,MajorCode,MajorName,ThesisNameRus,ThesisComDate,ComMemberNumberTotal,ComMemberNumberSpecific,EducationDirection,MajorId,TrainingDirectionId,DisCouncilId")] PhdStudent phdStudent)
        {
            if (ModelState.IsValid)
            {
                Context.Add(phdStudent);
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phdStudent);
        }











        //////////////////////////////////////////////////////////






        [Authorize(Roles = "moderator, user, Ученый секретарь, Член диссовета")]
        public IActionResult CreateVote(int id)
        {
            ViewBag.Id = id;
            return View();
        }


        [Authorize(Roles = "moderator, user, Ученый секретарь, Член диссовета")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVote([Bind("PhdStudentId,Voice")] Vote vote)
        {
            if (ModelState.IsValid)
            {

                Context.Add(vote);
                await Context.SaveChangesAsync();
                await SingInManager.SignOutAsync(); // пользователь выходит после голосования

                return RedirectToAction(nameof(Index));
            }
            return View();
        }












        /*

        public async Task<IActionResult> Index(string majorCode, string searchString)
        {
            IQueryable<string> codeQuery = from m in _context.PhdStudent
                                           orderby m.MajorCode
                                           select m.MajorCode;

            var phdStudents = from m in _context.PhdStudent
                              select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                phdStudents = phdStudents.Where(s => s.Lname.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(majorCode))
            {
                phdStudents = phdStudents.Where(x => x.MajorCode == majorCode);
            }

            var majorCodeVM = new MajorCodeViewModel
            {
                Codes = new SelectList(await codeQuery.Distinct().ToListAsync()),
                PhdStudents = await phdStudents.ToListAsync()
            };

            return View(majorCodeVM);
        }
        */
        /*
        public IActionResult VoteResult(int id, string lastName, string firstName, string middleName, string majorName, string majorCode, string projectName, int voicesCount, int voicesCountPositive, int voicesCountNegative, int voicesCountAbstain)
        {
            ViewBag.Id = id;
            ViewBag.Lname = lastName;
            ViewBag.Fname = firstName;
            ViewBag.Mname = middleName;
            ViewBag.MajName = majorName;
            ViewBag.MajorCode = majorCode;
            ViewBag.DisNameRus = projectName;


            var result  = from m in _context.PhdStudent
                   where m.Id == id
                   select m;



            return View();
        }

    */
        /*
            public IActionResult VoteResult(int? id)
            {
                ViewBag.Id = id;
                return View();
            }

        *//*
            public IActionResult VoteResult(int id)
            {
                var result = from m in _context.PhdStudent
                             select m;

                    result = result.Where(s => s.Id == id);

                return View(result.ToList());
            }
            */



        /*

    public Task<IAsyncResult> VoteResult(int id)
    {

        // var vote = await _context.Vote
        //         .FirstOrDefaultAsync(m => m.Id == id);


        /*
        var vote = "SELECT COUNT(Voice) FROM Vote where PhdStudentId = '" + id + "'";
        ViewBag.Vote = vote;

        return vote;
        */
        /*
        var result = from r in _context.Vote
                     where r.PhdStudentId = id
                     orderby t

*/
        /*

                var voteResult = await  _context.Vote.
                    FirstOrDefaultAsync(Where(p => p.PhdStudentId == id));

                /*
                var phdStudent = await _context.PhdStudent
                    .FirstOrDefaultAsync(m => m.Id == id);

        */
        //     return View();
        //     }


        //    */





        [Authorize(Roles = "moderator, Ученый секретарь")]
        public IActionResult VoteResult(int? id)
        {
            var resultAll = Context.Vote.Count(p => p.PhdStudentId == id);
            ViewBag.Vote = resultAll;
            return View(resultAll);
        }

        /*
        [HttpGet]
        public async Task<IActionResult> GetReportsAsync(int id)
        {
            var student = await _context.PhdStudent.Include(x => x.Vote).FirstOrDefaultAsync(x => x.Id == id);

            return Ok(new StudentReportViewModel
            {
                FName = student.Fname,
                LName = student.Lname,
                PositiveVoteQuantity = student.Vote.Where(xx => xx.Voice == "1").Count(),
                NegativeVoteQuantity = student.Vote.Where(xx => xx.Voice == "0").Count()
            });
        }
        */



        [Authorize(Roles = "moderator, admin, Ученый секретарь")]
        [HttpGet]
        public async Task<IActionResult> GetReportsAsync(int id)
        {
            //var student = await _context.PhdStudent.Include(x => x.Vote).FirstOrDefaultAsync(x => x.Id == id);
            var student = await Context.PhdStudent.Include(x => x.Vote).Include(p => p.Major).Include(p => p.TrainingDirection).FirstOrDefaultAsync(x => x.Id == id);



            return View(new StudentReportViewModel
            {
                FName = student.FirstName,
                LName = student.LastName,
                MName = student.MiddleName,
                PositiveVoteQuantity = student.Vote.Where(xx => xx.Voice == "1").Count(),
                NegativeVoteQuantity = student.Vote.Where(xx => xx.Voice == "0").Count(),
                OverallVoteQuantity = student.Vote.Where(xx => xx.PhdStudentId == id).Count(),
                MajName = student.Major.MajorCypherName,
                MajCode = student.Major.MajorCypher,
                TrainingDirectionCypher = student.TrainingDirection.TrainingDirectionCypher,
                TrainingDirectionCypherName = student.TrainingDirection.TrainingDirectionCypherName,
                DisNameRus = student.ThesisNameRus,
                ReleaseDate = student.ThesisComDate,
                MemberNumberTotal = student.ComMemberNumberTotal,
                MemberNumberSpecific = student.ComMemberNumberSpecific

            }) ;

        }





        //////////////////////////////////////////////////////////////////////


































        [Authorize(Roles = "moderator, admin, Ученый секретарь")]
        // GET: PhdStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phdStudent = await Context.PhdStudent.FindAsync(id);
            if (phdStudent == null)
            {
                return NotFound();
            }
            return View(phdStudent);
        }


        // POST: PhdStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = "moderator, admin, Ученый секретарь, Член диссовета")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName,MiddleName,MajorCode,MajorName,ThesisNameRus,ThesisComDate,ComMemberNumberTotal,ComMemberNumberSpecific,EducationDirection,MajorId,TrainingDirectionId")] PhdStudent phdStudent)
        {
            if (id != phdStudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Context.Update(phdStudent);
                    await Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhdStudentExists(phdStudent.Id))
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
            return View(phdStudent);
        }

        [Authorize(Roles = "moderator, admin, Ученый секретарь")]
        // GET: PhdStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phdStudent = await Context.PhdStudent
                .FirstOrDefaultAsync(m => m.Id == id);
            if (phdStudent == null)
            {
                return NotFound();
            }

            return View(phdStudent);
        }


        // POST: PhdStudents/Delete/5
        [Authorize(Roles = "moderator, admin, Ученый секретарь")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phdStudent = await Context.PhdStudent.FindAsync(id);
            Context.PhdStudent.Remove(phdStudent);
            await Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhdStudentExists(int id)
        {
            return Context.PhdStudent.Any(e => e.Id == id);
        }





        /////////////////////////////////////////////







        public IActionResult GetQRCode(int? id)
        {
           ViewBag.Url = $"{Request.Scheme}://{Request.Host}/PhdStudents/Details/{id}";

            return View();
        }










    }
}
