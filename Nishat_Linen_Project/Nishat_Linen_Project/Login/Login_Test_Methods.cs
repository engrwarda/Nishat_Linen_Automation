using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nishat_Linen_Project.Login
{
    [TestClass]
    public class Login_Test_Methods:BaseClass
    {
        LoginClass loginClass = new LoginClass();
        [TestMethod]
        public void Login_Test()
        {
            InitDriver("chrome");
            loginClass.LoginMethod();
            CloseDriver();
        }
    }
}
