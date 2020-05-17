using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plagiarism_Checker.Models.AdminDTO
{
    public class AllUsers
    {
        public List<_User> allTeachers= new List<_User>();
        public List<_User> allStudents = new List<_User>();
        public List<_User> unregisteredUsers = new List<_User>();
    }
    public class _User
    {
        public string id { get; set; }
        public string name { get; set; }

        public _User(string id,string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}
