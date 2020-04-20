using System;
using System.Collections.Generic;

namespace Plagiarism_Checker.Models
{
    public partial class Discipline : BaseEntity
    {
        public Discipline()
        {
            Schedule = new HashSet<Schedule>();
        }

        public string Name { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
