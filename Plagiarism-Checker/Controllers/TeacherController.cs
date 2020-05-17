using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plagiarism_Checker.Models;
using Plagiarism_Checker.Models.Interfaces;
using Plagiarism_Checker.Models.Teacher;

namespace Plagiarism_Checker.Controllers
{
    [Authorize(Roles = "Teacher")]

    public class TeacherController : Controller
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
        public TeacherTasks teacherTasks = new TeacherTasks();


        public TeacherController(UserManager<User> userManager, TeacherTasks teacherTasks,
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
            this.teacherTasks = teacherTasks;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListSubjects()
        {
            SubjectUpdate(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(subjects);
        }

        public IActionResult ListTests()
        {
            teacherTasksUpdate(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(teacherTasks);
        }


        public IActionResult ListHomework()
        {
            teacherTasksUpdate(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(teacherTasks);
        }
        public IActionResult ListSolvedTests()
        {
            teacherTasksUpdate(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return View(teacherTasks);
        }
        public IActionResult AddTask()
        {
            SubjectUpdate(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            TaskAdd newtask = new TaskAdd(subjects);
            return View(newtask);
        }

        [HttpPost]
        public IActionResult AddTask(TaskAdd task)
        {
            Assignment assignment = new Assignment();
            Models.Task ad_tast = new Models.Task();

            assignment.Deadline = task.taskAdd.Deadline;
            assignment.Requirenments = task.taskAdd.Requirenments;
            if (ModelState.IsValid)
            {
                _Assignment.Insert(assignment);
                ad_tast.AssignmentId = _Assignment.GetAll().OrderBy(a => a.Id).LastOrDefault().Id;
                _Task.Insert(ad_tast);
                if (task.taskAdd.IsTest == true)
                {
                    var l = _Lesson.GetById(task.taskAdd.Lesson);
                    l.TestTaskId = _Task.GetAll().OrderBy(a => a.Id).LastOrDefault().Id;
                    _Lesson.Update(l);
                }
                else
                {
                    var l = _Lesson.GetById(task.taskAdd.Lesson);
                    l.HwTaskId = _Task.GetAll().OrderBy(a => a.Id).LastOrDefault().Id;
                    _Lesson.Update(l);
                }
                return RedirectToAction("Index", "Teacher");
            }
            else
            {
                return View(task);
            }

        }



        public void SubjectUpdate(string Id)
        {
            var userId = Id; // will give the user's userId

            var current_sch = _Schedule.GetAll().Where(sch => sch.TeacherId == userId);
            foreach (var item in current_sch)
            {
                string NameDiscipline = _Discipline.GetById(item.DisciplineId).Name;
                var Group = _Group.GetById(item.GroupId).Name;
                string Time = _Day.GetById(item.DayId).Day1 + " " + _Time.GetById(item.TimeId).Time1.ToString();
                var lesson = _Lesson.GetAll().Where(l => l.ScheduleId == item.Id).FirstOrDefault();
                subjects.Add(new Subjects(NameDiscipline, Group, Time, item.GroupId, lesson.Id));
            }
        }

        public void teacherTasksUpdate(string id)
        {
            var r = new Regex(@"
                (?<=[A-Z])(?=[A-Z][a-z]) |
                 (?<=[^A-Z])(?=[A-Z]) |
                 (?<=[A-Za-z])(?=[^A-Za-z])", RegexOptions.IgnorePatternWhitespace);
            var userId = id; // will give the user's userId

            var current_sch = _Schedule.GetAll().Where(sch => sch.TeacherId == userId);


            foreach (var item in current_sch)
            {
                string NameDiscipline = _Discipline.GetById(item.DisciplineId).Name;
                var Group = _Group.GetById(item.GroupId).Name;
                var lesson = _Lesson.GetAll().Where(l => l.ScheduleId == item.Id).FirstOrDefault();
                var assign = _Assignment.GetById(_Task.GetById(lesson.TestTaskId).AssignmentId);
                string Time = _Day.GetById(item.DayId).Day1 + " " + _Time.GetById(item.TimeId).Time1.ToString();
                teacherTasks.Tests.Add(new _FullTask(new __Assignment(assign.Id, assign.Deadline, assign.Requirenments), NameDiscipline, Group, Time));
                //var Student = _userManager.FindByIdAsync(_Group.GetById(item.GroupId).StudentId);
                //string LectorName = r.Replace(Student.UserName, " ");
            }

        }

    }
}