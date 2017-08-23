using OpenQA.Selenium.Support.PageObjects;

namespace TestCloudControl.PageObjects
{
    public static class PageFactory
    {
        private static T GetPage<T>() where T : new()
        {
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
    }
}
