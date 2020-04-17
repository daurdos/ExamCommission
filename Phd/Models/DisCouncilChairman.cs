using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class DisCouncilChairman
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FullNameKaz { get; set; }
        public string FullNameEng { get; set; }
        public int DisCouncilId { get; set; }
        public DisCouncil DisCouncil { get; set; }
    }
}
