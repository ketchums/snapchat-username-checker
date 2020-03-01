using System;

namespace SnapUsernameChecker
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var checker = new SnapUsernameChecker();
            var usernameToCheck = Console.ReadLine();

            Console.WriteLine(SnapUsernameChecker.Check(usernameToCheck).Exists ? 
                "This username exists" : 
                "This username doesn't exist.");
            
            Console.ReadLine();
        }
    }
}