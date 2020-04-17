using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class BRStudentGrade
    {
        public int Id { get; set; }
        public int Value { get; set; }


        public int BRStudentId { get; set; }
        public BRStudent BRStudent { get; set; }


        public string UserId { get; set; }
        public User User { get; set; }
    }
}
