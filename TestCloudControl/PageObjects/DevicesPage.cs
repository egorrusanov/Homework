using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace TestCloudControl.PageObjects
{
    /// <summary>
    /// Оборудование
    /// </summary>
    public class DevicesPage : Header
    {
        [FindsBy(How = How.XPath, Using = SEARCH)]
        private IWebElement _search;

        [FindsBy(How = How.XPath, Using = ALL_MODEMS)]
        private IWebElement _allModemsButton;

        [FindsBy(How = How.XPath, Using = ONLINE_MODEMS)]
        private IWebElement _onlineModemsButton;

        [FindsBy(How = How.XPath, Using = OFFLINE_MODEMS)]
        private IWebElement _offlineModemsButton;

        [FindsBy(How = How.ClassName, Using = "modems-list")]
        private IWebElement _modemList;

        [FindsBy(How = How.XPath, Using = ALL_DEVICES)]
        private IWebElement _allDevicesButton;

        [FindsBy(How = How.XPath, Using = ALARMED_DEVICES)]
        private IWebElement _alarmedDevicesButton;

        [FindsBy(How = How.XPath, Using = ONLINE_DEVICES)]
        private IWebElement _onlineDevicesButton;

        [FindsBy(How = How.XPath, Using = OFFLINE_DEVICES)]
        private IWebElement _offlineDevicesButton;

        [FindsBy(How = How.XPath, Using = SEARCH_DEVICES)]
        private IWebElement _searchDevices;

        [FindsBy(How = How.XPath, Using = SHOW_NUMBERS)]
        private IWebElement _showNumbers;

        [FindsBy(How = How.Id, Using = "environmentTable")]
        private IWebElement _devicesTable;

        public IList<IWebElement> DevicesRow { get; set; }

        public bool SuccessLoadModemList()
        {
            if (_modemList == null)
                throw new Exception("Не удалось загрузить список модемов.");

            if (GetModemsList().Count == 0)
                throw new Exception("Cписок модемов пуст.");

            return true;
        }

        public bool SuccessLoadDevicesTable()
        {
            if (_devicesTable == null)
                throw new Exception("Не удалось загрузить список оборудования.");
            
            if (GetDevicesRow().Count == 0)
                throw new Exception("Cписок оборудования пуст.");

            return true;
        }

        private IList<IWebElement> GetDevicesRow()
        {
            DevicesRow = _devicesTable.FindElements(By.TagName("tr"));
            return DevicesRow;
        }

        private IList<IWebElement> GetModemsList()
        {
            return _modemList.FindElements(By.TagName("li"));
        }
        

        public string GetFirstDeviceName()
        {
            return DevicesRow[1].FindElement(By.TagName("a")).Text;
        }

        public void OpenFirstDeviceLink()
        {
            DevicesRow[1].FindElements(By.ClassName("device-link"))[0].Click();
        }

        private const string SEARCH = ".//[@id='mod-search']/input";
        private const string MODEMS_LIST = ".//[@class='modems-list']/li";
        private const string ALL_MODEMS = ".//[@id='mod-filters2']/button[0]";
        private const string ONLINE_MODEMS = ".//[@id='mod-filters2']/button[1]";
        private const string OFFLINE_MODEMS = ".//[@id='mod-filters2']/button[2]";
        private const string ALL_DEVICES = ".//[@id='mod-filters']/button[0]";
        private const string ALARMED_DEVICES = ".//[@id='mod-filters']/button[1]";
        private const string ONLINE_DEVICES = ".//[@id='mod-filters']/button[2]";
        private const string OFFLINE_DEVICES = ".//[@id='mod-filters']/button[3]";
        private const string SEARCH_DEVICES = ".//[@id='environmentTable_filter']/input";
        private const string SHOW_NUMBERS = ".//[@class='dropdown modified for-table open']/button";
    }
}
