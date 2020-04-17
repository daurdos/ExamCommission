using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Phd.Models
{
    public class MajorCodeViewModel
    {
        public List<PhdStudent> PhdStudents { get; set; }
        public SelectList Cyphers { get; set; }
        public string MajorCypher{ get; set; }

        public string SearchString { get; set; }

        // <summary>


        public int Id { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Отчество")]
        public string MiddleName { get; set; }


        [Display(Name = "Специальность")]
        public string MajorName { get; set; }

        [Display(Name = "Название диссертации")]
        public string ThesisNameRus { get; set; }

        [Display(Name = "Дата диссертационного совета")]
        [DataType(DataType.Date)]
        public DateTime ThesisComDate { get; set; }






        [Display(Name = "Всего членов совета")]
        public int ComMemberNumberTotal { get; set; }

        [Display(Name = "Членов совета по специальности")]
        public int ComMemberNumberSpecific { get; set; }

        [Display(Name = "Направление подготовки кадров")]
        public string EducationDirection { get; set; }




        // </summary>


    }
}
