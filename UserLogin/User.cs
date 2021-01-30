using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public enum Role {Administrator = 1, Inspector, Teacher, Student};

    public class User
    {
        public String username;
        public String password;
        public String facNum;
        public int role;// { Administrator = 1, Inspector, Teacher, Student };
        public DateTime created;
        public DateTime activeTill;
        //public User(String u, String p, String fn, int r, DateTime c, DateTime a)
        //{
        //    this.username = u;
        //    this.password = p;
        //    this.facNum = fn;
        //    this.role = r;
        //    this.created = c;
        //    this.activeTill = a;
        //}
    }
}
