using NUnit.Framework;
using TestCloudControl.PageObjects;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Collections;

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
            string deviceName;

            WebDriverFactory.InitDriver(browserName);
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);

            LoginPage loginPage = PageFactory.GetLoginPage();
            MainPage mainPage = PageFactory.GetMainPage();
            DevicesPage devicesPage = PageFactory.GetDevicesPage();
            DevicePage devicePage = PageFactory.GetDevicePage();

            loginPage.LoginToApplication("superadmin@x5test.ru", "xW%fEseSJCD1");

            if (loginPage.SuccessLogin(WebDriverFactory.Driver) == false)
                throw new Exception("Не удалось авторизоваться.");

            WebDriverFactory.WaitForReady();

            mainPage.OpenDevicesList();

            WebDriverFactory.WaitForReady();

            if (devicesPage.SuccessLoadModemList() && devicesPage.SuccessLoadDevicesTable())
                devicesPage.OpenFirstDeviceLink();
                //WebDriverFactory.Driver.Navigate().GoToUrl(devicesPage.GetFirstDeviceLink());

            deviceName = devicesPage.DevicesRow[0].Text;

            WebDriverFactory.WaitForReady();

            if (devicePage.SuccessLoadDevice(deviceName))
                devicePage.OpenProfile();
        }

    }
}
