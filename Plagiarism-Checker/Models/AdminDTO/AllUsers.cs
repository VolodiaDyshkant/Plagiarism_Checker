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
        public List<_applUser> unregisteredUsers = new List<_applUser>();
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
    public class _applUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }


        public _applUser(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public _applUser(int id, string name, string email, string number) : this(id, name)
        {
            Email = email;
            Number = number;
        }
    }
}
