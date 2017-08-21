using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TestCloudControl.TestCases
{
    public class TestBase
    {
        public static IEnumerable<String> BrowserToRunWith()
        {
            String[] browsers = { "Chrome", "Firefox" };
            return browsers;
        }

        [TearDown]
        public void Close()
        {
            WebDriverFactory.CloseAllDrivers();
        }
    }
}
