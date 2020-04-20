using System;
using System.Collections.Generic;

namespace Plagiarism_Checker.Models
{
    public partial class Solution : BaseEntity
    {
        public Solution()
        {
            Task = new HashSet<Task>();
        }

        public byte[] File { get; set; }

        public virtual ICollection<Task> Task { get; set; }
    }
}
