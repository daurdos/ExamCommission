using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class PhdStudentManual
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Неверно указана фамилия")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Неверно указано имя")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }


        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }

        public string LastNameKaz { get; set; } // на казахском языке
        public string FirstNameKaz { get; set; } // на казахском языке
        public string MiddleNameKaz { get; set; } // на казахском языке
        public string LastNameEng { get; set; } // на английском языке
        public string FirstNameEng { get; set; } // на английском языке
        public string MiddleNameEng { get; set; } // на английском языке

        public int RectorId { get; set; } // one rector - many students
        public Rector Rector { get; set; }

        [Required(ErrorMessage = "Неверно указано название диссертации")]
        [Display(Name = "Название диссертации")]
        public string ThesisNameRus { get; set; }

        public string ThesisNameKaz { get; set; }
        public string ThesisNameEng { get; set; }


        [Required(ErrorMessage = "Неверно указана дата защиты")]
        [Display(Name = "Дата диссертационного совета")]
        [DataType(DataType.Date)]
        public DateTime ThesisComDate { get; set; }

        [Required(ErrorMessage = "Неверно указано количество")]
        [Display(Name = "Всего членов заседающих")]
        public int ComMemberNumberTotal { get; set; }

        [Required(ErrorMessage = "Неверно указано количество")]
        [Display(Name = "Членов совета по специальности")]
        public int ComMemberNumberSpecific { get; set; }


        public ICollection<Vote> Vote { get; set; } // one PhdStudent - many Votes


        [Display(Name = "Специальность")]
        public int MajorId { get; set; } // many PhdStudents - one Major

        public Major Major { get; set; } // many PhdStudents - one Major


        [Display(Name = "Направление подготовки")]
        public int TrainingDirectionId { get; set; } // many PhdStudents - one TrainingDirection

        public TrainingDirection TrainingDirection { get; set; } // many PhdStudents - one TrainingDirection


        [Display(Name = "Номер приказа диссовета")]
        public int DisCouncilId { get; set; } // many PhdStudents - one Dissertation Council

        public DisCouncil DisCouncil { get; set; } // many PhdStudents - one Dissertation Council

        public DiplomaFormOne DiplomaFormOne { get; set; }


    }
}
