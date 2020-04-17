using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class StudentReportViewModel
    {
        public int PhdId { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public int PositiveVoteQuantity { get; set; }
        public int NegativeVoteQuantity { get; set; }
        public int OverallVoteQuantity { get; set; }
        public string MajName { get; set; }
        public string MajCode { get; set; }
        public string TrainingDirectionCypher { get; set; }
        public string TrainingDirectionCypherName { get; set; }
        public string DisNameRus { get; set; }
        public int MemberNumberTotal { get; set; }
        public int MemberNumberSpecific { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Voice { get; set; }

        public IEnumerable<Major> AllMajors { get; set; }
        public IEnumerable<TrainingDirection> AllTrainingDirections { get; set; }
    }
}
