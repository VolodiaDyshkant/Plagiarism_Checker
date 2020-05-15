using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plagiarism_Checker.Models.Teacher
{

    public class TeacherTasks
    {
        public List<_FullTask> Tests = new List<_FullTask>();
        public List<_FullTask> SolvedTests = new List<_FullTask>();
        public List<_FullTask> SolvedHometasks = new List<_FullTask>();
    }
    public class _FullTask

    {
        public _FullTask(__Task task, __Assignment taskAssignment, string nameOfDiscipline, string student, string time)
        {
            _Task = task;
            TaskAssignment = taskAssignment;
            NameOfDiscipline = nameOfDiscipline;
            Student = student;
            Time = time;
        }
        public _FullTask(__Assignment taskAssignment, string nameOfDiscipline, string group, string time)
        {
            TaskAssignment = taskAssignment;
            NameOfDiscipline = nameOfDiscipline;
            Group = group;
            Time = time;
        }

        public _FullTask(__Task task, __Assignment taskAssignment, __Solution taskSolutiont, 
            string nameOfDiscipline, string student, string time)
        {
            _Task = task;
            TaskAssignment = taskAssignment;
            TaskSolutiont = taskSolutiont;
            NameOfDiscipline = nameOfDiscipline;
            Student = student;
            Time = time;
        }

        public __Task _Task { get; set; }
        public __Assignment TaskAssignment { get; set; }
        public __Solution TaskSolutiont { get; set; }
        public string NameOfDiscipline { get; set; }
        public string Student { get; set; }
        public string Group { get; set; }
        public string Time { get; set; }

    }
    public class __Task
    {
        public __Task(int id, int assignmentId, int solutionId, double percent)
        {
            Id = id;
            AssignmentId = assignmentId;
            SolutionId = solutionId;
            Percent = percent;
        }

        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public int SolutionId { get; set; }
        public double Percent { get; set; }
    }
    public class __Assignment
    {
        public __Assignment(int id, DateTime deadline, string requirenments)
        {
            Id = id;
            Deadline = deadline;
            Requirenments = requirenments;
        }

        public int Id { get; set; }
        public DateTime Deadline { get; set; }
        public string Requirenments { get; set; }
    }
    public class __Solution
    {
        public __Solution(int id)
        {
            Id = id;
        }

        public __Solution(int id, byte[] file) : this(id)
        {
            File = file;
        }

        public int Id { get; set; }
        public byte[] File { get; set; }
    }

}
