using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class DiplomaFormOne
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool Damaged { get; set; } = false;
        public bool Lost { get; set; } = false;
        public int? PhdStudentId { get; set; }
        public PhdStudent PhdStudent { get; set; }
        public int? PhdStudentManualId { get; set; }
        public PhdStudentManual PhdStudentManual { get; set; }


    }
}
