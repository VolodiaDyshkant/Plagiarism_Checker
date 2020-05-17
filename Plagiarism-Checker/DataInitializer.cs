using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Plagiarism_Checker.Models;
using Plagiarism_Checker.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plagiarism_Checker
{
    public class DataInitializer
    {
        
        

        public static void SeedData(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, 
            IRepository<StudentLesson> student_Lesson, IRepository<Lesson> lesson, 
            IRepository<Models.Task> task, IRepository<Assignment> assignment,
            IRepository<Schedule> schedule, IRepository<Discipline> discipline, 
            IRepository<Time> time, IRepository<Day> day, IRepository<Group> group)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
            SeedGroups(group);
            //SeedDDiscipline();
            //SeedTimes();
            //SeedDays();
            //SeedSchedule();
            //SeedAssignment();

        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Student").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Student";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Teacher").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Teacher";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }

        public static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                User user = new User();
                user.UserName = "Admin";
                user.Email = "admin@gmail.com";

                IdentityResult result = userManager.CreateAsync(user, "Admin007").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByNameAsync("Ashot").Result == null)
            {
                User user = new User();
                user.UserName = "Ashot";
                user.Email = "ashot@gmail.com";

                IdentityResult result = userManager.CreateAsync(user, "Ashot001").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Teacher").Wait();
                }
            }

            if (userManager.FindByNameAsync("Mustafa").Result == null)
            {
                User user = new User();
                user.UserName = "Mustafa";
                user.Email = "mustafa@gmail.com";

                IdentityResult result = userManager.CreateAsync(user, "Mustafa001").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Teacher").Wait();
                }
            }

            if (userManager.FindByNameAsync("Tamara").Result == null)
            {
                User user = new User();
                user.UserName = "Tamara";
                user.Email = "tamara@gmail.com";

                IdentityResult result = userManager.CreateAsync(user, "Tamara001").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Teacher").Wait();
                }
            }

            if (userManager.FindByNameAsync("Aramat").Result == null)
            {
                User user = new User();
                user.UserName = "Aramat";
                user.Email = "aramat@gmail.com";

                IdentityResult result = userManager.CreateAsync(user, "Aramat001").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Student").Wait();
                }
            }

            if (userManager.FindByNameAsync("Aslan").Result == null)
            {
                User user = new User();
                user.UserName = "Aslan";
                user.Email = "aslan@gmail.com";

                IdentityResult result = userManager.CreateAsync(user, "Aslan001").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Student").Wait();
                }
            }

            if (userManager.FindByNameAsync("Mahmud").Result == null)
            {
                User user = new User();
                user.UserName = "Mahmud";
                user.Email = "mahmud@gmail.com";

                IdentityResult result = userManager.CreateAsync(user, "Mahmud001").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Student").Wait();
                }
            }

        }

        public static void SeedGroups(IRepository<Group> group)
        {
            var id1 = "5f361bec-fc51-4b5b-8059-94c19ae8bd80";
            var id2 = "5b6377fe-da9c-409d-9d8b-22f182c464ea";
            var id3 = "54ce0186-703e-4716-a770-0b8a24b79820";
            group.Insert(new Group { Name = "PMP-32", StudentId = id1 });
            group.Insert(new Group { Name = "PMP-32", StudentId = id2 });
            group.Insert(new Group { Name = "PMP-32", StudentId = id3 });
            //using (UniverContext uc = new UniverContext())
            //{
            //    //if (uc.Group.FirstOrDefault(g => g.Name == "PMP-32") == null)
            //    //{
            //        var id1 = uc.User.FirstOrDefault(u => u.UserName == "Aslan").Id;
            //        var id2 = uc.User.FirstOrDefault(u => u.UserName == "Mahmud").Id;
            //        var id3 = uc.User.FirstOrDefault(u => u.UserName == "Aramat").Id;
            //        Group[] groups = { new Group { Name = "PMP-32", StudentId = id1 }, new Group { Name = "PMP-32", StudentId = id2 }, new Group { Name = "PMP-32", StudentId = id3 } };
            //        uc.Group.AddRange(groups);
            //        uc.SaveChanges();
            //    //}
            //}

        }

        public static void SeedDDiscipline()
        {
            using (UniverContext uc = new UniverContext())
            {
                if (uc.Discipline.FirstOrDefault(d => d.Name == ".net") == null)
                {
                    uc.Discipline.Add(new Discipline { Name = ".net" });
                    uc.SaveChanges();
                }

                if (uc.Discipline.FirstOrDefault(d => d.Name == "numerical methods") == null)
                {
                    uc.Discipline.Add(new Discipline { Name = "numerical methods" });
                    uc.SaveChanges();
                }

                if (uc.Discipline.FirstOrDefault(d => d.Name == "dynamic systems") == null)
                {
                    uc.Discipline.Add(new Discipline { Name = "dynamic systems" });
                    uc.SaveChanges();
                }

                if (uc.Discipline.FirstOrDefault(d => d.Name == "operating systems") == null)
                {
                    uc.Discipline.Add(new Discipline { Name = "operating systems" });
                    uc.SaveChanges();
                }
            }

        }

        public static void SeedTimes()
        {
            using (UniverContext uc = new UniverContext())
            {
                if (uc.Time.FirstOrDefault() == null)
                {
                    Time time1 = new Time { Time1 = new TimeSpan(0, 1, 0, 0) };
                    Time time2 = new Time { Time1 = new TimeSpan(0, 2, 0, 0) };
                    Time time3 = new Time { Time1 = new TimeSpan(0, 3, 0, 0) };
                    Time time4 = new Time { Time1 = new TimeSpan(0, 4, 0, 0) };
                    Time time5 = new Time { Time1 = new TimeSpan(0, 5, 0, 0) };
                    Time time6 = new Time { Time1 = new TimeSpan(0, 6, 0, 0) };
                    Time time7 = new Time { Time1 = new TimeSpan(0, 7, 0, 0) };
                    uc.Time.AddRange(new List<Time> { time1, time2, time3, time4, time5, time6, time7 });
                    uc.SaveChanges();
                }

            }

        }

        public static void SeedDays()
        {
            using (UniverContext uc = new UniverContext())
            {
                if (uc.Day.FirstOrDefault(g => g.Day1 == "Monday") == null)
                {
                    uc.Day.Add(new Day { Day1 = "Monday" });
                    uc.SaveChanges();
                }

                if (uc.Day.FirstOrDefault(g => g.Day1 == "Tuesday") == null)
                {
                    uc.Day.Add(new Day { Day1 = "Tuesday" });
                    uc.SaveChanges();
                }

                if (uc.Day.FirstOrDefault(g => g.Day1 == "Wednesday") == null)
                {
                    uc.Day.Add(new Day { Day1 = "Wednesday" });
                    uc.SaveChanges();
                }

                if (uc.Day.FirstOrDefault(g => g.Day1 == "Thursday") == null)
                {
                    uc.Day.Add(new Day { Day1 = "Thursday" });
                    uc.SaveChanges();
                }

                if (uc.Day.FirstOrDefault(g => g.Day1 == "Friday") == null)
                {
                    uc.Day.Add(new Day { Day1 = "Friday" });
                    uc.SaveChanges();
                }

                if (uc.Day.FirstOrDefault(g => g.Day1 == "Saturday") == null)
                {
                    uc.Day.Add(new Day { Day1 = "Saturdayy" });
                    uc.SaveChanges();
                }

                if (uc.Day.FirstOrDefault(g => g.Day1 == "Sunday") == null)
                {
                    uc.Day.Add(new Day { Day1 = "Sunday" });
                    uc.SaveChanges();
                }
            }

        }

        public static void SeedSchedule()
        {
            using (UniverContext uc = new UniverContext())
            {
                //if (uc.Schedule.FirstOrDefault() == null)
                //{

                    var id1 = uc.User.FirstOrDefault(u => u.UserName == "Ashot").Id;
                    var id2 = uc.User.FirstOrDefault(u => u.UserName == "Tamara").Id;
                    var id3 = uc.User.FirstOrDefault(u => u.UserName == "Mustafa").Id;
                    Schedule schedule1 = new Schedule { TeacherId = id1, GroupId = 1, DisciplineId = 1, DayId = 1, TimeId = 1 };
                    Schedule schedule2 = new Schedule { TeacherId = id1, GroupId = 1, DisciplineId = 1, DayId = 3, TimeId = 4 };
                    Schedule schedule3 = new Schedule { TeacherId = id1, GroupId = 1, DisciplineId = 1, DayId = 5, TimeId = 2 };
                    Schedule schedule4 = new Schedule { TeacherId = id1, GroupId = 1, DisciplineId = 1, DayId = 3, TimeId = 4 };
                    Schedule schedule5 = new Schedule { TeacherId = id2, GroupId = 1, DisciplineId = 2, DayId = 2, TimeId = 3 };
                    Schedule schedule6 = new Schedule { TeacherId = id2, GroupId = 1, DisciplineId = 2, DayId = 3, TimeId = 7 };
                    Schedule schedule7 = new Schedule { TeacherId = id2, GroupId = 1, DisciplineId = 3, DayId = 4, TimeId = 5 };
                    Schedule schedule8 = new Schedule { TeacherId = id2, GroupId = 1, DisciplineId = 3, DayId = 6, TimeId = 6 };
                    Schedule schedule9 = new Schedule { TeacherId = id3, GroupId = 1, DisciplineId = 4, DayId = 1, TimeId = 3 };
                    Schedule schedule10 = new Schedule { TeacherId = id3, GroupId = 1, DisciplineId = 4, DayId = 2, TimeId = 5 };
                    Schedule schedule11 = new Schedule { TeacherId = id3, GroupId = 1, DisciplineId = 4, DayId = 3, TimeId = 6 };
                    Schedule schedule12 = new Schedule { TeacherId = id3, GroupId = 1, DisciplineId = 4, DayId = 4, TimeId = 1 };
                    uc.Schedule.AddRange(new List<Schedule> { schedule1, schedule2, schedule3, schedule4, schedule5, schedule6, schedule7, schedule8, schedule9, schedule10, schedule11, schedule12, });
                    uc.SaveChanges();
                //}
            }
        }



        public static void SeedAssignment()
        {
            using (UniverContext uc = new UniverContext())
            {
                //if (uc.Assignment.FirstOrDefault() == null)
                //{
                DateTime dt1 = new DateTime(2020, 05, 25);
                Assignment assignment1 = new Assignment { Deadline = dt1, Requirenments = "test1" };
                DateTime dt2 = new DateTime(2020, 05, 26);
                Assignment assignment2 = new Assignment { Deadline = dt2, Requirenments = "test2" };
                DateTime dt3 = new DateTime(2020, 05, 27);
                Assignment assignment3 = new Assignment { Deadline = dt3, Requirenments = "test3" };
                DateTime dt4 = new DateTime(2020, 05, 28);
                Assignment assignment4 = new Assignment { Deadline = dt4, Requirenments = "test4" };
                DateTime dt5 = new DateTime(2020, 05, 29);
                Assignment assignment5 = new Assignment { Deadline = dt5, Requirenments = "test5" };
                DateTime dt6 = new DateTime(2020, 05, 30);
                Assignment assignment6 = new Assignment { Deadline = dt6, Requirenments = "homework1" };
                DateTime dt7 = new DateTime(2020, 05, 31);
                Assignment assignment7 = new Assignment { Deadline = dt7, Requirenments = "homework2" };
                DateTime dt8 = new DateTime(2020, 06, 01);
                Assignment assignment8 = new Assignment { Deadline = dt8, Requirenments = "homework3" };
                DateTime dt9 = new DateTime(2020, 06, 02);
                Assignment assignment9 = new Assignment { Deadline = dt9, Requirenments = "homework4" };
                DateTime dt10 = new DateTime(2020, 06, 03);
                Assignment assignment10 = new Assignment { Deadline = dt10, Requirenments = "homework5" };
                uc.Assignment.AddRange(new List<Assignment> { assignment1, assignment2, assignment3, assignment4, assignment5, assignment6, assignment7, assignment8, assignment9, assignment10, });
                uc.SaveChanges();
                //}
            }


        }
    }

}