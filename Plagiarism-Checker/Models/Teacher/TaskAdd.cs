using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plagiarism_Checker.Models.Teacher
{
    public class TaskAdd
    {

        public _TaskAdd taskAdd;
        public List<Subjects> subjects=new List<Subjects>();

        public TaskAdd(List<Subjects> subjects)
        {
            this.subjects = subjects;
        }
    }
    public class _TaskAdd
    {
        [Required(ErrorMessage = "Оберить тип завдання:")]
        public bool IsTest { get; set; }
        [Required(ErrorMessage = "Вкажіть термір виконання завдання:")]
        [DataType(DataType.DateTime)]
        public DateTime Deadline { get; set; }
        [Required(ErrorMessage = "Заповніть вимоги:")]
        public string Requirenments { get; set; }

        [Required(ErrorMessage = "Заповніть поле з вибраною дисципліною тф группою:")]

        public int Lesson { get; set; }

  
    }
}
