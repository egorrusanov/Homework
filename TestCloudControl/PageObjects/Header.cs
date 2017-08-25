using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestCloudControl.PageObjects
{
    /// <summary>
    /// Заголовок и Левое меню
    /// Базовый класс для всех страниц, доступных после авторизации
    /// </summary>
    public class Header
    {
        [FindsBy(How = How.ClassName, Using = "expand-menu")]
        private IWebElement _expandMenu;

        [FindsBy(How = How.Id, Using = "search")]
        [CacheLookup]
        private IWebElement _search;

        [FindsBy(How = How.XPath, Using = OFFLINE_MODEMS_HREF)]
        private IWebElement _devicesOfflineModemsHref;

        [FindsBy(How = How.XPath, Using = OFFLINE_MODEMS_NUMBERS)]
        private IWebElement _devicesOfflineModemsNumbers;

        [FindsBy(How = How.XPath, Using = UNPLUGGED_HREF)]
        private IWebElement _devicesUnpluggedHref;

        [FindsBy(How = How.XPath, Using = UNPLUGGED_NUMBERS)]
        private IWebElement _devicesUnpluggedNumbers;

        [FindsBy(How = How.XPath, Using = ALARMED_HREF)]
        private IWebElement _devicesAlarmedHref;

        [FindsBy(How = How.XPath, Using = ALARMED_NUMBERS)]
        private IWebElement _devicesAlarmedNumbers;

        [FindsBy(How = How.ClassName, Using = "user-data")]
        private IWebElement _userData;

        [FindsBy(How = How.ClassName, Using = "user-rang")]
        private IWebElement _userRang;

        [FindsBy(How = How.ClassName, Using = "user-name")]
        private IWebElement _userName;

        [FindsBy(How = How.XPath, Using = "//[@data-l10n-id='Profile']")]
        private IWebElement _profile;

        [FindsBy(How = How.XPath, Using = "//[@data-l10n-id='Info']")]
        private IWebElement _info;

        [FindsBy(How = How.XPath, Using = "//[@data-l10n-id='LogOff']")]
        private IWebElement _logOff;

        [FindsBy(How = How.Id, Using = "m-main")]
        [CacheLookup]
        private IWebElement _mainItem;

        [FindsBy(How = How.Id, Using = "m-service-companies")]
        [CacheLookup]
        private IWebElement _serviceCompaniesItem;

        [FindsBy(How = How.Id, Using = "m-users")]
        [CacheLookup]
        private IWebElement _usersItem;

        [FindsBy(How = How.Id, Using = "m-orders")]
        [CacheLookup]
        private IWebElement _ordersItem;

        [FindsBy(How = How.Id, Using = "m-devices")]
        [CacheLookup]
        private IWebElement _devicesItem;

        public void OpenOfflineModems()
        {
            _devicesOfflineModemsHref.Click();
        }

        public void OpenUnpluggedDevices()
        {
            _devicesUnpluggedHref.Click();
        }

        public void OpenAlarmedDevices()
        {
            _devicesAlarmedHref.Click();
        }

        public void OpenDevicesList()
        {
            _devicesItem.Click();
        }

        public void LogOff()
        {
            _logOff.Click();
        }

        private const string OFFLINE_MODEMS_HREF = ".//[@class='signal-icons']/a[0]";
        private const string OFFLINE_MODEMS_NUMBERS = ".//[@class='signal-icons']/a[0]/span";
        private const string UNPLUGGED_HREF = ".//[@class='signal-icons']/a[1]";
        private const string UNPLUGGED_NUMBERS = ".//[@class='signal-icons']/a[1]/span";
        private const string ALARMED_HREF = ".//[@class='signal-icons']/a[2]";
        private const string ALARMED_NUMBERS = ".//[@class='signal-icons']/a[2]/span";
    }
}
