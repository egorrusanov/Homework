using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestCloudControl.PageObjects
{
    public class ObjectsPage : Header
    {
        [FindsBy(How = How.XPath, Using = COMPANY_NAME)]
        private IWebElement _companyName;

        [FindsBy(How = How.XPath, Using = OBJECTS_TABLE)]
        private IWebElement _objectsTable;

        [FindsBy(How = How.XPath, Using = OBJECT_HREF)]
        private IWebElement _objectHref;

        public void SuccessLoadObjects(string companyName)
        {
            if (!companyName.Contains(_companyName.Text))
                throw new Exception("Объекты не загружены.");
        }

        public void OpenObject()
        {
            _objectHref.Click();
        }

        public string GetObjectName()
        {
            return _objectHref.Text;
        }

        private const string COMPANY_NAME = "//*[@id='spaContent']/div[1]/div[1]/div[2]/h1";
        private const string OBJECTS_TABLE = "//*[@id='objectsTable']";
        private const string OBJECT_HREF = "//*[@id='objectsTable']/tbody/tr/td[2]/a";

    }
}
