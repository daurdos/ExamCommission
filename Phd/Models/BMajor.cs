using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class BMajor
    {
        public int Id { get; set; }
        public string Cypher { get; set; }
        public string NameRus { get; set; }
        public string NameKaz { get; set; }
        public string NameEng { get; set; }

        public ICollection<BRExamCommission> BRExamCommission { get; set; }
        public int AcademicDepartmentId { get; set; }
        public AcademicDepartment AcademicDepartment { get; set; }








       


    }
}
