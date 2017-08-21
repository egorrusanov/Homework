using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestCloudControl.PageObjects
{
    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "RegisterUserName")]
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "RegisterPassword")]
        [CacheLookup]
        private IWebElement UserPassword { get; set; }

        [FindsBy(How = How.XPath, Using = LOGIN_BUTTON)]
        private IWebElement Submit { get; set; }

        [FindsBy(How = How.LinkText, Using = "Авторизация")]
        private IWebElement SuccessLoad { get; set; }
        
        [FindsBy(How = How.Id, Using = "toast-container")]
        private IWebElement ToastContainer { get; set; }

        [FindsBy(How = How.XPath, Using = "//[@data-l10n-id='Register']")]
        private IWebElement Register { get; set; }

        [FindsBy(How = How.XPath, Using = "//[@data-l10n-id='RecoverPassword']")]
        private IWebElement RecoverPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//[@type='checkbox']")]
        private IWebElement RememberMe { get; set; }

        public void LoginToApplication(string name, string password)
        {
            UserName.Clear();
            UserName.SendKeys(name);
            UserPassword.Clear();
            UserPassword.SendKeys(password);
            Submit.Click();
        }

        public string ValidateResultLogin(IWebDriver driver)
        {
            try
            {
                WebDriverFactory.WaitForReady();
                IWebElement errorMessage = driver.FindElement(By.XPath(".//*[@class='toast-message']"));

                return errorMessage.Text;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public bool SuccessLogin(IWebDriver driver)
        {
            return driver.Manage().Cookies.AllCookies.Count > 0 
                && driver.Manage().Cookies.AllCookies[0].Expiry == DateTime.Now.AddHours(1);
        }

        private const string LOGIN_BUTTON = "//button[@type='submit']";
        private const string LOGIN_DENIED = "Неверный логин или пароль";
    }
}
