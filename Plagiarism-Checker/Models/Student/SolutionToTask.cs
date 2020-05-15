using Microsoft.AspNetCore.Http;
using Microsoft.Web.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plagiarism_Checker.Models.Student
{
    public class SolutionToTask
    {
        public SolutionToTask(string nameOfDiscipline, string requirements, string time, string lector, int taskId)
        {
            NameOfDiscipline = nameOfDiscipline;
            Requirements = requirements;
            Time = time;
            Lector = lector;
            TaskId = taskId;
        }

        public string NameOfDiscipline { get; set; }
        public string Requirements { get; set; }
        public string Time { get; set; }
        public string Lector { get; set; }

        [Required(ErrorMessage ="Please upload a file")]
        [DataType(DataType.Upload)]

        public IFormFile PostedFile { get; set; }
        public int TaskId { get; set; }
        public double Percent { get; set; }




    }
}
