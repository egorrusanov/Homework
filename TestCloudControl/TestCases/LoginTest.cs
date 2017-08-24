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

            LoginPage loginPage = PageFactory.GetLoginPage();
            
            loginPage.LoginToApplication(GetEmail(), GetPassword());

            WebDriverFactory.WaitForReady();

            loginPage.SuccessLogin(WebDriverFactory.Driver);
        }
    }
}
