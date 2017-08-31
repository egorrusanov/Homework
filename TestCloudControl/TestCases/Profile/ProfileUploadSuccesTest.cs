using NUnit.Framework;
using TestCloudControl.PageObjects;
using System.Configuration;
using TestCloudControl.PageObjects.Device;
using System.Collections;

namespace TestCloudControl.TestCases.Device.Profile
{
    [TestFixture]
    [Parallelizable]
    public class ProfileUploadSuccesTest : TestBase
    {
        private const string SAVE_SUCCESS = "Профиль успешно сохранен";
        public static IEnumerable GetTestCases
        {
            get
            {
                foreach (string browserName in BrowserToRunWith())
                {
                    yield return new TestCaseData(browserName).Returns(SAVE_SUCCESS);
                }
            }
        }

        [Test]
        [TestCaseSource(nameof(GetTestCases))]
        public string ProfileUploadSucces(string browserName)
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

            profileDevicePage.UploadProfile();

            WebDriverFactory.WaitForReady();

            profileDevicePage.BrowseFile();

            return profileDevicePage.ValidateResultSave();
        }
    }
}
