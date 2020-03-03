using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
	public static class Logger
	{
		static public List<String> currentSessionActivities = new List<String>();

		private const String LOG_FILE_PATH = "C:\\Users\\Hristo\\Desktop\\Ico _ Bobi\\log.txt";

		public static void logActivity(String activity)
		{
			string activityLine = DateTime.Now + ";"
			+ LoginValidation.username + ";"
			+ LoginValidation.currentUserRole + ";"
			+ activity;

			currentSessionActivities.Add(activityLine);
		}

		public static void saveLogToFile()
		{
			StringBuilder sb = new StringBuilder();
			
			foreach (String log in currentSessionActivities)
			{
				sb.Append(log);
				sb.Append(Environment.NewLine);
			}

			if (File.Exists(LOG_FILE_PATH) == false)
			{
				File.WriteAllText(LOG_FILE_PATH, sb.ToString());
			} else
			{
				File.AppendAllText(LOG_FILE_PATH, sb.ToString());
			}
		}

		public static void displayLogs()
		{
			string[] lines = File.ReadAllLines(LOG_FILE_PATH);

			foreach(String line in lines)
			{
				Console.WriteLine(line);
			}
		}
	}
}
