using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class BRStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BRStudentGrade> BRStudentGrade { get; set; }
        public ICollection<BRStudentDoc> BRStudentDoc { get; set; }
        public int BRStudentGroupId { get; set; }
        public BRStudentGroup BRStudentGroup { get; }
    }
}
