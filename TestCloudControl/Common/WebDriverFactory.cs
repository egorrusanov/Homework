using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using System;
using System.IO;

namespace TestCloudControl.Common
{
    public class WebDriverFactory
    {
        /// <summary>
        /// Получить драйвер IWebDriver по имени
        /// </summary>
        /// <param name="driverName"></param>
        /// <returns></returns>
        public IWebDriver GetDriver(string driverName)
        {
            IWebDriver driver = null;

            switch (driverName)
            {
                case "Firefox":
                    FirefoxProfile firefoxProfile = new FirefoxProfile();
                    firefoxProfile.SetPreference("browser.download.folderList", 2);
                    firefoxProfile.SetPreference("browser.download.dir", GetDownloadPath());
                    firefoxProfile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/xml");
                    firefoxProfile.SetPreference("browser.helperApps.alwaysAsk.force", false);
                    driver = new FirefoxDriver(firefoxProfile);
                    break;

                case "Chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddUserProfilePreference("download.default_directory", GetDownloadPath());
                    chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
                    chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
                    chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                    chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
                    chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "IE":
                    var options = new InternetExplorerOptions
                    {
                        EnsureCleanSession = true,
                        IgnoreZoomLevel = true,
                        IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                    };
                    driver = new InternetExplorerDriver(options);
                    break;

                case "PhantomJS":
                    var phantomJsOptions = new PhantomJSOptions();
                    phantomJsOptions.AddAdditionalCapability("phantomjs.page.settings.userAgent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.94 Safari/537.36");

                    var driverService = PhantomJSDriverService.CreateDefaultService();
                    driverService.IgnoreSslErrors = true;
                    driverService.SslProtocol = "any";
                    driver = new PhantomJSDriver(driverService, phantomJsOptions);
                    break;
            }
            if (driver != null)
            {
                driver.Manage().Cookies.DeleteAllCookies();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(3);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(200);
            }

            return driver;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [test failed].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [test failed]; otherwise, <c>false</c>.
        /// </value>
        public bool IsTestFailed { get; set; }

        public static void CloseDriver(IWebDriver driver)
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Close();
            driver.Quit();
        }

        /// <summary>
        /// Состояние сессии
        /// </summary>
        /// <param name="driver">Драйвер</param>
        /// <returns></returns>
        public static bool IsActiveSession(IWebDriver driver)
        {
            ICookieJar cookies = driver.Manage().Cookies;
            if (cookies.AllCookies.Count == 0)
                throw new Exception("Cookies пустые.");

            if (cookies.AllCookies[0].Value.Equals("null"))
                throw new Exception("Значение токена null.");

            if (cookies.AllCookies[0].Expiry.Value < DateTime.Now)
                throw new Exception("Время жизни токена истекло");

            return true;
        }

        /// <summary>
        /// Получить путь для скачивания файла
        /// </summary>
        /// <returns></returns>
        public static string GetDownloadPath()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        /// Удалить скачанный файл
        /// </summary>
        /// <param name="filename"></param>
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

        /// <summary>
        /// Проверить наличие скачанного файла
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns></returns>
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