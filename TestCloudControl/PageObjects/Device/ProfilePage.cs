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

        [FindsBy(How = How.XPath, Using = UPLOAD_PROFILE)]
        private IWebElement _uploadProfileButton;

        [FindsBy(How = How.XPath, Using = APPLY_PROFILE)]
        private IWebElement _applyProfileButton;

        [FindsBy(How = How.XPath, Using = BROWSE)]
        private IWebElement _browseButton;

        [FindsBy(How = How.XPath, Using = UPLOAD)]
        private IWebElement _uploadButton;

        [FindsBy(How = How.XPath, Using = CLOSE)]
        private IWebElement _closeButton;

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

        public void UploadProfile()
        {
            _uploadProfileButton.Click();

        }

        public void ApplyProfile()
        {
            _applyProfileButton.Click();
        }

        public void BrowseFile()
        {
            _browseButton.Click();
        }

        public void Upload()
        {
            _uploadButton.Click();
        }

        public void Close()
        {
            _closeButton.Click();
        }

        private const string DOWNLOADING_FILE = "AK-PC551-0140.xml";
        private const string SAVE_PROFILE = "//*[@id='spaContent']/div/div[2]/div[1]/div/div/div[1]/div/button[1]";
        private const string UPLOAD_PROFILE = "//*[@id='spaContent']/div/div[2]/div[1]/div/div/div[1]/div/button[2]";
        private const string APPLY_PROFILE = "//*[@id='spaContent']/div/div[2]/div[1]/div/div/div[1]/div/button[3]";
        private const string WAIT_DIALOG = "//*[@id='pleaseWaitDialog']";
        private const string SUCCESS_MESSAGE = ".//*[@class='toast-message']";
        private const string GROUPS = "//*[@id='spaContent']/div/div[2]/div[2]/div[1]/div/div[2]/ul";
        private const string UPLOAD_MODAL = "//*[@id='uploadProfileModal']";
        private const string BROWSE = "//*[@id='uploadProfileModal']/form/div/div/div[2]/a/input";
        private const string UPLOAD = "//*[@id='uploadProfileModal']/form/div/div/div[3]/div/button[1]";
        private const string CLOSE = "//*[@id='uploadProfileModal']/form/div/div/div[3]/div/button[2]";

    }
}
