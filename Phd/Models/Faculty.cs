using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AcademicDepartment> AcademicDepartment { get; set; }
    }
}
