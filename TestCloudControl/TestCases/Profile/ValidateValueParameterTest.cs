using NUnit.Framework;
using TestCloudControl.PageObjects;
using System.Configuration;
using TestCloudControl.PageObjects.Device;
using System.Collections;
using System;

namespace TestCloudControl.TestCases.Device.Profile
{
    [TestFixture]
    [Parallelizable]
    public class ValidateValueParameterTest : TestBase
    {        
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void ValidateValueParameter(string browserName)
        {
            WebDriverFactory.InitDriver(browserName);
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);

            LoginPage loginPage = PageFactory.GetLoginPage();
            loginPage.LoginToApplication(GetEmail(), GetPassword());

            WebDriverFactory.WaitForReady();

            loginPage.SuccessLogin();
            
            MainPage mainPage = PageFactory.GetMainPage();
            string companyName = mainPage.GetTestCompanyName();
            mainPage.OpenTestCompany();

            ObjectsPage objectsPage = PageFactory.GetObjectsPage();

            objectsPage.SuccessLoadObjects(companyName);

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
