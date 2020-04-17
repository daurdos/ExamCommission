using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Phd.Models
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }


        [Display(Name = "Диссовет")]
        public int DisCouncilId { get; set; } // many Users - one Dissertation Council
        public DisCouncil DisCouncil { get; set; } // many Users - one Dissertation Council
        public int CertificationCommissionId { get; set; } // many Users - one CertificationCommission
        public CertificationCommission CertificationCommission { get; set; } // many Users - one CertificationCommission
        // public int BRExamCommissionId { get; set; } // many Users - one BRExamCommission // модернизации логики, чтобы была связь с кафедрами
        // public BRExamCommission BRExamCommission { get; set; } // many Users - one BRExamCommission // модернизации логики, чтобы была связь с кафедрами
        public int AcademicDepartmentId { get; set; } // модернизации логики, чтобы была связь с кафедрами
        public AcademicDepartment AcademicDepartment { get; set; }








        public int BMajorId { get; set; }
        public int BRExamCommissionId { get; set; }
        public int FacultyId { get; set; }












    }
}