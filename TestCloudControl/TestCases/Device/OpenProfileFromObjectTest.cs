using NUnit.Framework;
using TestCloudControl.PageObjects;
using System.Configuration;
using System;
using TestCloudControl.PageObjects.Device;

namespace TestCloudControl.TestCases.Device
{
    [TestFixture]
    [Parallelizable]
    public class OpenProfileFromObjectTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void OpenProfileFromObject(string browserName)
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
            objectsPage.SelectPageSize(100);

            WebDriverFactory.WaitForReady();

            string objectName = objectsPage.GetObjectName();
            objectsPage.OpenObject();

            ObjectPage objectPage = PageFactory.GetObjectPage();
            objectPage.SuccessLoadObject(objectName);
            objectPage.OpenProfile();

            ProfilePage profileDevicePage = PageFactory.GetProfileDevicePage();

            profileDevicePage.SuccessLoadProfileDevice();
        }

    }
}
