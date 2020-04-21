using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plagiarism_Checker.Models;

namespace Plagiarism_Checker.Models.StudentDTO
{
    public class StudentTasks
    {
        public List<FullTask> Hometasks = new List<FullTask>();
        public List<FullTask> SolvedHometasks = new List<FullTask>();

        public List<FullTask> Tests = new List<FullTask>();
        public List<FullTask> SolvedTests = new List<FullTask>();

    }
}
