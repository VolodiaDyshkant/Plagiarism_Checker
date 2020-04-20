using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plagiarism_Checker.Models.AccountDTO
{
    public class LogIn
    {
        [Required]

        //custom way
        //[RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]

        [EmailAddress(ErrorMessage = "Email format is invalid!")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
