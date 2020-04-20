using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plagiarism_Checker.Models.AccountDTO
{
    public class Registration
    {
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Name is invalid!")]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "Surname is invalid!")]
        public string Surname { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Email format is invalid!")]
        public string Email { get; set; }
        public bool isTeacher { get; set; }
        [DataType(DataType.Password)]
        [Required, MinLength(6)]
        public string Password1 { get; set; }
        [Required, Compare(nameof(Password1))]
        [DataType(DataType.Password)]
        public string Password2 { get; set; }
        [RegularExpression("([0-9]{7}[a-zA-Z])")]
        public string student_number { get; set; }
        [RegularExpression("([0-9]{10})")]
        public string nin { get; set; }
    }
}
