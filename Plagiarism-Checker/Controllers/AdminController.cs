using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plagiarism_Checker.Models;
using Plagiarism_Checker.Models.AdminDTO;
using Plagiarism_Checker.Models.Interfaces;
using Plagiarism_Checker.Rpositories;
using Plagiarism_Checker.Services;

namespace Plagiarism_Checker.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private 
           IRepository<Applications> _applications;
        private readonly EmailService _emailService;

        public AdminController(UserManager<User> userManager, 
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager, 
            IRepository<Applications> applications,
            EmailService emailService
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _applications = applications;
            _emailService = emailService;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Applications, User>()
           .ForMember(u => u.Email, opt => opt.MapFrom(i => i.Email))
           .ForMember(u => u.UserName, opt => opt.MapFrom(i => i.Name + i.Surname))
           .ForMember(u => u.StudentNumber, opt => opt.MapFrom(i => i.StudentNumber))
           .ForMember(u => u.Nin, opt => opt.MapFrom(i => i.Nin)));

            _mapper = new Mapper(config);
        }

        public IActionResult UsersList()
        {
            AllUsers users = new AllUsers();
            List<User> teachers = _userManager.GetUsersInRoleAsync("Teacher").Result.ToList();
            List<User> students = _userManager.GetUsersInRoleAsync("Student").Result.ToList();
            List<Applications> allUsers = _applications.GetAll().ToList();
            
            foreach (var u in teachers)
            {
                users.allTeachers.Add(new _User(u.Id, u.UserName));
            }
            foreach (var u in students)
            {
                users.allStudents.Add(new _User(u.Id, u.UserName));
            }
            
            foreach (var item in allUsers)
            {
                string num;
                if (!item.IsTeacher) 
                {
                    num = item.StudentNumber;

                }
                else
                {
                    num = item.Nin;

                }
                users.unregisteredUsers.Add(new _applUser(item.Id, item.Name +" "+ item.Surname, item.Email,num));
                
            }
           
            return View(users);
        }
       
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
             _userManager.DeleteAsync(user).Wait();

            return RedirectToAction("UsersList", "Admin");
        }

        public async Task<IActionResult> DeleteApplication(int Id)
        {
            _applications.Delete(Id);
            return RedirectToAction("UsersList", "Admin");
        }
        public async Task<IActionResult> ApproveApplication(int Id)
        {
            var appl = _applications.GetById(Id);
            var user = _mapper.Map<User>(appl);
            var result = await _userManager.CreateAsync(user, appl.Password);
            await _signInManager.PasswordSignInAsync(appl.Email, appl.Password, false, false);
            if(appl.IsTeacher)
            {
                _userManager.AddToRoleAsync(user, "Teacher").Wait();
            }
            else
            {
                _userManager.AddToRoleAsync(user, "Students").Wait();
            }
            _applications.Delete(Id);
            await _emailService.SendEmailAsync(user.Email, "Реєстрація", "Вітаємо ви зареєстровані!!!");
            return RedirectToAction("UsersList", "Admin");

        }
    }
}