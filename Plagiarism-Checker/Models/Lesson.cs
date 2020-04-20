using System;
using System.Collections.Generic;

namespace Plagiarism_Checker.Models
{
    public partial class Lesson : BaseEntity
    {
        public Lesson()
        {
            StudentLesson = new HashSet<StudentLesson>();
        }

        public int ScheduleId { get; set; }
        public int HwTaskId { get; set; }
        public int TestTaskId { get; set; }

        public virtual Task HwTask { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Task TestTask { get; set; }
        public virtual ICollection<StudentLesson> StudentLesson { get; set; }
    }
}
