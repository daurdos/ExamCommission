using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class StudentDocType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BRStudentDoc> BRStudentDoc { get; set; }
    }
}
