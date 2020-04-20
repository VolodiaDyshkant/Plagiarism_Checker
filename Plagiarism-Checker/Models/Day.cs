using System;
using System.Collections.Generic;

namespace Plagiarism_Checker.Models
{
    public partial class Day : BaseEntity
    {
        public Day()
        {
            Schedule = new HashSet<Schedule>();
        }

        public string Day1 { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
