using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestCloudControl.PageObjects
{
    public class LoginPage
    {
        private const string LOGIN_TEXTBOX = "//*[@id='LoginTextBox']";
        private const string PASSWORD_TEXTBOX = "//*[@id='PasswordTextBox']";
        private const string LOGIN_BUTTON = "//*[@id='btnLogin']";

        [FindsBy(How = How.XPath, Using = LOGIN_TEXTBOX)]
        private IWebElement _loginTextbox;

        [FindsBy(How = How.XPath, Using = PASSWORD_TEXTBOX)]
        private IWebElement _passwordTextbox;

        [FindsBy(How = How.XPath, Using = LOGIN_BUTTON)]
        private IWebElement _submit;

        public void LoginToApplication(string email, string password)
        {
            _loginTextbox.Clear();
            _loginTextbox.SendKeys(email);
            _passwordTextbox.Clear();
            _passwordTextbox.SendKeys(email);
            _submit.Click();
        }
    }
}
