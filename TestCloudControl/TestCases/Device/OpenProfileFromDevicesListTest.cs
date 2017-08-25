using NUnit.Framework;
using TestCloudControl.PageObjects;
using System.Configuration;
using System;
using TestCloudControl.PageObjects.Device;

namespace TestCloudControl.TestCases.Device
{
    [TestFixture]
    [Parallelizable]
    public class OpenProfileFromDevicesListTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void OpenProfileFromDevicesList(string browserName)
        {
            string deviceName = "";

            WebDriverFactory.InitDriver(browserName);
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);

            LoginPage loginPage = PageFactory.GetLoginPage();

            loginPage.LoginToApplication(GetEmail(), GetPassword());

            WebDriverFactory.WaitForReady();

            loginPage.SuccessLogin();

            MainPage mainPage = PageFactory.GetMainPage();

            mainPage.OpenDevicesList();

            DevicesPage devicesPage = PageFactory.GetDevicesPage();

            if (devicesPage.SuccessLoadModemList() && devicesPage.SuccessLoadDevicesTable())
            {
                deviceName = devicesPage.GetFirstDeviceName();
                devicesPage.OpenFirstDeviceLink();
            }

            DashboardPage dashboardPage = PageFactory.GetDashboardDevicePage();

            if (dashboardPage.SuccessLoadDevice(deviceName) && dashboardPage.SuccessLoadDashboard())
                dashboardPage.OpenProfile();

            ProfilePage profileDevicePage = PageFactory.GetProfileDevicePage();

            profileDevicePage.SuccessLoadProfileDevice();

        }

    }
}
