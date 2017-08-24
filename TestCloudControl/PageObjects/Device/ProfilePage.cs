using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace TestCloudControl.PageObjects.Device
{
    public class ProfilePage : DevicePage
    {
        [FindsBy(How = How.XPath, Using = SAVE_PROFILE)]
        private IWebElement _saveProfileButton;

        public bool SuccessLoadProfileDevice()
        {
            if (_saveProfileButton == null)
                throw new Exception("Не удалось загрузить Профиль.");

            return true;
        }
        
        private const string SAVE_PROFILE = "//button[.='Сохранить профиль']";
    }
}
