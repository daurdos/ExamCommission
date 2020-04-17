using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class Rector
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FullNameKaz { get; set; }
        public string FullNameEng { get; set; }
        public ICollection<PhdStudent> PhdStudent { get; set; }
        public ICollection<PhdStudentManual> PhdStudentManual { get; set; }



    }
}
