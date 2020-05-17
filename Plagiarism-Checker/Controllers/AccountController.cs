using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plagiarism_Checker.Models;
using Plagiarism_Checker.Models.AccountDTO;
using Plagiarism_Checker.Models.Interfaces;
using Plagiarism_Checker.Models.Student;
using Plagiarism_Checker.Rpositories;

namespace Plagiarism_Checker.Controllers
{

    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMapper _mapperAp;

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IRepository<Applications> _applications;


        //private readonly UserRepository<User> db;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager, IRepository<Applications> applications)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _applications = applications;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Registration, User>()
            .ForMember(u => u.Email, opt => opt.MapFrom(i => i.Email))
            .ForMember(u => u.UserName, opt => opt.MapFrom(i => i.Name+i.Surname))
            .ForMember(u => u.StudentNumber, opt => opt.MapFrom(i => i.student_number))
            .ForMember(u => u.Nin, opt => opt.MapFrom(i => i.nin)));
            _mapper = new Mapper(config);


            _mapperAp = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Registration, Applications>()));
        }

        public IActionResult ThanksFR()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(Registration model)
        {
            var user = _mapper.Map<User>(model);
            var result = await _userManager.CreateAsync(user, model.Password2);
            await _signInManager.PasswordSignInAsync(model.Email, model.Password2, false, false);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View(model);
            }
            else
            { 
                await _userManager.DeleteAsync(user);
                var appl = _mapperAp.Map<Applications>(model);
                appl.Name = model.Name;
                appl.Surname = model.Surname;
                appl.IsTeacher = model.isTeacher;
                appl.Password = model.Name;
                appl.StudentNumber = model.student_number;
                appl.Nin = model.nin;
                appl.Password = model.Password2;
                appl.Email = model.Email;
                _applications.Insert(appl);
                return View("ThanksFR", "Account");
            }

        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogIn model)
        {
            if (ModelState.IsValid)
            {
                await _signInManager.SignOutAsync();
                var user = _userManager.FindByEmailAsync(model.Email).Result;

                if(user==null)
                {
                    ModelState.AddModelError("", "Password or Email is invalid!");
                    return View();
                }
                Microsoft.AspNetCore.Identity.SignInResult result =
                    await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Password or Email is invalid!");
                    return View();
                }
                if (_userManager.IsInRoleAsync(user, "Teacher").Result)
                {
                    return RedirectToAction("Index", "Teacher");

                    //return RedirectToAction("WorkChecker", "Teacher");
                }
                if (_userManager.IsInRoleAsync(user, "Student").Result)
                {

                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    //return RedirectToAction("Index", "Student");
                    return RedirectToAction("UsersList", "Admin");

                }
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("LogIn", "Account");
        }
    }
}