using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phd.Models
{
    public enum Choice
    {
        [Display(Name = "Против")]
        No,
        [Display(Name = "За")]
        Yes
    }
    public class Vote
    {
        public int Id { get; set; }
        public string Voice { get; set; }

        public int PhdStudentId { get; set; }
        public PhdStudent PhdStudent { get; set; }
    }
}
