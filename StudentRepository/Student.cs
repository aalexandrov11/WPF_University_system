using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    public class Student
    {
        public String name;
        public String secondName;
        public String lastName;
        public String faculty;
        public String spec;
        public String eqDegree;
        public String status;//zaveril, semestrialno zavurshil ...
        public String facNum;
        public int course;
        public int stream;
        public int group;
        public DateTime lastSign;
        public DateTime lastPaid;

        public Student(String n, String sn, String ln, String f, String s, String eq, String st, String fn, int c, int str, int g)
        {
            this.name = n;
            this.secondName = sn;
            this.lastName = ln;
            this.faculty = f;
            this.spec = s;
            this.eqDegree = eq;
            this.status = st;
            this.facNum = fn;
            this.course = c;
            this.stream = str;
            this.group = g;
            }

        private String getDataZav()
        {
            String d;
            d = Convert.ToString(this.lastSign);
            return d;
        }

         private String getDataPaid()
         { 
            String d;
            d = Convert.ToString(this.lastPaid);
            return d;
         }
    }
}
