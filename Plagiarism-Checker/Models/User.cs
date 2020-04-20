using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Plagiarism_Checker.Models
{
    public partial class User:IdentityUser
    {
        public User()
        {
            Schedule = new HashSet<Schedule>();
            StudentLesson = new HashSet<StudentLesson>();
        }

        public string StudentNumber { get; set; }
        public string Nin { get; set; }
        public int? StudentLessonId { get; set; }
        public string Discriminator { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
        public virtual ICollection<StudentLesson> StudentLesson { get; set; }
    }
}
