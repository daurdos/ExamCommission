using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class DisCouncil


    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите номер приказа диссовета")]
        [Display(Name = "Номер приказа")]
        public string OrderNumber { get; set; }

        [Required(ErrorMessage = "Укажите председателя")]
        [Display(Name = "Председатель")]
        public string CouncilChairman { get; set; } // manual insertion

        [Required(ErrorMessage = "Укажите секретаря")]
        [Display(Name = "Секретарь")]
        public string CouncilSecretary { get; set; }

        [Required(ErrorMessage = "Перечислите членов совета через запятую")]
        [Display(Name = "Члены совета")]
        public string CouncilMember { get; set; }

        [Display(Name = "Дата защиты")]
        public DateTime DefenceDate { get; set; }

        public ICollection<User> User { get; set; }
        public ICollection<PhdStudent> PhdStudent {get; set; }
        public DisCouncilChairman DisCouncilChairman { get; set; } // one discouncil - one chairman (справочник)

        


    }
}
