using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plagiarism_Checker.Models.Student
{
    public class Subjects
    {
        public Subjects(string nameOfDiscipline, string lector, string time)
        {
            NameOfDiscipline = nameOfDiscipline;
            Lector = lector;
            Time = time;
        }

        public string NameOfDiscipline { get; set; }
        public string Lector { get; set; }
        public string Time { get; set; }

    }
}
