using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Plagiarism_Checker.Models;

namespace Plagiarism_Checker.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ChooseFile()
        {
            return View();
        }

        private readonly IHostingEnvironment _appEnvironment;

        [HttpPost]
        public ActionResult AddFile(IFormFile[] files)
        {
            byte[] ByteArray = null;
            for (int i = 0; i < files.Length; i++)
            {
                using (var binaryReader = new BinaryReader(files[i].OpenReadStream()))
                {
                    ByteArray = binaryReader.ReadBytes((int)files[i].Length);
                }
                using (UniverContext db = new UniverContext())
                {



                    db.Solution.Add(new Solution
                    { File = ByteArray });
                    db.SaveChanges();

                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
