using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestCloudControl.PageObjects.Device
{
    public class DashboardPage : DevicePage
    {
        [FindsBy(How = How.XPath, Using = ADD_WIDGET)]
        private IWebElement _addWidgetButton;

        public bool SuccessLoadDashboard()
        {
            if (_addWidgetButton == null)
                throw new Exception("Не удалось загрузить Панель управления.");

            return true;
        }
        
        private const string ADD_WIDGET = "//button[.='Добавить виджет']";
    }
}
