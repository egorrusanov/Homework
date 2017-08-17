using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace TestCloudControl.WrapperFactory
{
    class WebDriverFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitDriver.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public static void InitDriver(string driverName)
        {
            switch (driverName)
            {
                case "Firefox":                    
                    driver = new FirefoxDriver();
                    Drivers.Add("Firefox", Driver);
                    break;

                case "Chrome":
                    driver = new ChromeDriver();
                    Drivers.Add("Chrome", Driver);
                    break;

                case "IE":
                    var options = new InternetExplorerOptions
                    {
                        EnableNativeEvents = true, // just as an example, you don't need this
                        IgnoreZoomLevel = true,
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true
                    };
                    driver = new InternetExplorerDriver(options);
                    Drivers.Add("IE", Driver);
                    break;
            }
        }

        public static void LoadApplication(string url)
        {
            Driver.Url = url;
        }
        
        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}
