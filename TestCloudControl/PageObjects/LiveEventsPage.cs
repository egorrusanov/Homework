using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestCloudControl.Common;
using NUnit.Framework;

namespace TestCloudControl.PageObjects
{
    public class MainPage : AbstractPage
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