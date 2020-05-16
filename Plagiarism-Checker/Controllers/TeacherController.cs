using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plagiarism_Checker.Extensions;
using Plagiarism_Checker.Models.Student;

namespace Plagiarism_Checker.Controllers
{
    [Authorize(Roles = "Teacher")]

    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View(new StudentTasks());
        }

        public IActionResult WorkChecker()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile firstFile, IFormFile secondFile)
        {
            if (firstFile != null && secondFile != null)
            {
                var firstContent = await firstFile.ReadAsStringAsync();
                var secondContent = await secondFile.ReadAsStringAsync();
            }

            return RedirectToAction("WorkChecker", "Teacher");
        }
    }
}