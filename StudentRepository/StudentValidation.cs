using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentRepository
{
    class StudentValidation
    {
        private Student GetStudentDataByUser(User u)
        {
            if (u.facNum == null)
            {
                Console.WriteLine("That user has not entered faculty number.\n");
                return null;
                //Environment.Exit(1);
            }
            for (int i = 0; i < StudentData.testStudents.Count; i++)
            {
                if (u.facNum == StudentData.testStudents[i].facNum)
                    return StudentData.testStudents[i];
                else
                {
                    Console.WriteLine("No user with that faculty number.");
                    return null;
                }
            }

            return null;
        }
    }
}
