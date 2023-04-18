using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nishat_Linen_Project.Login;

namespace Nishat_Linen_Project.Address
{
    [TestClass]
  public class Address_Test_Method: BaseClass
    {
        LoginClass loginClass = new LoginClass();
        AddressClass addressClass = new AddressClass();
        [TestMethod]
        public void Address_Test()
        {

            InitDriver("chrome");
            loginClass.LoginMethod();
            addressClass.AddressMethod();
            CloseDriver();
        }
    }
}
