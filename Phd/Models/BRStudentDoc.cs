using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class BRStudentDoc
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BRStudentId { get; set; }
        public BRStudent BRStudent { get; set; }
        public int StudentDocTypeId { get; set; }
        public StudentDocType StudentDocType { get; set; }

    }
}
