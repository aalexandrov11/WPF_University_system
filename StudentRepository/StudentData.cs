using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StudentRepository
{
    public class StudentData
    {
        private static List<Student> _testStudents = new List<Student>();
        public static List<Student> testStudents
        {
            get
            {
                fillStudents();
                return _testStudents;
            }

            private set { }
        }

        static private void fillStudents()
        {
            _testStudents.Add(new Student("Iliq", "Iliev", "Iliev", "FT", "Telecommunications", "Bakalavar", "zaveril", "141516171", 3, 8, 40));
            _testStudents.Add(new Student("Matrin", "Ivanov", "Georgiev", "FM", "Machine Building", "Bakalavar", "semestrialno zavusrshil", "192031413", 1, 7, 39));
            _testStudents.Add(new Student("Dimitar", "Asenov", "Cenev", "FKST", "ITI", "Bakalavar", "zaveril", "234959879", 2, 6, 38));
        }

        public static Student isThereStudent(String facN)
        {
            List<Student> listSt = (from students in testStudents where students.facNum == facN select students).ToList();
            if (listSt.Any() == true)
                return listSt[0];
            else
                return null;
        }
        
        public static void PrepareCertificate()
        {
            Student stud = isThereStudent(Console.ReadLine());
            if (stud != null)
            {
                String uverenie = stud.name + " " + stud.lastName + "\nFacNum: " + stud.facNum + "\nCourse: " + stud.course + ", stream: " + stud.stream + ", group: " + stud.group + "\nLast taken course: " + (stud.course - 1) + "\n";
                Console.WriteLine(uverenie);
                if (stud.course > 2)
                    SaveCertificate(uverenie);
            }
            else
                Console.WriteLine("There is no a such student!");
        }

        public static void SaveCertificate(String info)
        {
            if (File.Exists("D:/proekti/pops/PS_49_AA/StudentRepository/ExportFile.txt"))
                File.WriteAllText("D:/proekti/pops/PS_49_AA/StudentRepository/ExportFile.txt", info);
        }
    }
}
