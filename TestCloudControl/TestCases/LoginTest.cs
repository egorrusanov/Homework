using NUnit.Framework;
using TestCloudControl.PageObjects;
using System.Configuration;
using System;
using System.Collections.Generic;

namespace TestCloudControl.TestCases
{
    [TestFixture]
    [Parallelizable]
    public class LoginTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void Login(string browserName)
        {
            WebDriverFactory.InitDriver(browserName);
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);

            Page.Login.LoginToApplication("superadmin@x5test.ru", "&U*I9o");

            Page.Login.SuccessLogin(WebDriverFactory.Driver);
        }
    }
}
