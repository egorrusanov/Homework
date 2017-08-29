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

        public void SaveProfile()
        {
            WebDriverFactory.DeleteFileDownloaded(DOWNLOADING_FILE);
            _saveProfileButton.Click();
        }

        public string ValidateResultSave(IWebDriver driver)
        {
            try
            {
                WebDriverFactory.WaitForReady();
                IWebElement successMessage = driver.FindElement(By.XPath(".//*[@class='toast-message']"));
                
                if (!WebDriverFactory.CheckFileDownloaded(DOWNLOADING_FILE))
                    throw new Exception("Скаченный файл не найден.");
                return successMessage.Text;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        private const string DOWNLOADING_FILE = "AK-PC551-0140.xml";
        private const string SAVE_PROFILE = "//button[.='Сохранить профиль']";
        private const string WAIT_DIALOG = "//*[@id='pleaseWaitDialog']";
    }
}
