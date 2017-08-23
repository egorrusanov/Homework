using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestCloudControl.PageObjects
{
    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "RegisterUserName")]
        private IWebElement _userName;

        [FindsBy(How = How.Id, Using = "RegisterPassword")]
        [CacheLookup]
        private IWebElement _userPassword;

        [FindsBy(How = How.XPath, Using = LOGIN_BUTTON)]
        private IWebElement _submit;

        [FindsBy(How = How.LinkText, Using = "Авторизация")]
        private IWebElement _successLoad;

        [FindsBy(How = How.Id, Using = "toast-container")]
        private IWebElement _toastContainer;

        [FindsBy(How = How.XPath, Using = "//[@data-l10n-id='Register']")]
        private IWebElement _register;

        [FindsBy(How = How.XPath, Using = "//[@data-l10n-id='RecoverPassword']")]
        private IWebElement _recoverPassword;

        [FindsBy(How = How.XPath, Using = "//[@type='checkbox']")]
        private IWebElement _rememberMe;

        public void LoginToApplication(string name, string password)
        {
            _userName.Clear();
            _userName.SendKeys(name);
            _userPassword.Clear();
            _userPassword.SendKeys(password);
            _submit.Click();
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
                && driver.Manage().Cookies.AllCookies[0].Value != null
                && driver.Manage().Cookies.AllCookies[0].Expiry.Value.Hour == DateTime.Now.AddHours(1).Hour;
        }

        private const string LOGIN_BUTTON = "//button[@type='submit']";
        private const string LOGIN_DENIED = "Неверный логин или пароль";
    }
}
