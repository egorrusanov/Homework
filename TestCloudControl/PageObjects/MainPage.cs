using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestCloudControl.PageObjects
{
    public class MainPage : Header
    {
        private IWebElement _testCompanyHref;

        [FindsBy(How = How.XPath, Using = TEST_COMPANY_NAME)]
        private IWebElement _testCompanyName;

        public bool SuccessLoadMainPage()
        {
            if (_testCompanyHref == null)
                throw new Exception("Отсутствуют компании.");

            return true;
        }

        public void GetCompanyHref()
        {
            _testCompanyHref = _testCompanyName.FindElement(By.XPath(".//a"));
        }

        public string GetCompanyName()
        {
            return _testCompanyName.Text;
        }

        public void OpenObjects()
        {
            GetCompanyHref();
            _testCompanyHref.Click();
        }
        
        private const string FIRST_COMPANY_HREF = "//*[@id='spaContent']/div[3]/div[1]/div[1]/div/a";
        //private const string FIRST_COMPANY_NAME = "//*[@id='spaContent']/div[3]/div[1]/div[1]/div/a/div[2]";
        private const string TEST_COMPANY_NAME = "//*[text()[contains(., 'Тестовый дивизион')]]";
    }
}
