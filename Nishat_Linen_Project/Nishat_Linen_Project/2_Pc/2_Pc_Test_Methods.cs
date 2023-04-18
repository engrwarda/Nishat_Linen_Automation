using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nishat_Linen_Project._2_Pc
{
    [TestClass]
    public class PcTestMethods:BaseClass
    {
        TwoPieceClass twoPieceClass = new TwoPieceClass();
        [TestMethod]
        public void Two_Piece_Method()
        {
            InitDriver("chrome");
            twoPieceClass.TwoPieceMethod();
            CloseDriver();

           //expected = login.validation();
           // Console.WriteLine(expected);
           // bs.AssertEqual(expected, actual);
        }

    }
}
