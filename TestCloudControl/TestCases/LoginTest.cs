using NUnit.Framework;
using TestCloudControl.PageObjects;
using TestCloudControl.WrapperFactory;
using System.Configuration;
using System;

namespace TestCloudControl.TestCases
{
    [TestFixture]
    [Parallelizable]
    public class LoginTest : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowserToRunWith")]
        public void Login(string browserName)
        {
            WebDriverFactory.InitDriver(browserName);
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);

            Page.Login.LoginToApplication("", "Administrator_123");

            if (Page.Login.ValidateResultLogin(WebDriverFactory.Driver) == true)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Wrong msg!!!");
            };
        }

        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowserToRunWith")]
        public void VerifyEmail(string browserName)
        {
            WebDriverFactory.InitDriver(browserName);
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);

            Page.Login.LoginToApplication("", "Administrator_123");

            if (Page.Login.ValidateResultLogin(WebDriverFactory.Driver) == true)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Wrong msg!!!");
            };
        }

        [Test]
        [TestCaseSource(typeof(BaseTest), "BrowserToRunWith")]
        public void VerifyPassword(string browserName)
        {
            WebDriverFactory.InitDriver(browserName);
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);

            Page.Login.LoginToApplication("administrator", "Administrator_123");

            Page.Login.LoginToApplication("", "Administrator_123");

            if (Page.Login.ValidateResultLogin(WebDriverFactory.Driver) == true)
            {
                Console.Write("Success");
            }
            else
            {
                Console.Write("Wrong msg!!!");
            };
        }
    }
}
