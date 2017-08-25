using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestCloudControl
{
    public class WebDriverFactory
    {
        private static IWebDriver driver;
        private static TimeSpan waitForElement = TimeSpan.FromSeconds(5);

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
                    break;

                case "Chrome":
                    driver = new ChromeDriver();
                    break;

                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
            }
            driver.Manage().Cookies.DeleteAllCookies();
        }

        public static void LoadApplication(string url)
        {
            Driver.Url = url;
        }
        
        public static void CloseAllDrivers()
        {
            Driver.Manage().Cookies.DeleteAllCookies();
            Driver.Close();
            Driver.Quit();
        }

        //Ожидание ответа ajax
        public static void WaitForReady()
        {
            WebDriverWait wait = new WebDriverWait(Driver, waitForElement);
            wait.Until(driver =>
            {
                bool isAjaxFinished = (bool)((IJavaScriptExecutor)driver).
                    ExecuteScript("return window.jQuery != undefined && jQuery.active === 0");
                return isAjaxFinished;
            });
        }

        public static bool IsActiveSession()
        {
            ICookieJar cookies = Driver.Manage().Cookies;
            if (cookies.AllCookies.Count == 0)
                throw new Exception("Cookies пустые.");

            if (cookies.AllCookies[0].Value.Equals("null"))
                throw new Exception("Значение токена null.");

            if (cookies.AllCookies[0].Expiry.Value < DateTime.Now)
                throw new Exception("Время жизни токена истекло");

            return true;
        }
    }
}
