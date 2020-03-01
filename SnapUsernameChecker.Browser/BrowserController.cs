using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace SnapUsernameChecker.Browser
{
    public class BrowserController
    {
        private readonly IWebDriver _webDriver;

        public BrowserController(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void Navigate(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }
        
        public bool ElementExists(By selector)
        {
            try
            {
                return _webDriver.FindElement(selector) != null;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        public bool TryWaitForElement(By selector, int timeoutSeconds, out IWebElement element)
        {
            var started = DateTime.Now;

            while (!ElementExists(selector))
            {
                if ((DateTime.Now - started).TotalSeconds > timeoutSeconds)
                {
                    element = null;
                    return false;
                }

                Thread.Sleep(TimeSpan.FromMilliseconds(100));
            }

            element = _webDriver.FindElement(selector);
            return true;
        }

        public IWebElement GetElement(By by)
        {
            return _webDriver.FindElement(by);
        }

        public void SendKeysToElement(IWebElement element, string keys)
        {
            element.SendKeys(keys);
        }

        public void ClickElement(IWebElement element)
        {
            element.Click();
        }
    }
}