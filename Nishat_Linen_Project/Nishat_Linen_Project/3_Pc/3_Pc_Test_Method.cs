using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nishat_Linen_Project._3_Pc
{
    [TestClass]
    public class _3_Pc_Test_Method : BaseClass
    {
        ThreePcLocators ThreePcClass = new ThreePcLocators();
        [TestMethod]
        public void Three_3Pc_Test_Method()
        {
            InitDriver("chrome");
            ThreePcClass.ThreePcMethod();
            CloseDriver();

        }

    }
}
