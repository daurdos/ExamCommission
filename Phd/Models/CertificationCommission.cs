using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class CertificationCommission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> User { get; set; }
        public ICollection<Student> Student { get; set; }

    }
}
