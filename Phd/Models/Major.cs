using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class Major
    {
        [Key]
        public int Id { get; set; }
        public string MajorCypher { get; set; }
        public string MajorCypherName { get; set; }
        public string MajorCypherNameKaz { get; set; }
        public string MajorCypherNameEng { get; set; }

        public ICollection<PhdStudent> PhdStudent { get; set; }

    }
}
