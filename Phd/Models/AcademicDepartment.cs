using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class AcademicDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public ICollection<BMajor> BMajor { get; set; }
        public ICollection<BDirection> BDirection { get; set; }
        public ICollection<User> User { get; set; }
    }
}
