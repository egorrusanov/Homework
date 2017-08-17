using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestCloudControl.PageObjects
{
    public class StartPage
    {
        [FindsBy(How = How.Id, Using = "start")]
        public IWebElement Start { get; set; }
    }
}
