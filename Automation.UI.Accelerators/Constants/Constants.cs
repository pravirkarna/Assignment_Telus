using System.IO;

namespace Automation.Ui.Accelerators.Constants
{
    public static class Constants
    {
        public const string URL = "https://www.saucedemo.com";
        public static string Path = Directory.GetCurrentDirectory();
        public static string NewPath = Path.Substring(0, Path.Length - 24) + "\\" + "Test Results" + "\\";
        public static string Username = "standard_user";
        public static string Password = "secret_sauce";
        public static string FirstName = "TestUser";
        public static string LastName = "123";
        public static string Postal = "122001";
    }
}