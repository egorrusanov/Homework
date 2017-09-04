﻿using OpenQA.Selenium;
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

        [FindsBy(How = How.XPath, Using = OBJECTS_PER_PAGE)]
        private IWebElement _objectsPerPage;

        [FindsBy(How = How.XPath, Using = PAGE_SIZE_100)]
        private IWebElement _pageSize100;

        public void SuccessLoadObjects(string companyName)
        {
            //необходимо в FF
            System.Threading.Thread.Sleep(2000);
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

        public void SelectPageSize(int size)
        {
            _objectsPerPage.Click();
            switch (size)
            {
                case 100:
                    _pageSize100.Click();
                    break;
            }
        }

        private const string COMPANY_NAME = "//*[@id='spaContent']/div[1]/div[1]/div[2]/h1";
        private const string OBJECTS_TABLE = "//*[@id='objectsTable']";
        private const string OBJECT_HREF = "//*[@id='objectsTable']/tbody/tr/td[2]/a";
        private const string OBJECTS_PER_PAGE = "//*[@id='spaContent']/div[1]/div[2]/div[1]/div[3]/div/button";
        private const string PAGE_SIZE_100 = "//*[@id='spaContent']/div[1]/div[2]/div[1]/div[3]/div/ul/li[4]/a";

    }
}
