using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plagiarism_Checker.Models;
using Plagiarism_Checker.Models.Interfaces;
using Plagiarism_Checker.Models.Student;
using Plagiarism_Checker.Rpositories;

namespace Plagiarism_Checker.Controllers
{
    public class StudentController : Controller
    {
        private readonly UserManager<User> _userManager;

        public IRepository<StudentLesson> _Student_Lesson;
        public IRepository<Lesson> _Lesson;
        public IRepository<Models.Task> _Task;
        public IRepository<Assignment> _Assignment;
        public IRepository<Solution> _Solution;
        public IRepository<Schedule> _Schedule;
        public IRepository<Discipline> _Discipline;
        public IRepository<Time> _Time;
        public IRepository<Day> _Day;
        public IRepository<Models.Group> _Group;
        public List<Subjects> subjects;
        public StudentTasks studentTasks = new StudentTasks();


        public StudentController(UserManager<User> userManager, StudentTasks studentTasks,
            IRepository<StudentLesson> student_Lesson, IRepository<Lesson> lesson, IRepository<Models.Task> task,
            IRepository<Assignment> assignment, IRepository<Solution> solution, IRepository<Schedule> schedule,
            IRepository<Discipline> discipline, IRepository<Time> time, IRepository<Day> day, List<Subjects> _subjects, IRepository<Models.Group> group, StudentTasks _studentTasks)
        {
            _userManager = userManager;
            _Student_Lesson = student_Lesson;
            _Lesson = lesson;
            _Task = task;
            _Assignment = assignment;
            _Solution = solution;
            _Schedule = schedule;
            _Discipline = discipline;
            _Time = time;
            _Day = day;
            _Group = group;
            subjects = _subjects;
            studentTasks = _studentTasks;
            studentTasksUpdate(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        [Authorize]

        public IActionResult Index()
        {
            studentTasksUpdate(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            StudentTasks studentTasksPreview = new StudentTasks();
            for (int i = 0; i < 3; i++)
            {

                if (studentTasks.Hometasks.OrderBy(t => t.TaskAssignment.Deadline).Count()> i)
                {
                    studentTasksPreview.Hometasks.Add(studentTasks.Hometasks.OrderBy(t => t.TaskAssignment.Deadline).ElementAt(i));
                }
                if (studentTasks.Tests.OrderBy(t => t.TaskAssignment.Deadline).Count() > i)
                {
                    studentTasksPreview.Tests.Add(studentTasks.Tests.OrderBy(t => t.TaskAssignment.Deadline).ElementAt(i));
                }

            }

            return View(studentTasksPreview);
        }
        //ListHomework
        //ListSubjects
        //ListTestWork

        public IActionResult SolvedTask(SolutionToTask model)
        {
            studentTasksUpdate(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            double countedPercent = 0;
            model.Percent = countedPercent;
            return View(model);
        }
        public IActionResult ListHomework()
        {
            studentTasksUpdate(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(studentTasks.SolvedHometasks);
        }

        public IActionResult ListUnsolvedHomework()
        {
            studentTasksUpdate(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var unsolvedHw = studentTasks.Hometasks.OrderBy(t => t.TaskAssignment.Deadline).ToList();
            return View(unsolvedHw);
        }
        public IActionResult ListSubjects()
        {
            SubjectUpdate(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(subjects);
        }
        public IActionResult ListTestWork()
        {
            studentTasksUpdate(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(studentTasks.SolvedTests);
        }

        public IActionResult ListUnsolvedTestWork()
        {
            studentTasksUpdate(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var unsolvedTs = studentTasks.Tests.OrderBy(t => t.TaskAssignment.Deadline).ToList();
            return View(unsolvedTs);
        }
        [HttpPost]
        public ActionResult AddSolutionPage(int id)
        {
            studentTasksUpdate(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            bool taskType = false;
            SolutionToTask model;
            foreach (var test in studentTasks.Tests)
            {
                if (test._Task.Id == id)
                {
                    taskType = true;
                }
            }
            if (taskType)
            {
                _FullTask current_test = studentTasks.Tests.Where(h => h._Task.Id == id).FirstOrDefault();
                model = new SolutionToTask(current_test.NameOfDiscipline, current_test.TaskAssignment.Requirenments, current_test.Time, current_test.Lector, id);
            }
            else
            {
                _FullTask current_hw = studentTasks.Hometasks.Where(h => h._Task.Id == id).FirstOrDefault();
                model = new SolutionToTask(current_hw.NameOfDiscipline, current_hw.TaskAssignment.Requirenments, current_hw.Time, current_hw.Lector, id);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult AddSolutionFile(SolutionToTask model)
        {
            studentTasksUpdate(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (ModelState.IsValid && model.PostedFile != null)
            {
                var allowedExtensions = new string[] { "doc", "docx", "pdf", "txt" };
                var extension = Path.GetExtension(model.PostedFile.FileName).ToLower().Replace(".", "");
                if (allowedExtensions.Contains(extension))
                {
                    Solution newSolution = new Solution();
                    using (var ms = new MemoryStream())
                    {
                        model.PostedFile.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        newSolution.File = fileBytes;
                    }
                    _Solution.GetById(_Task.GetById(model.TaskId).SolutionId).File = newSolution.File;
                    _Solution.Update(_Solution.GetById(_Task.GetById(model.TaskId).SolutionId));
                    newSolution.Task.Add(_Task.GetById(model.TaskId));
                    return View("SolvedTask", model);
                }
                else
                {
                    ModelState.AddModelError(nameof(model.PostedFile), "Incorrect format");
                    return View(model);

                }
            }
            return View("SolvedTask", model);

        }
        public void studentTasksUpdate(string id)
        {
            var student_id =  id;
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
                string Time = _Day.GetById(_Schedule.GetById(current_lesson.ScheduleId).DayId).Day1 + " " + _Time.GetById(_Schedule.GetById(current_lesson.ScheduleId).TimeId).Time1.ToString();
                var HomeworkAssign = _Assignment.GetById(item.AssignmentId);

                var some_Sol = new Solution();
                some_Sol.File = new byte[1000 * 1000 * 3];
                _Solution.Insert(some_Sol);
                if (item.Solution != null)
                {
                    if (_Solution.GetAll().Where(s => s.Id == item.SolutionId).FirstOrDefault().File != null)
                    {
                        var HomeworkSolution = _Solution.GetById(item.SolutionId);
                        studentTasks.SolvedHometasks.Add(new _FullTask(new __Task(item.Id, item.AssignmentId, item.SolutionId, item.Percent),
                            new __Assignment(HomeworkAssign.Id, HomeworkAssign.Deadline, HomeworkAssign.Requirenments),
                            new __Solution(HomeworkSolution.Id, HomeworkSolution.File), NameDiscipline, LectorName, Time));
                    }
                }

                else
                {
                    studentTasks.Hometasks.Add(new _FullTask(new __Task(item.Id, item.AssignmentId, item.SolutionId, item.Percent),
                        new __Assignment(HomeworkAssign.Id, HomeworkAssign.Deadline, HomeworkAssign.Requirenments), NameDiscipline, LectorName, Time));
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
                string Time_test = _Day.GetById(_Schedule.GetById(current_lesson_test.ScheduleId).DayId).Day1 + " " + _Time.GetById(_Schedule.GetById(current_lesson_test.ScheduleId).TimeId).Time1.ToString();
                var TestAssign = _Assignment.GetById(item_test.AssignmentId);


                if (item_test.Solution != null)
                {


                    if (!String.IsNullOrEmpty(_Solution.GetById(item_test.SolutionId).File.ToString()))
                    {
                        var TestSolution = _Solution.GetById(item_test.SolutionId);
                        studentTasks.SolvedTests.Add(new _FullTask(new __Task(item_test.Id, item_test.AssignmentId, item_test.SolutionId, item_test.Percent),
                        new __Assignment(TestAssign.Id, TestAssign.Deadline, TestAssign.Requirenments),
                        new __Solution(TestSolution.Id, TestSolution.File), NameDiscipline_test, NameDiscipline_test, Time_test));
                    }
                }
                else
                {
                    studentTasks.Tests.Add(new _FullTask(new __Task(item_test.Id, item_test.AssignmentId, item_test.SolutionId, item_test.Percent),
                        new __Assignment(TestAssign.Id, TestAssign.Deadline, TestAssign.Requirenments),
                        NameDiscipline_test, NameDiscipline_test, Time_test));
                }

            }

        }
        public void SubjectUpdate(string Id)
        {
            var r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
            var userId = Id; // will give the user's userId

            var current_sch = _Schedule.GetAll().Where(sch => sch.GroupId == _Group.GetAll().Where(g => g.StudentId == userId).FirstOrDefault().Id);
            foreach (var item in current_sch)
            {
                string NameDiscipline = _Discipline.GetById(item.DisciplineId).Name;
                var Lector = _userManager.FindByIdAsync(item.TeacherId).Result;
                string LectorName = r.Replace(Lector.UserName, " ");
                string Time = _Time.GetById(item.TimeId).Time1.ToString();

                subjects.Add(new Subjects(NameDiscipline, LectorName, Time));
            }
        }
    }
}