using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestCloudControl.PageObjects
{
    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "RegisterUserName")]
        [CacheLookup]
        private IWebElement UserName { get; set; }

        [FindsBy(How = How.Id, Using = "RegisterPassword")]
        [CacheLookup]
        private IWebElement UserPassword { get; set; }

        [FindsBy(How = How.XPath, Using = LOGIN_BUTTON)]
        [CacheLookup]
        private IWebElement Submit { get; set; }

        [FindsBy(How = How.LinkText, Using = "Авторизация")]
        [CacheLookup]
        private IWebElement SuccessLoad { get; set; }
        
        [FindsBy(How = How.Id, Using = "toast-container")]
        [CacheLookup]
        private IWebElement ToastContainer { get; set; }

        [FindsBy(How = How.XPath, Using = "//[@data-l10n-id='Register']")]
        [CacheLookup]
        private IWebElement Register { get; set; }

        [FindsBy(How = How.XPath, Using = "//[@data-l10n-id='RecoverPassword']")]
        [CacheLookup]
        private IWebElement RecoverPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//[@type='checkbox']")]
        [CacheLookup]
        private IWebElement RememberMe { get; set; }

        public void LoginToApplication(string name, string password)
        {
            UserName.SendKeys(name);
            UserPassword.SendKeys(password);
            Submit.Click();
        }

        public bool ValidateResultLogin(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("toast-container")));

            return ToastContainer.Text.Contains(LOGIN_DENIED);
        }

        private const string LOGIN_BUTTON = "//button[@type='submit']";
        private const string LOGIN_DENIED = "Неверный логин или пароль";
    }
}
