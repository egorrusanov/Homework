using NUnit.Framework;
using TestCloudControl.PageObjects;
using TestCloudControl.Common;

namespace TestCloudControl.TestCases
{
    [TestFixture]
    [Parallelizable]
    public class LoginTest : TestBase
    {
        [Test]
        [TestCaseSource(typeof(TestBase), "BrowserToRunWith")]
        public void Login(string browserName)
        {
            InitDriver(browserName);

            LoginPage loginPage = PageFactory.GetPage<LoginPage>(Driver);

            loginPage.LoginToApplication(GetEmail(), GetPassword(), Driver);

            Assert.IsTrue(loginPage.SuccessLogin(Driver), "Не удалось авторизоваться.");
        }
    }
}
