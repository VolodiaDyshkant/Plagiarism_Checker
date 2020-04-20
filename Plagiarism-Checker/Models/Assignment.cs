using System;
using System.Collections.Generic;

namespace Plagiarism_Checker.Models
{
    public partial class Assignment:BaseEntity
    {
        public Assignment()
        {
            Task = new HashSet<Task>();
        }

        public DateTime Deadline { get; set; }
        public string Requirenments { get; set; }

        public virtual ICollection<Task> Task { get; set; }
    }
}
