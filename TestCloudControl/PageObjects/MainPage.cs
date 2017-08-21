using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestCloudControl.PageObjects
{
    public class MainPage
    {
        [FindsBy(How = How.ClassName, Using = "user-data")]
        [CacheLookup]
        private IWebElement UserData { get; set; }
    }
}
