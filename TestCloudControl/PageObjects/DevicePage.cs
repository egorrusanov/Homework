using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestCloudControl.PageObjects
{
    /// <summary>
    /// Оборудование
    /// </summary>
    public class DevicePage : Header
    {
        [FindsBy(How = How.TagName, Using = "h1")]
        private IWebElement _deviceName;

        [FindsBy(How = How.XPath, Using = TAB_DASHBOARD)]
        private IWebElement _tabDashboard;

        [FindsBy(How = How.XPath, Using = TAB_HISTORY)]
        private IWebElement _tabHistory;

        [FindsBy(How = How.XPath, Using = TAB_PROFILE)]
        private IWebElement _tabProfile;

        [FindsBy(How = How.XPath, Using = TAB_OPERATION_LOG)]
        private IWebElement _tabOperationLog;

        [FindsBy(How = How.XPath, Using = TAB_ALARMS)]
        private IWebElement _tabAlarms;

        public bool SuccessLoadDevice(string deviceName)
        {
            if (!_deviceName.Text.Equals(deviceName))
                throw new Exception("Не удалось загрузить страницу оборудования " + deviceName + ".");

            return true;
        }

        public void OpenProfile()
        {
            _tabProfile.Click();
        }

        private const string TAB_DASHBOARD = ".//[@class='dash-tabs']/a[0]";
        private const string TAB_HISTORY = ".//[@class='dash-tabs']/a[1]";
        private const string TAB_PROFILE = "//*[@class='dash-tabs']/a[2]";
        private const string TAB_OPERATION_LOG = ".//[@class='dash-tabs']/a[3]";
        private const string TAB_ALARMS = ".//[@class='dash-tabs']/a[4]";
    }
}
