using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
    static public class Logger
    {
        static  private List<String> currentSessionActivities = new List<String>();

        static public void LogActivity(String activity)
        {
            String activityLane = DateTime.Now + "; " + LoginValidation.currentUserName + "; " + LoginValidation.currentUserRole + "; " + activity + "\n";
            currentSessionActivities.Add(activityLane);
            //Console.WriteLine(activityLane);
            if (File.Exists("D:/proekti/pops/PS_49_AA/UserLogin/test.txt"))
            {
                File.AppendAllText("D:/proekti/pops/PS_49_AA/UserLogin/test.txt", activityLane);
            }


        }

        public static void readAllLog()
        {
            string line;
            StreamReader sr = new StreamReader("D:/proekti/pops/PS_49_AA/UserLogin/test.txt");
            while ((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
                sr.Close();
        }

        //public static void GetCurrentSessionActivities()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("LOG: ");
        //    foreach(var log in currentSessionActivities)
        //    {
        //        sb.Append(log);
        //    }
        //    Console.WriteLine(sb.ToString());
        //}

        public static void GetCurrentSessionActivities(string filter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Current Session: ");
            List<string> filteredActivities = (from activity in currentSessionActivities where activity.Contains(filter) select activity).ToList();
            foreach (var action in filteredActivities)
            {
                sb.Append(action);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
