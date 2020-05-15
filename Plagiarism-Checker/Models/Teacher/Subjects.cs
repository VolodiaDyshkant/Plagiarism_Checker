using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plagiarism_Checker.Models.Teacher
{
    public class Subjects
    {
        public Subjects(string nameOfDiscipline, string group, string time,int groupId, int lessonId)
        {
            NameOfDiscipline = nameOfDiscipline;
            Group = group;
            Time = time;
            GroupId = groupId;
            LessonId = lessonId;
        }

        public string NameOfDiscipline { get; set; }
        public string Group { get; set; }
        public int GroupId { get; set; }
        public int LessonId { get; set; }

        public string Time
        { get; set; }

    }
}
