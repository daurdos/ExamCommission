using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class BRExamCommission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public ICollection<User> User { get; set; } // модернизации логики, чтобы была связь с кафедрами
        public ICollection<BRStudentGroup> BRStudentGroup { get; set; }
        public int BMajorId { get; set; }
        public BMajor BMajor { get; set; }









        


    }
}
