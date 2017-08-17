using NUnit.Framework;
using TestCloudControl.PageObjects;
using TestCloudControl.WrapperFactory;
using System.Configuration;
using System.Net;

namespace TestCloudControl.TestCases
{
    public class GetTokenTest : BaseTest
    {
        //[Test]
        //[TestCaseSource("BrowserToRunWith")]
        public void GetToken (string browserName)
        {
            WebDriverFactory.InitDriver(browserName);
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);

            Page.Login.LoginToApplication("administrator", "Administrator_123");

        }
    }
}
