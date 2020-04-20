using System;
using System.Collections.Generic;

namespace Plagiarism_Checker.Models
{
    public partial class Schedule : BaseEntity
    {
        public Schedule()
        {
            Lesson = new HashSet<Lesson>();
        }

        public string TeacherId { get; set; }
        public int GroupId { get; set; }
        public int DisciplineId { get; set; }
        public int DayId { get; set; }
        public int TimeId { get; set; }

        public virtual Day Day { get; set; }
        public virtual Discipline Discipline { get; set; }
        public virtual Group Group { get; set; }
        public virtual User Teacher { get; set; }
        public virtual Time Time { get; set; }
        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}
