using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace TestCloudControl.PageObjects
{
    public class MainPage
    {
        private const string LIVE_EVENTS = "//*[@id='LayoutContentPlaceHolder_LeftSidebarGamesMenuUserControl1_LeftSidebarGamesRepeater_LeftSidebarGamesHyperLinkLocalizable_0']";

        [FindsBy(How = How.XPath, Using = LIVE_EVENTS)]
        private IWebElement _liveEvents;

        public void OpenLiveEvents()
        {
            _liveEvents.Click();
        }
    }
}
