using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plagiarism_Checker.Models.Student
{
    public class FullTask

    {
        public FullTask(Task task, Assignment taskAssignment, string nameOfDiscipline, string lector, string time)
        {
            _Task = task;
            TaskAssignment = taskAssignment;
            NameOfDiscipline = nameOfDiscipline;
            Lector = lector;
            Time = time;
        }

        public FullTask(Task task, Assignment taskAssignment, Solution taskSolutiont, string nameOfDiscipline, string lector, string time)
        {
            _Task = task;
            TaskAssignment = taskAssignment;
            TaskSolutiont = taskSolutiont;
            NameOfDiscipline = nameOfDiscipline;
            Lector = lector;
            Time = time;
        }

        public Task _Task { get; set; }
        public Assignment TaskAssignment { get; set; }
        public Solution TaskSolutiont { get; set; }
        public string NameOfDiscipline { get; set; }
        public string Lector { get; set; }
        public string Time { get; set; }
      
    }
}
