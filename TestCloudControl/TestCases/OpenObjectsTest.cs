using NUnit.Framework;
using TestCloudControl.PageObjects;
using System.Configuration;
using System;

namespace TestCloudControl.TestCases
{
    [TestFixture]
    [Parallelizable]
    public class OpenObjectsTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void OpenObjects(string browserName)
        {
            WebDriverFactory.InitDriver(browserName);
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);

            LoginPage loginPage = PageFactory.GetLoginPage();

            loginPage.LoginToApplication(GetEmail(), GetPassword());

            WebDriverFactory.WaitForReady();

            if (!loginPage.SuccessLogin())
                throw new Exception("Не удалось авторизоваться.");

            MainPage mainPage = PageFactory.GetMainPage();
            string companyName = mainPage.GetTestCompanyName();
            mainPage.OpenTestCompany();

            ObjectsPage objectsPage = PageFactory.GetObjectsPage();

            objectsPage.SuccessLoadObjects(companyName);
        }
    }
}
