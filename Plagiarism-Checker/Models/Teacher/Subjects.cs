using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plagiarism_Checker.Models.Teacher
{
    public class Subjects
    {
        public Subjects(string nameOfDiscipline, string group, string time)
        {
            NameOfDiscipline = nameOfDiscipline;
            Group = group;
            Time = time;
        }

        public string NameOfDiscipline { get; set; }
        public string Group { get; set; }
        public string Time { get; set; }

    }
