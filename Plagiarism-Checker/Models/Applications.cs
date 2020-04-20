using System;
using System.Collections.Generic;

namespace Plagiarism_Checker.Models
{
    public partial class Applications : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool IsTeacher { get; set; }
        public string Password { get; set; }
        public string StudentNumber { get; set; }
        public string Nin { get; set; }
    }
}
