using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;

namespace TestCloudControl.PageObjects
{
    /// <summary>
    /// Объект
    /// </summary>
    public class ObjectPage : Header
    {
        [FindsBy(How = How.XPath, Using = OBJECT_NAME)]
        private IWebElement _objectName;

        [FindsBy(How = How.XPath, Using = MODEMS_LEFT_SIDE)]
        private IWebElement _modemsLeftSide;

        [FindsBy(How = How.XPath, Using = MODEMS_RIGHT_SIDE)]
        private IWebElement _modemsRightSide;

        [FindsBy(How = How.XPath, Using = DEVICES_LIST)]
        private IWebElement _devicesList;

        [FindsBy(How = How.XPath, Using = PROFILE_HREF)]
        private IWebElement _profileHref;

        public void SuccessLoadObject(string objectName)
        {
            if (!objectName.Contains(_objectName.Text))
                throw new Exception("Объект не загружены.");
        }

        public void OpenProfile()
        {
            GetProfileHref().Click();
        }

        private IWebElement GetProfileHref()
        {
            try
            {
                IList<IWebElement> modemsLeftSideList = _modemsLeftSide.FindElements(By.TagName("div"));
                IList<IWebElement> modemsRightSideList = _modemsRightSide.FindElements(By.TagName("div"));
                IWebElement profileHref = null;

                if (modemsLeftSideList != null && modemsLeftSideList.Count > 0)
                {
                    profileHref = GetFirstDeviceProfileHref(modemsLeftSideList);
                    return profileHref;
                }

                if (modemsRightSideList != null && modemsRightSideList.Count > 0)
                {
                    profileHref = GetFirstDeviceProfileHref(modemsRightSideList);
                }
                return profileHref;
            }
            catch
            {
                throw new Exception("Не удалось получить ссылку на Профиль.");
            }
        }

        private IWebElement GetFirstDeviceProfileHref(IList<IWebElement> modemsList)
        {
            try
            {
                IWebElement profileHref = null;
                foreach (IWebElement dg in modemsList)
                {
                    profileHref = dg.FindElement(By.XPath("ul/li[1]/div/div[2]/a[1]"));
                    break;
                }

                return profileHref;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        private const string OBJECT_NAME = "//*[@id='spaContent']/div[1]/div[1]/div[1]/h1";
        private const string MODEMS_LEFT_SIDE = "//*[@id='spaContent']/div[1]/div[2]/div[2]/div[1]";
        private const string MODEMS_RIGHT_SIDE = "//*[@id='spaContent']/div[1]/div[2]/div[2]/div[2]";
        private const string DEVICES_LIST = "//*[@id='spaContent']/div[1]/div[2]/div[2]/div[1]/div/ul";
        private const string PROFILE_HREF = "//*[@id='spaContent']/div[1]/div[2]/div[2]/div[1]/div/ul/li[1]/div[1]/div[2]/a[1]";
    }
}
