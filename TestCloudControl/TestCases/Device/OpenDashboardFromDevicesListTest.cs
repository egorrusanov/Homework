using NUnit.Framework;
using TestCloudControl.PageObjects;
using System.Configuration;
using System;
using TestCloudControl.PageObjects.Device;

namespace TestCloudControl.TestCases.Device
{
    [TestFixture]
    [Parallelizable]
    public class OpenDashboardFromDevicesListTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void OpenDashboardFromDevicesList(string browserName)
        {
            string deviceName = "";

            WebDriverFactory.InitDriver(browserName);
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);

            LoginPage loginPage = PageFactory.GetLoginPage();

            loginPage.LoginToApplication(GetEmail(), GetPassword());

            WebDriverFactory.WaitForReady();

            if (loginPage.SuccessLogin(WebDriverFactory.Driver) == false)
                throw new Exception("Не удалось авторизоваться.");

            MainPage mainPage = PageFactory.GetMainPage();

            mainPage.OpenDevicesList();

            WebDriverFactory.WaitForReady();
            DevicesPage devicesPage = PageFactory.GetDevicesPage();

            if (devicesPage.SuccessLoadModemList() && devicesPage.SuccessLoadDevicesTable())
            {
                deviceName = devicesPage.GetFirstDeviceName();
                devicesPage.OpenFirstDeviceLink();
            }     

            WebDriverFactory.WaitForReady();
            DashboardPage dashboardPage = PageFactory.GetDashboardDevicePage();

            dashboardPage.SuccessLoadDevice(deviceName);
            dashboardPage.SuccessLoadDashboard();
        }

    }
}
