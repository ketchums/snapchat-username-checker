using System.Collections.Generic;
using OpenQA.Selenium;
using SnapUsernameChecker.Browser;

namespace SnapUsernameChecker
{
    public class SnapUsernameChecker
    {
        private readonly BrowserController _browserController;
        
        public SnapUsernameChecker(BrowserController browserController)
        {
            _browserController = browserController;
        }
        

        public SnapResult Check(string username)
        {
            TryLogin(username);

            if (!_browserController.TryWaitForElement(By.Id("error_message"), 5, out var error))
            {
                return new SnapResult(username, 1);
            }

            var errorMessage = error.GetAttribute("innerText");

            if (errorMessage == "Cannot find user.")
            {
                return new SnapResult(username, 2);
            }
            
            return errorMessage == "That's not the right password." ? new SnapResult(username, 3) : new SnapResult(username, 1);
        }

        private void TryLogin(string username)
        {
            _browserController.Navigate("https://accounts.snapchat.com/accounts/login");
            
            var usernameInput = _browserController.GetElement(By.Id("username"));
            var passwordInput = _browserController.GetElement(By.Id("password"));
            var submitButton = _browserController.GetElement(By.ClassName("btn-primary"));
            
            _browserController.SendKeysToElement(usernameInput, username);
            _browserController.SendKeysToElement(passwordInput, ".");
            
            _browserController.ClickElement(submitButton);
        }

        public List<SnapResult> CheckMany(IEnumerable<string> usernames)
        {
            var results = new List<SnapResult>();
            
            foreach (var username in usernames)
            {
                results.Add(Check(username));
            }

            return results;
        }
    }
}