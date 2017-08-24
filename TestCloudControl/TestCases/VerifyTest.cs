using NUnit.Framework;
using TestCloudControl.PageObjects;
using System.Configuration;
using System.Collections;

namespace TestCloudControl.TestCases
{
    [TestFixture]
    [Parallelizable]
    public class VerifyIncorrectLoginTest : TestBase
    {
        private const string LOGIN_DENIED = "Неверный логин или пароль";

        public static IEnumerable GetTestCasesEmailLogin
        {
            get
            {
                foreach (string browserName in BrowserToRunWith())
                {
                    yield return new TestCaseData(browserName, "superadmiu", "&U*I9o").Returns(LOGIN_DENIED);
                    yield return new TestCaseData(browserName, "123456", "&U*I9o").Returns(LOGIN_DENIED);
                    yield return new TestCaseData(browserName, "1234567890@asdf.asd", "&U*I9o").Returns(LOGIN_DENIED);
                    yield return new TestCaseData(browserName, "", "&U*I9o").Returns(LOGIN_DENIED);
                }
            }
        }

        public static IEnumerable GetTestCasesPasswordLogin
        {
            get
            {
                foreach (string browserName in BrowserToRunWith())
                {
                    yield return new TestCaseData(browserName, "superadmin@x5test.ru", "DROP DATABASE").Returns(LOGIN_DENIED);
                    yield return new TestCaseData(browserName, "superadmin@x5test.ru", "1111111111111111111111111111111111231231wsfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdvxcvxcvxcvxcvdfgdfgsdsgsdfgsdgdserrhjfhjfhdfghfghfgo").Returns(LOGIN_DENIED);
                    yield return new TestCaseData(browserName, "superadmin@x5test.ru", "@wqqqwe").Returns(LOGIN_DENIED);
                    yield return new TestCaseData(browserName, "superadmin@x5test.ru", "").Returns(LOGIN_DENIED);
                }
            }
        }

        [Test]
        [TestCaseSource(nameof(GetTestCasesEmailLogin))]
        public string IncorrectEmail(string browserName, string email, string password)
        {
            WebDriverFactory.InitDriver(browserName);
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);

            LoginPage loginPage = PageFactory.GetLoginPage();
            
            loginPage.LoginToApplication(GetEmail(), GetPassword());

            return loginPage.ValidateResultLogin(WebDriverFactory.Driver);
        }

        [Test]
        [TestCaseSource(nameof(GetTestCasesPasswordLogin))]
        public string IncorrectPassword(string browserName, string email, string password)
        {
            
            WebDriverFactory.InitDriver(browserName);
            WebDriverFactory.LoadApplication(ConfigurationManager.AppSettings["URL"]);

            LoginPage loginPage = PageFactory.GetLoginPage();
            
            loginPage.LoginToApplication(GetEmail(), GetPassword());

            return loginPage.ValidateResultLogin(WebDriverFactory.Driver);
        }
    }
}
