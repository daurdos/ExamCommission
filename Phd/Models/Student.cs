using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }

        /// <summary>
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        /// </summary>

        /// <summary>
        public ICollection<Grade> Grades { get; set; } // здесь связь с оценками
        /// </summary>


        public int CertificationCommissionId { get; set; }
        public CertificationCommission CertificationCommission { get; set; }




    }
}
