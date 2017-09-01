using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Configuration;

namespace TestCloudControl.TestCases
{
    public class TestBase
    {
        public string GetEmail()
        {
            return ConfigurationManager.AppSettings["email"];
        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings["password"];
        }

        public static IEnumerable<String> BrowserToRunWith()
        {
            String[] browsers =
                {
                    "Chrome",
                    "Firefox",
                    "IE"
                };
            return browsers;
        }
        
        [TearDown]
        public void Close()
        {
            WebDriverFactory.CloseAllDrivers();
        }
    }
}
