using System;
using System.Collections.Generic;

namespace Plagiarism_Checker.Models
{
    public partial class StudentLesson : BaseEntity
    {
        public string StudentId { get; set; }
        public int LessonId { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual User Student { get; set; }
    }
}
