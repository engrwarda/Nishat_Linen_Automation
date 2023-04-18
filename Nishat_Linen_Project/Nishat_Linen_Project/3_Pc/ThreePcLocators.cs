using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Nishat_Linen_Project._3_Pc
{
    public class ThreePcLocators : BaseClass
    {
        #region Three_Pc_Locators
        By Search = (By.XPath("//div[@class ='t4s-site-nav__icon t4s-site-nav__search']"));
        By Search_Field = (By.Name("q"));
        By Submit_Btn = (By.XPath("//button[@class = 't4s-mini-search__submit t4s-btn-loading__svg']"));
        By searchFirstResult = (By.CssSelector(".t4s-product-title"));


        #endregion
        public void ThreePcMethod()
        {
            #region Three_Pc_Method
            FindElement(Search);
            SendKeysMethod(Search_Field, "3 Piece");
            FindElement(Submit_Btn);
            string searchResult = GetElementText(searchFirstResult);
            Assert.IsTrue(searchResult.Contains("3 Piece"));
            #endregion

        }
    }
}
