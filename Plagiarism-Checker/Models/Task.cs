using System;
using System.Collections.Generic;

namespace Plagiarism_Checker.Models
{
    public partial class Task : BaseEntity
    {
        public Task()
        {
            LessonHwTask = new HashSet<Lesson>();
            LessonTestTask = new HashSet<Lesson>();
        }

        public int AssignmentId { get; set; }
        public int SolutionId { get; set; }
        public double Percent { get; set; }

        public virtual Assignment Assignment { get; set; }
        public virtual Solution Solution { get; set; }
        public virtual ICollection<Lesson> LessonHwTask { get; set; }
        public virtual ICollection<Lesson> LessonTestTask { get; set; }
    }
}
