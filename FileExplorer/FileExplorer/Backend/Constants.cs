using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Backend
{
    /// <summary>
    /// Put all constants here for reference
    /// </summary>
    public class Constants
    {
        // default root folder
        public static string USER_NAME = Environment.UserName;
        public static string ROOT = @"C:\Users\" + USER_NAME;

        public static string TIME_FORMAT = "MM/dd/yyyy hh:mm tt";
    }
}
