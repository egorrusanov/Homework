﻿using OpenQA.Selenium.Support.PageObjects;

namespace TestCloudControl.PageObjects
{
    public static class PageFactory
    {
        private static T GetPage<T>() where T : new()
        {
            WebDriverFactory.WaitForReady();
            var page = new T();
            OpenQA.Selenium.Support.PageObjects.PageFactory.InitElements(WebDriverFactory.Driver, page);
            return page;
        }

        public static LoginPage GetLoginPage()
        {
            return GetPage<LoginPage>();
        }

        public static MainPage GetMainPage()
        {
            return GetPage<MainPage>();
        }

        public static DevicesPage GetDevicesPage()
        {
            return GetPage<DevicesPage>();
        }

        public static DevicePage GetDevicePage()
        {
            return GetPage<DevicePage>();
        }

        public static Device.ProfilePage GetProfileDevicePage()
        {
            return GetPage<Device.ProfilePage>();
        }

        public static Device.DashboardPage GetDashboardDevicePage()
        {
            return GetPage<Device.DashboardPage>();
        }

        public static ObjectsPage GetObjectsPage()
        {
            return GetPage<ObjectsPage>();
        }

        public static ObjectPage GetObjectPage()
        {
            return GetPage<ObjectPage>();
        }
    }
}
