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
        //for a cool password
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
        [EmailAddress(ErrorMessage = "Email format is invalid!")]
        public string Email { get; set; }
        public bool isTeacher { get; set; }
        [Required]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [DataType(DataType.Password)]

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
