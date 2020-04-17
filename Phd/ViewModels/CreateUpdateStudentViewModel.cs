using Phd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.ViewModels
{
    public class CreateUpdateStudentViewModel
    {

        public PhdStudent PhdStudent { get; set; }
        public IEnumerable<Major> AllMajors { get; set; }
        public IEnumerable<TrainingDirection> AllTrainingDirections { get; set; }
       

    }
}
