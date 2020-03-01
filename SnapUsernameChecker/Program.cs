using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SnapUsernameChecker.Browser;

namespace SnapUsernameChecker
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var chromeOptions = new FirefoxOptions();

            if (!Debugger.IsAttached)
            {
                // chromeOptions.AddArgument("-headless");
            }

            var webDriver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                chromeOptions);
            var browser = new BrowserController(webDriver);
            
            var checker = new SnapUsernameChecker(browser);
            var usernameToCheck = Console.ReadLine();

            switch (checker.Check(usernameToCheck).Result)
            {
                case 1:
                    Console.WriteLine("This username couldn't be checked.");
                    break;
                case 2:
                    Console.WriteLine("This username exists");
                    break;
                case 3:
                    Console.WriteLine("This username is free");
                    break;
            }
            
            Console.ReadLine();
        }
    }
}