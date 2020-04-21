using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plagiarism_Checker.Models;
using Plagiarism_Checker.Models.StudentDTO;
using Plagiarism_Checker.Rpositories;

namespace Plagiarism_Checker.Controllers
{
    public class StudentController : Controller
    {
        private readonly UserManager<User> _userManager;

        public StudentTasks studentTasks = new StudentTasks();
        public Repository<StudentLesson> _Student_Lesson;
        public Repository<Lesson> _Lesson;
        public Repository<Models.Task> _Task;
        public Repository<Assignment> _Assignment;
        public Repository<Solution> _Solution;
        public Repository<Schedule> _Schedule;
        public Repository<Discipline> _Discipline;
        public Repository<Time> _Time;
        public Repository<Day> _Day;


        public StudentController(UserManager<User> userManager, StudentTasks studentTasks,
            Repository<StudentLesson> student_Lesson, Repository<Lesson> lesson, Repository<Models.Task> task,
            Repository<Assignment> assignment, Repository<Solution> solution, Repository<Schedule> schedule,
            Repository<Discipline> discipline, Repository<Time> time, Repository<Day> day)
        {
            _userManager = userManager;
            this.studentTasks = studentTasks;
            _Student_Lesson = student_Lesson;
            _Lesson = lesson;
            _Task = task;
            _Assignment = assignment;
            _Solution = solution;
            _Schedule = schedule;
            _Discipline = discipline;
            _Time = time;
            _Day = day;
            studentTasksUpdate();

        }

        public IActionResult Index()
        {
            StudentTasks studentTasksPreview = new StudentTasks();
            for (int i = 0; i < 3; i++)
            {
                studentTasksPreview.SolvedHometasks.Add(studentTasks.SolvedHometasks.OrderBy(t => t.TaskAssignment.Deadline).ElementAt(i));
                studentTasksPreview.Tests.Add(studentTasks.Tests.OrderBy(t => t.TaskAssignment.Deadline).ElementAt(i));

            }

            return View(studentTasksPreview);
        }
        //ListHomework
        //ListSubjects
        //ListTestWork

        public IActionResult SolvedTask(SolutionToTask model)
        {
            double countedPercent = 0 ;
            model.Percent = countedPercent;
            return View(model);
        }
        public IActionResult ListHomework()
        {
            return View(studentTasks.SolvedHometasks);
        }

