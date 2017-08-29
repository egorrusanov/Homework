using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace TestCloudControl.PageObjects
{
    public class MainPage : Header
    {
        [FindsBy(How = How.XPath, Using = COMPANY_LIST)]
        private IWebElement _companyList;

        [FindsBy(How = How.XPath, Using = COMPANY_HREF)]
        private IWebElement _companyHref;

        public bool SuccessLoadMainPage()
        {
            if (_companyList.FindElements(By.ClassName("col")) == null)
                throw new Exception("Отсутствуют компании.");

            return true;
        }

        public void OpenTestCompany()
        {
            _companyHref.Click();
        }

        public string GetTestCompanyName()
        {
            return TEST_COMPANY_NAME;
        }

        private const string COMPANY_LIST = "//*[@id='spaContent']/div[3]/div[1]";
        private const string COMPANY_HREF = "//*[@id='spaContent']/div[3]/div[1]/div[6]/div/a";

        //не работает, но то
        private const string TEST_COMPANY_NAME = "Тестовый дивизион";
    }
}
