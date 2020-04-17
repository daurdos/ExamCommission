using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int Value { get; set; }
        
        
        public int StudentId { get; set; }
        public Student Student { get; set; }


        public string UserId { get; set; }
        public User User { get; set; }
    }
}
