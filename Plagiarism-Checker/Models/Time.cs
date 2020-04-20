using System;
using System.Collections.Generic;

namespace Plagiarism_Checker.Models
{
    public partial class Time : BaseEntity
    {
        public Time()
        {
            Schedule = new HashSet<Schedule>();
        }

        public TimeSpan? Time1 { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
