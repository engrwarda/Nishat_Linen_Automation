using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nishat_Linen_Project.Cart
{
    [TestClass]
    public class Cart_TeMethods: BaseClass
    {
        CartClass cartClass = new CartClass();
        [TestMethod]
        public void Cart_Test()
        {
            InitDriver("chrome");
            cartClass.CartMethod();
            CloseDriver();
        }
    }
}

