using OpenQA.Selenium;
using AutomationFramework;

namespace Nishat_Linen_Project.Login
{
    public class LoginClass : BaseClass
    {
        #region Login_Locators
        By Account = By.XPath("//div[@class = 't4s-site-nav__icon t4s-site-nav__account t4s-d-none t4s-d-md-inline-block']");
        By Email = By.Id("CustomerEmail");
        By Password = By.Id("CustomerPassword");
        By Login = By.XPath("//button[text() ='Sign In']");
        By ValidateLogin = By.Id("b_5ceb80b4-7249-43c6-bab2-723276f6f6a2");

        #endregion


        public void LoginMethod()
        {
            #region Login_Method
            FindElement(Account);
            SendKeysMethod(Email, "pefimo2055@cyclesat.com");
            SendKeysMethod(Password, "@123456789");
            FindElement(Login);
            WaitforElement(ValidateLogin, 1);
            string validation = GetElementText(ValidateLogin);
            AssertEqual("MY ACCOUNT", validation);
            #endregion
        }


    }
}
