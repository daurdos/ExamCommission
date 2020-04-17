using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class TrainingDirection
    {
        [Key]
        public int Id { get; set; }
        public string TrainingDirectionCypher { get; set; }
        public string TrainingDirectionCypherName { get; set; }
        public string TrainingDirectionCypherNameKaz { get; set; }
        public string TrainingDirectionCypherNameEng { get; set; }
        public ICollection<PhdStudent> PhdStudent { get; set; }

    }
}
