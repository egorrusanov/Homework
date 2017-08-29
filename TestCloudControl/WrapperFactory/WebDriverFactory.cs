using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace TestCloudControl
{
    public class WebDriverFactory
    {
        private static IWebDriver driver;
        private static int waitForElement = 30;
        //private static string DOWNLOAD_PATH;

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
                    FirefoxProfile firefoxProfile = new FirefoxProfile();
                    firefoxProfile.SetPreference("browser.download.folderList", 2);
                    firefoxProfile.SetPreference("browser.download.dir", GetDownloadPath());
                    firefoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/xml");
                    driver = new FirefoxDriver(firefoxProfile);
                    break;

                case "Chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddUserProfilePreference("download.default_directory", GetDownloadPath());
                    chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
                    chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                    driver = new ChromeDriver(chromeOptions);
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
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(waitForElement));
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

        public static string GetDownloadPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        public static void DeleteFileDownloaded(string filename)
        {
            string Path = GetDownloadPath();
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains(filename))
                {
                    File.Delete(p);
                    break;
                }
            }
        }

        public static bool CheckFileDownloaded(string filename)
        {
            bool exist = false;
            string Path = GetDownloadPath();
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains(filename))
                {
                    FileInfo thisFile = new FileInfo(p);
                    //Check the file that are downloaded in the last 3 minutes
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(2).ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(3).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                        exist = true;
                    File.Delete(p);
                    break;
                }
            }
            return exist;
        }
    }
}
