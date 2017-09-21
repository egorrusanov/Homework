using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestCloudControl.Common
{
    /// <summary>
    /// Базовая страница
    /// </summary>
    public abstract class AbstractPage
    {
        private int _waitForElement = 60;
        /// <summary>
        /// Ожидание окончания загрузки скриптов
        /// </summary>
        public void WaitForReady(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_waitForElement));
            wait.Until(d =>
            {
                bool isAjaxFinished = (bool)((IJavaScriptExecutor)d).
                    ExecuteScript("return window.jQuery != undefined && jQuery.active === 0");
                return isAjaxFinished;
            });
        }

        /// <summary>
        /// Сделать скриншот текущей страницы
        /// </summary>
        /// <param name="driver">Драйвер</param>
        /// <param name="testName">Название теста</param>
        /// <param name="pageName">Название страницы</param>
        public void GetScreenshot(IWebDriver driver, string testName, string pageName)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            //ss.SaveAsFile("C:\\sample.png", ScreenshotImageFormat.Png);
        }
    }
}
