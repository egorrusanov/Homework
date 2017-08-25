using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestCloudControl.PageObjects
{
    public class MainPage : Header
    {
        [FindsBy(How = How.XPath, Using = FIRST_COMPANY_HREF)]
        private IWebElement _firstCompanyHref;

        [FindsBy(How = How.XPath, Using = FIRST_COMPANY_NAME)]
        private IWebElement _firstCompanyName;

        public bool SuccessLoadMainPage()
        {
            if (_firstCompanyHref == null)
                throw new Exception("Отсутствуют компании.");

            return true;
        }

        public string GetCompanyName()
        {
            return _firstCompanyName.Text;
        }

        public void OpenObjects()
        {
            _firstCompanyHref.Click();
        }
        
        private const string FIRST_COMPANY_HREF = "//*[@id='spaContent']/div[3]/div[1]/div[1]/div/a";
        private const string FIRST_COMPANY_NAME = "//*[@id='spaContent']/div[3]/div[1]/div[1]/div/a/div[2]";
    }
}
