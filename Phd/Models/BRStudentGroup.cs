using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class BRStudentGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BRStudent> BRStudent { get; set; }
        public int BRExamCommissionId { get; set; }
        public BRExamCommission BRExamCommission { get; set; }

    }
}
