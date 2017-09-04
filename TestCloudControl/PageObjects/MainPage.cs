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

        [FindsBy(How = How.XPath, Using = COMPANY_NAME)]
        private IWebElement _companyName;

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
            //необходимо в FF
            System.Threading.Thread.Sleep(2000);
            return _companyName.Text;
        }

        private const string COMPANY_LIST = "//*[@id='spaContent']/div[3]/div[1]";
        // Не работает с Тестовым дивизионом обрыв по таймауту
        private const string COMPANY_HREF = "//*[@id='spaContent']/div[3]/div[1]/div[5]/div/a";
        private const string COMPANY_NAME = "//*[@id='spaContent']/div[3]/div[1]/div[5]/div/a/div[2]";
        //*[@id="spaContent"]/div[3]/div[1]/div[7]/div/a
        //не работает, но то
        private const string TEST_COMPANY_NAME = "Тестовый дивизион";
    }
}
