using System;
using System.Collections.Generic;

namespace Plagiarism_Checker.Models
{ 
    public partial class Group : BaseEntity
    {
        public Group()
        {
            Schedule = new HashSet<Schedule>();
        }

        public string Name { get; set; }
        public string StudentId { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
