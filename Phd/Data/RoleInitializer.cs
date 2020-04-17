using Microsoft.AspNetCore.Identity;
using Phd.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Data
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, PhdContext context)
        {
            
            /*
            string adminEmail = "daurdos@gmail.com";
            string password = "!QAZ1qaz";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            */
            
            /*
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            */
           
            if (!context.DisCouncil.Any())
            {
                context.DisCouncil.Add(new DisCouncil { OrderNumber = "000", CouncilChairman = "CouncilChairman", CouncilSecretary = "CouncilSecretary", CouncilMember = "CouncilMember", DefenceDate = DateTime.Now });
                context.SaveChanges();
            }

            // УСТАРЕВШЕЕ (не удаляю для теста, как конктрукция ниже заработает удалить) добавляю инициализацию госаттестационной комисии
            if (!context.CertificationCommission.Any())
            {
                context.CertificationCommission.Add(new CertificationCommission { Name = "CertificationCommission" });
                context.SaveChanges();
            }

            // добавляю инициализацию кафедр
            if (!context.Faculty.Any())
            {
                context.Faculty.Add(new Faculty { Name = "Initial Faculty" });
                context.SaveChanges();
            }

            // добавляю инициализацию кафедр
            if (!context.AcademicDepartment.Any())
            {
                context.AcademicDepartment.Add(new AcademicDepartment { Name = "Initial AcademicDepartment", FacultyId = 1 });
                context.SaveChanges();
            }

            //// добавляю инициализацию специальностей бакалавра
            if (!context.BMajor.Any())
            {
                context.BMajor.Add(new BMajor { Cypher = "BMajor Initial Cypher", NameRus = "BMajor Initial NameRus", NameKaz = "BMajor Initial NameKaz", NameEng = "BMajor Initial NameEng", AcademicDepartmentId = 1 });
                context.SaveChanges();
            }

            // добавляю инициализацию госаттестационной комисии
            if (!context.BRExamCommission.Any())
            {
                context.BRExamCommission.Add(new BRExamCommission { Name = "Initial BRExamCommission", BMajorId = 1 });
                context.SaveChanges();
            }
            ///




            /*
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail, DisCouncilId = 1, CertificationCommissionId = 1, AcademicDepartmentId = 1 };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
            */
            
        }



    }
}
