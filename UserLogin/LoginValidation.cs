using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    public class LoginValidation
    {
        private String username;
        private String password;
        private String errorMessage;
        public delegate void ActionOnError(String errorM);//D
        private ActionOnError errorMess;//tova e kato funkciq zaradi D

        public LoginValidation(String un, String pass, ActionOnError em)
        {
            this.username = un;
            this.password = pass;
            this.errorMess = em;
            currentUserName = un;
        }

        static public UserRoles currentUserRole
        {
            get;
            private set;
        }

        static public String currentUserName
        {
            get;
            private set;
        }

        public bool ValidateUserInput(ref User us)//(ref User us)
        {
            //us.username = UserData.testUser.username;
            //us.password = UserData.testUser.password;
            //us.facNum = UserData.testUser.facNum;
            //us.role = UserData.testUser.role;

            //us = UserData.testUsers;
            //currentUserRole = (UserRoles)us.role;
            //us = new User();
            //us = UserData.IsUserPassCorrect(us.username, us.password);

            bool emptyUserName;
            emptyUserName = username.Equals(String.Empty);
            if(emptyUserName == true || username.Length < 5)
            {
                errorMessage = "You have not entered a username or it is too short.";
                errorMess(errorMessage);
                currentUserRole = UserRoles.Anonymous;
                return false;
            }

            bool emptyUserPassword;
            emptyUserPassword = password.Equals(String.Empty);
            if(emptyUserPassword == true || password.Length < 5)
            {
                errorMessage = "You have not entered a password or it is too short.";
                errorMess(errorMessage);
                currentUserRole = UserRoles.Anonymous;
                return false;
            }

            User proverka = UserData.IsUserPassCorrect(username, password);
            //if(UserData.IsUserPassCorrect(us.username, us.password)is User)
            if (proverka != null)
            {
                us = proverka;
                //User found = UserData.IsUserPassCorrect(us.username, us.password);
                currentUserRole = (UserRoles)us.role;
                //currentUserName = us.username;
                Logger.LogActivity("Succesful login!");
                return true;

            }
            else
            {
                errorMessage = "There is no a such user!";
                errorMess(errorMessage);
                currentUserRole = UserRoles.Anonymous;
                return false;
            }
        }
    }
}
