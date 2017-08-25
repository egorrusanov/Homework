using NUnit.Framework;
using TestCloudControl.PageObjects;
using System.Configuration;
using System;

namespace TestCloudControl.TestCases
{
    [TestFixture]
    [Parallelizable]
    public class OpenObjectTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void OpenObject(string browserName)
        {
            WebDriverFactory.InitDriver(browserName);
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);

            LoginPage loginPage = PageFactory.GetLoginPage();
            loginPage.LoginToApplication(GetEmail(), GetPassword());

            WebDriverFactory.WaitForReady();

            if (!loginPage.SuccessLogin())
                throw new Exception("Не удалось авторизоваться.");

            MainPage mainPage = PageFactory.GetMainPage();
            string companyName = mainPage.GetCompanyName();
            mainPage.OpenObjects();

            ObjectsPage objectsPage = PageFactory.GetObjectsPage();

            objectsPage.SuccessLoadObjects(companyName);

            string objectName = objectsPage.GetObjectName();
            objectsPage.OpenObject();

            ObjectPage objectPage = PageFactory.GetObjectPage();
            objectPage.SuccessLoadObject(objectName);
        }
    }
}
