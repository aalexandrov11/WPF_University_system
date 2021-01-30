using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.// Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.//Console.WriteLine("Hello World!");//Console.ReadKey();// Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
            //User u1 = new User()
            //{
            //    username = "Krasi",
            //    password = "123a",
            //    facNum = "981276345",
            //    role = (int)Role.Administrator
            //};
            //UserData.resetTestUserData();
            Console.WriteLine("Enter name: ");
            String name = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            String password = Console.ReadLine();
            Console.WriteLine();

            LoginValidation test = new LoginValidation(name, password, errorMessageFunction);
            User user3 = null;
            if(test.ValidateUserInput(ref user3) == true)
            {
                //Console.WriteLine("Name = {0}, password = {1}, faculty number = {2}, role = {3}", UserData.testUser.username, UserData.testUser.password, UserData.testUser.facNum, UserData.testUser.role);
                Console.WriteLine("Name = {0}, password = {1}, faculty number = {2}, role = {3}", user3.username, user3.password, user3.facNum, user3.role);
                //Console.WriteLine(LoginValidation.currentUserRole);
                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.Admin:
                        Console.WriteLine("This User is Administrator!"); break;
                    case UserRoles.Inspector:
                        Console.WriteLine("This User is a Inspector!"); break;
                    case UserRoles.Professor:
                        Console.WriteLine("This User is a Professor!"); break;
                    case UserRoles.Student:
                        Console.WriteLine("This User is a Student!"); break;
                    case UserRoles.Anonymous:
                        Console.WriteLine("This User is Anonymous!"); break;
                }

                //public delegate void ActionOnError(String errorM);

                //Console.WriteLine();
                //Console.WriteLine(u1.username, " ",u1.password, " ", u1.facNum, " ", u1.role);
                //Console.ReadKey();
            }

            void errorMessageFunction(String msg)
            {
                Console.WriteLine("!!!Error!!! " + msg);
                Console.ReadKey();
            }

            if (LoginValidation.currentUserRole == UserRoles.Admin)
            {
                AdministratorPanel();
                
                //Console.WriteLine("Choose an option:" + "\n" + "0: Exit" + "\n" + "1: Change User Role" + "\n" + "2: Change User Activity");
                //int num;
                //num = Convert.ToInt32(Console.ReadLine());
                //switch (num)
                //{
                //    case 0:
                //        break;
                //    case 1:
                //        UserData.AssignUserRole(Console.ReadLine(), (UserRoles)Convert.ToInt32(Console.ReadLine())); break;
                //    case 2:
                //        UserData.SetUserActiveTo(Console.ReadLine(), Convert.ToDateTime(Console.ReadLine())); break;

                //}
            }


            Console.ReadKey();
            //Console.WriteLine("Name = {0}, password = {1}, faculty number = {2}, role = {3}", u1.username, u1.password, u1.facNum, u1.role);
            ////Console.WriteLine();
            ////Console.WriteLine(u1.username, " ",u1.password, " ", u1.facNum, " ", u1.role);
            //Console.ReadKey();
            //DateTime dt = new DateTime(2017, 9, 15, 10, 30, 0);//6 tip konstruktor y/m/d/h/m/s
            //int h = dt.Hour;// vzima chasa ot gornoto
            //DateTime dt = DateTime.Now;//vzima vremeto koeto e v momenta
            //int n = dt.Hour;//vzima chasa koito teche v momenta zaradi Now
            //Console.WriteLine(n);
            //Console.ReadKey();
            //DateTime dt = DateTime.Now;
            //int nextDay = dt.AddHours(14).Day;
            //Console.WriteLine(nextDay);//namirame koq data shte e sled 14 chasa
            //Console.ReadKey();
            //String data1 = Console.ReadLine();
            //DateTime d = Convert.ToDateTime(data1);//konvertira string na data
            //Console.WriteLine(d);
            //Console.ReadKey();
        }

        public static void AdministratorPanel()
        {
            Console.WriteLine("Choose an option:" + "\n" + "0: Exit" + "\n" + "1: Change User Role" + "\n" + "2: Change User Activity" + "\n" + "3: List of users" + "\n" + "4: Check LOG" + "\n" + "5: Check current LOG");
            int num;
            num = Convert.ToInt32(Console.ReadLine());
            Dictionary<String, int> allUsers = UserData.AllUsersUsernames();
            string userToEdit;
            switch (num)
            {
                case 0:
                    Environment.Exit(0); break;
                case 1:
                    //UserData.AssignUserRole(Console.ReadLine(), (UserRoles)Convert.ToInt32(Console.ReadLine())); break;
                    userToEdit = Console.ReadLine();
                    UserRoles newUserRole = (UserRoles)Convert.ToInt32(Console.ReadLine());
                    UserData.AssignUserRole(allUsers[userToEdit], newUserRole);
                    break;
                case 2:
                    //UserData.SetUserActiveTo(Console.ReadLine(), Convert.ToDateTime(Console.ReadLine())); break;
                    userToEdit = Console.ReadLine();
                    DateTime newActDate = Convert.ToDateTime(Console.ReadLine());
                    UserData.SetUserActiveTo(allUsers[userToEdit], newActDate);
                    break;

                case 3:
                    //Dictionary<String, int> allUsers = UserData.AllUsersUsernames();
                    foreach(KeyValuePair<String, int> userOut in allUsers)
                    {
                        Console.WriteLine(userOut.Key);
                    }
                    break;

                case 4:
                    Logger.readAllLog();
                    break;

                case 5:
                    Console.WriteLine("Enter filter:");
                    String filter = Console.ReadLine();
                    Logger.GetCurrentSessionActivities(filter);
                    break;
            }
        }
    }
}
