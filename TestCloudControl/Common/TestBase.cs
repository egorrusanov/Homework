using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Configuration;
using OpenQA.Selenium;

namespace TestCloudControl.Common
{
    /// <summary>
    /// Базовый тест
    /// </summary>
    public abstract class TestBase
    {
        protected IWebDriver Driver;
        protected PageFactory PageFactory = new PageFactory();

        /// <summary>
        /// Инициализация web-драйвера
        /// </summary>
        /// <param name="browserName">Название браузера</param>
        protected void InitDriver(string browserName)
        {
            WebDriverFactory factory = new WebDriverFactory();
            Driver = factory.GetDriver(browserName);
            Driver.Url = ConfigurationManager.AppSettings["URL"];
        }

        public string GetEmail()
        {
            return ConfigurationManager.AppSettings["email"];
        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings["password"];
        }

        /// <summary>
        /// Используемые драйверы
        /// </summary>
        /// <returns>Список поддерживаемых драйверов</returns>
        public static IEnumerable<String> BrowserToRunWith()
        {
            String[] browsers =
                {
                    "Chrome",
                    //"Firefox",
                    //"PhantomJS",
                    //"IE"
                };
            return browsers;
        }

        [TearDown]
        public void Close()
        {
            WebDriverFactory.CloseDriver(Driver);
        }
    }
}
