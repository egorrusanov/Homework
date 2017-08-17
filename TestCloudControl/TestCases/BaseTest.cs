using System;
using System.Collections.Generic;
using NUnit.Framework;
using TestCloudControl.WrapperFactory;

namespace TestCloudControl.TestCases
{
    public class BaseTest
    {
        public static IEnumerable<String> BrowserToRunWith()
        {
            String[] browsers = { "Chrome", "Firefox", "IE" };
            foreach (string b in browsers)
            {
                yield return b;
            }
        }

        [TearDown]
        public void Close()
        {
            WebDriverFactory.CloseAllDrivers();
        }
    }
}
