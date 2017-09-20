using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace TestCloudControl.PageObjects
{
    /// <summary>
    /// Объект
    /// </summary>
    public class LivePage
    {
        private const string EVENT_NAME = "//div[. = 'Теннис']";

        [FindsBy(How = How.XPath, Using = EVENT_NAME)]
        private IWebElement _eventName;

        public void GetAllEvents()
        {
            IWebElement parent = _eventName.FindElement(By.XPath(".."));

        }
    }
}