        public IActionResult ListUnsolvedHomework()
        {

            var unsolvedHw = studentTasks.Hometasks.OrderBy(t => t.TaskAssignment.Deadline).ToList();
            return View(unsolvedHw);
        }
        [HttpPost]
        public ActionResult AddSolutionPage(int id)
        {
            bool taskType = false;
            SolutionToTask model;
            foreach (var test in studentTasks.Tests)
            {
                if(test._Task.Id==id)
                {
                    taskType = true;
                }
            }
            if (taskType)
            {
                FullTask current_test = studentTasks.Tests.Where(h => h._Task.Id == id).FirstOrDefault();
                 model = new SolutionToTask(current_test.NameOfDiscipline, current_test.TaskAssignment.Requirenments, current_test.Time, current_test.Lector, id);
            }
            else {
                FullTask current_hw = studentTasks.Hometasks.Where(h => h._Task.Id == id).FirstOrDefault();
                model = new SolutionToTask(current_hw.NameOfDiscipline, current_hw.TaskAssignment.Requirenments, current_hw.Time, current_hw.Lector, id);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddSolutionFile(SolutionToTask model)
        {
            if (ModelState.IsValid && model.PostedFile != null)
            {
                var allowedExtensions = new string[] { "doc", "docx", "pdf", "txt" };
                var extension = Path.GetExtension(model.PostedFile.FileName).ToLower().Replace(".", "");
                if (allowedExtensions.Contains(extension))
                {
                    Solution newSolution=new Solution();
                    using (var ms = new MemoryStream())
                    {
                        model.PostedFile.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        newSolution.File = fileBytes;
                    }
                    newSolution.Task.Add(_Task.GetById(model.TaskId));
                    _Solution.Insert(newSolution);
                    studentTasksUpdate();
                    return View("SolvedTask",model);
                }
                else
                {
                    ModelState.AddModelError(nameof(model.PostedFile), "Incorrect format");
                    return View(model);

                }
            }
            return View("SolvedTask",model);

        }
        public void studentTasksUpdate()
        {
            var student_id = _userManager.GetUserId(User);
            var student_leson = _Student_Lesson.GetAll().Where(s => s.StudentId == student_id);
            var listHomework = from s_l in student_leson
                               join l in _Lesson.GetAll()
                                   on s_l.LessonId equals l.Id
                               where !String.IsNullOrEmpty(l.HwTaskId.ToString())
                               join t in _Task.GetAll() on l.HwTaskId equals t.Id
                               select t;


            var r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);

            foreach (var item in listHomework)
            {

                var current_lesson = _Lesson.GetAll().Where(l => l.HwTaskId == item.Id).FirstOrDefault();
                string NameDiscipline = _Discipline.GetById(_Schedule.GetById(current_lesson.ScheduleId).DisciplineId).Name;
                var Lector = _userManager.FindByIdAsync(_Schedule.GetById(current_lesson.ScheduleId).TeacherId).Result;
                string LectorName = r.Replace(Lector.UserName, " ");
                string Time = _Day.GetById(_Schedule.GetById(current_lesson.ScheduleId).DayId).Day1 + " " + _Time.GetById(_Schedule.GetById(current_lesson.ScheduleId).TimeId).Time1;
                var HomeworkAssign = _Assignment.GetById(item.AssignmentId);


                if (!String.IsNullOrEmpty(item.SolutionId.ToString()))
                {
                    var HomeworkSolution = _Solution.GetById(item.SolutionId);
                    studentTasks.SolvedHometasks.Add(new FullTask(item, HomeworkAssign, HomeworkSolution, NameDiscipline, LectorName, Time));
                }
                else
                {
                    studentTasks.Hometasks.Add(new FullTask(item, HomeworkAssign, NameDiscipline, LectorName, Time));
                }
            }


                var listTests = from s_l in student_leson
                                join l in _Lesson.GetAll()
                                    on s_l.LessonId equals l.Id
                                where !String.IsNullOrEmpty(l.TestTaskId.ToString())
                                join t in _Task.GetAll() on l.TestTaskId equals t.Id
                                select t;

                foreach (var item_test in listTests)
                {

                    var current_lesson_test = _Lesson.GetAll().Where(l => l.TestTaskId == item_test.Id).FirstOrDefault();
                    string NameDiscipline_test = _Discipline.GetById(_Schedule.GetById(current_lesson_test.ScheduleId).DisciplineId).Name;
                    var Lector_test = _userManager.FindByIdAsync(_Schedule.GetById(current_lesson_test.ScheduleId).TeacherId).Result;
                    string LectorName_test = r.Replace(Lector_test.UserName, " ");
                    string Time_test = _Day.GetById(_Schedule.GetById(current_lesson_test.ScheduleId).DayId).Day1 + " " + _Time.GetById(_Schedule.GetById(current_lesson_test.ScheduleId).TimeId).Time1;
                    var TestAssign = _Assignment.GetById(item_test.AssignmentId);


                    if (!String.IsNullOrEmpty(item_test.SolutionId.ToString()))
                    {
                        var TestSolution = _Solution.GetById(item_test.SolutionId);
                        studentTasks.SolvedTests.Add(new FullTask(item_test, TestAssign, TestSolution, NameDiscipline_test, LectorName_test, Time_test));
                    }
                    else
                    {
                        studentTasks.Tests.Add(new FullTask(item_test, TestAssign, NameDiscipline_test, LectorName_test, Time_test));
                    }


                }
            
        }
    }
}