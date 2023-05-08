using System.IO;

namespace Automation.Ui.Accelerators.Constants
{
    public static class Constants
    {
        public const string URL = "http://the-internet.herokuapp.com/dynamic_controls";
        public static string Path = Directory.GetCurrentDirectory();
        public static string NewPath = Path.Substring(0, Path.Length - 24) + "\\" + "Test Results" + "\\";
    }
}