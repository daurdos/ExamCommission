using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Phd.Models;

namespace Phd.Models
{
    public class PhdContext : IdentityDbContext<User>
    {
        public PhdContext(DbContextOptions<PhdContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Phd.Models.PhdStudent> PhdStudent { get; set; }
        public DbSet<Phd.Models.Vote> Vote { get; set; }

        public DbSet<Phd.Models.Major> Major { get; set; }
        public DbSet<Phd.Models.TrainingDirection> TrainingDirection {get; set; }
        public DbSet<Phd.Models.DisCouncil> DisCouncil { get; set; }
        public DbSet<Phd.Models.Student> Student { get; set; }
        public DbSet<Phd.Models.Faculty> Faculty { get; set; }
        public DbSet<Phd.Models.Grade> Grade { get; set; }
        public DbSet<Phd.Models.PhdStudentManual> PhdStudentManual { get; set; }
        public DbSet<Phd.Models.DiplomaFormOne> DiplomaFormOne { get; set; }
        public DbSet<Phd.Models.Rector> Rector { get; set; }
        public DbSet<Phd.Models.DisCouncilChairman> DisCouncilChairman { get; set; }
        public DbSet<Phd.Models.CertificationCommission> CertificationCommission { get; set; }
        public DbSet<Phd.Models.AcademicDepartment> AcademicDepartment { get; set; }
        public DbSet<Phd.Models.BDirection> BDirection { get; set; }
        public DbSet<Phd.Models.BMajor> BMajor { get; set; }
        public DbSet<Phd.Models.BRExamCommission> BRExamCommission { get; set; }
        public DbSet<Phd.Models.BRStudentGroup> BRStudentGroup { get; set; }
        public DbSet<Phd.Models.BRStudent> BRStudent { get; set; }
        public DbSet<Phd.Models.BRStudentGrade> BRStudentGrade { get; set; }
        public DbSet<Phd.Models.BRStudentDoc> BRStudentDoc { get; set; }
        public DbSet<Phd.Models.StudentDocType> StudentDocType { get; set; }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        */
    }
}
