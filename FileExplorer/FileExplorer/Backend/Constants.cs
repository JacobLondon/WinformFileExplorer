using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public static string POWERSHELL = @"C:\Windows\System32\WindowsPowerShell\v1.0\powershell.exe";

        // all of the valid shortcuts
        public static List<string> VALID_SHORTCUTS = new List<string>()
        {
            "3D Objects",
            "Desktop",
            "Documents",
            "Downloads",
            "Music",
            "Pictures",
            "Videos"
        };

        // renaming a file may not contain these chars
        public static string INVALID_CHARS = "[<>:\"/\\\\|?*]";
        public static Regex INVALID_REGEX = new Regex(INVALID_CHARS);

        public static string TIME_FORMAT = "MM/dd/yyyy hh:mm tt";
        public static string NEW_FOLDER = "New folder";
    }
}
