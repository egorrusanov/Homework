using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestCloudControl.PageObjects.Device
{
    public class ProfilePage : DevicePage
    {
        [FindsBy(How = How.XPath, Using = SAVE_PROFILE)]
        private IWebElement _saveProfileButton;

        [FindsBy(How = How.XPath, Using = WAIT_DIALOG)]
        private IWebElement _pleaseWaitDialog;

        [FindsBy(How = How.XPath, Using = SUCCESS_MESSAGE)]
        private IWebElement _successMessage;

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

        public string ValidateResultSave()
        {
            try
            {
                WebDriverFactory.WaitForReady();

                string successMessage = WebDriverFactory.Driver.FindElement(By.XPath(".//*[@class='toast-message']")).Text;
                
                System.Threading.Thread.Sleep(3000);
                if (!WebDriverFactory.CheckFileDownloaded(DOWNLOADING_FILE))
                    throw new Exception("Скаченный файл не найден.");

                return successMessage;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public IWebElement GetSuccessMessage()
        {
            return _successMessage;
        }

        private const string DOWNLOADING_FILE = "AK-PC551-0140.xml";
        private const string SAVE_PROFILE = "//button[.='Сохранить профиль']";
        private const string WAIT_DIALOG = "//*[@id='pleaseWaitDialog']";
        private const string SUCCESS_MESSAGE = ".//*[@class='toast-message']";
    }
}
