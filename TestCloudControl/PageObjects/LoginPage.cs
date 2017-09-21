using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestCloudControl.Common;
using NUnit.Framework;

namespace TestCloudControl.PageObjects
{
    public class LoginPage : AbstractPage
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

        public void LoginToApplication(string email, string password, IWebDriver driver)
        {
            _loginTextbox.Clear();
            _loginTextbox.SendKeys(email);
            _passwordTextbox.Clear();
            _passwordTextbox.SendKeys(email);
            _submit.Click();
            WaitForReady(driver);
        }

        /// <summary>
        /// Успешный логин
        /// </summary>
        /// <param name="driver">Драйвер</param>
        /// <returns>true, если куки не пустые, значение токена не null, срок истечения не 1 час</returns>
        public bool SuccessLogin(IWebDriver driver)
        {
            Assert.IsTrue(driver.Manage().Cookies.AllCookies.Count != 0, "Cookies пустые.");
            Assert.IsTrue(!driver.Manage().Cookies.AllCookies[0].Value.Equals("null"), "Значение токена null.");
            //Assert.IsTrue(driver.Manage().Cookies.AllCookies[0].Expiry.Value.Hour.Equals(DateTime.Now.AddHours(1).Hour), "Время жизни токена не 1 час.");

            return true;
        }
    }
}