using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestCloudControl.PageObjects
{
    public class ObjectPage : Header
    {
        [FindsBy(How = How.XPath, Using = OBJECT_NAME)]
        private IWebElement _objectName;

        public void SuccessLoadObject(string objectName)
        {
            if (!objectName.Contains(_objectName.Text))
                throw new Exception("Объект не загружены.");
        }

        private const string OBJECT_NAME = "//*[@id='spaContent']/div[1]/div[1]/div[1]/h1";
        
    }
}
