using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plagiarism_Checker.Models
{
    public class User:IdentityUser
    {
        public string surname { get; set; }
        public string student_number { get; set; }
        public string nin { get; set; }
        public int student_lesson_id { get; set; }
    }
}
