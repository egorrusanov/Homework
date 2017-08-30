using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

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

        [FindsBy(How = How.XPath, Using = GROUPS)]
        private IWebElement _groups;

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

        private IList<IWebElement> GetGroupsList()
        {
            return _groups.FindElements(By.TagName("li"));
        }

        private IWebElement GetGroupAllParameters()
        {
            IWebElement group = null;
            foreach (IWebElement g in GetGroupsList())
            {
                if (g.GetAttribute("id").Equals("0"))
                {
                    group = g;
                    break;
                }                        
            }
            return group;
        }

        public void SelectAllParameters()
        {
            IWebElement allParameters = GetGroupAllParameters();

            if (allParameters == null)
                throw new Exception("Группа 'Все' не найдена.");

            GetGroupAllParameters().Click();
        }

        public bool CheckTimeQuery(int limitTime)
        {
            DateTime startTime = DateTime.Now;
            WebDriverFactory.WaitForReady();
            DateTime endTime = DateTime.Now;

            return endTime - startTime < TimeSpan.FromSeconds(limitTime);
        }

        private const string DOWNLOADING_FILE = "AK-PC551-0140.xml";
        private const string SAVE_PROFILE = "//button[.='Сохранить профиль']";
        private const string WAIT_DIALOG = "//*[@id='pleaseWaitDialog']";
        private const string SUCCESS_MESSAGE = ".//*[@class='toast-message']";
        private const string GROUPS = "//*[@id='spaContent']/div/div[2]/div[2]/div[1]/div/div[2]/ul";
    }
}
