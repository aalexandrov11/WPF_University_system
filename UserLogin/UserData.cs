using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static public class UserData
    {
        //private static User[] _testUsers = new User[3];
        //public static User[] testUsers
        private static List<User> _testUsers = new List<User>();
        public static List<User> testUsers
        {
            get{
                resetTestUserData();
                return _testUsers;
            }
            set{ }
        }


        static public void resetTestUserData()
        {
            //_testUsers[0] = new User()
            //{
            //    username = "Krasi1",
            //    password = "123a1",
            //    facNum = "981276345",
            //    role = (int)Role.Administrator,
            //    created = DateTime.Now,
            //    activeTill = DateTime.MaxValue
            //};

            _testUsers.Add(new User
            {
                username = "Krasi1",
                password = "123a1",
                facNum = "981276345",
                role = (int)Role.Administrator,
                created = DateTime.Now,
                activeTill = DateTime.MaxValue
            });

            //_testUsers[1] = new User//prepravqme go sus add
            _testUsers.Add(new User
            {
                username = "Bobi2",
                password = "123a2",
                facNum = "123456789",
                role = (int)Role.Student,
                created = DateTime.Now,
                activeTill = DateTime.MaxValue
            });

            //_testUsers[2] = new User()//prepravqme go sus add
            _testUsers.Add(new User
            {
                username = "Dancho3",
                password = "123a3",
                facNum = "987654321",
                role = (int)Role.Student,
                created = DateTime.Now,
                activeTill = DateTime.MaxValue
            });

            //_testUsers.Add(new User{username = "Krasi1",password = "123a1",facNum = "981276345",role = (int)Role.Administrator,created = DateTime.Now,activeTill = DateTime.MaxValue});

            ////_testUsers[1] = new User//prepravqme go sus add
            //_testUsers.Add(new User{username = "Bobi2",password = "123a2",facNum = "123456789",role = (int)Role.Student,created = DateTime.Now,activeTill = DateTime.MaxValue});

            ////_testUsers[2] = new User()//prepravqme go sus add
            //_testUsers.Add(new User{username = "Dancho3",password = "123a3",facNum = "987654321",role = (int)Role.Student,created = DateTime.Now,activeTill = DateTime.MaxValue});
        }

        public static User IsUserPassCorrect(String userN, String passW)
        {
            //String userN;
            //String passW;

            //for (int i = 0; i < _testUsers.Length; i++)
            //{
            //    if (testUsers[i].username == userN && testUsers[i].password == passW)
            //        return testUsers[i];
            //    //else
            //        //return null; bez nego zashtoto break-va fora
            //}


            //foreach(User u in testUsers)
            //{
            //    if (u.username == userN && u.password == passW)
            //        return u;
            //}
            List<User> lu = (from u in testUsers where u.username == userN && u.password == passW select u).ToList();
            //User user1 = lu[0];
            if(lu.Any() == true)
            return lu[0];
            else
            return null;//ako lenght na masiva = 0
        }

        public static void SetUserActiveTo(/*String*/int userName, DateTime newActivity)
        {
            //for(int i = 0; i<testUsers.Count; i++)
            //{
            //    //if (testUsers[i].username == userName)
            //    if (i == userName)
            //    {
            //        testUsers[i].activeTill = newActivity;
            //        Logger.LogActivity("Changed activity of " + userName);
            //    }
            //}
            testUsers[userName].activeTill = newActivity;
            Logger.LogActivity("Changed activity of " + userName);

        }

        public static void AssignUserRole(/*String*/int userName, UserRoles newUserRole)
        {
            //for (int i = 0; i < testUsers.Count; i++)
            //{
            //    //if (testUsers[i].username == userName)
            //    if (i == userName)
            //    {
            //        testUsers[i].role = (int)newUserRole;
            //        Logger.LogActivity("Changed role of " + userName);
            //    }
            //}
            testUsers[userName].role = (int)newUserRole;
            Logger.LogActivity("Changed role of " + userName);
        }

        public static Dictionary<String, int> AllUsersUsernames()
        {
            Dictionary<String, int> result = new Dictionary<String, int>();

            for (int i = 0; i < _testUsers.Count/*testUsers.Count*/; i++)
            {
                result.Add(_testUsers[i].username, i);
            }
            return result;
        }
    }
}
