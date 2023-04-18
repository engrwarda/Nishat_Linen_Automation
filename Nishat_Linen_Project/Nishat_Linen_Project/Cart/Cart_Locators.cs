using AutomationFramework;
using OpenQA.Selenium;
using System.Threading;

namespace Nishat_Linen_Project.Cart
{
    public class CartClass : BaseClass
    {
        #region Cart_Locators
        By Accessories = (By.XPath("//a[text() ='ACCESSORIES']"));
        By Search_First_Result = (By.CssSelector(".t4s-product-title"));
        By Add_Cart = (By.Name("add"));
        By Cart_Pop_Up = (By.XPath("//span[@class='add-to-cart-form-modal-close']"));
        By Cart_Icon = (By.XPath("//span[@class ='t4s-pr t4s-icon-cart__wrap']"));
        By Cart_Count = (By.XPath("//*[@id='shopify-section-header-bottom']/div/div/div[1]/div/div[4]/div/div[4]/a/span[1]/span"));
        By Cart_Delete = (By.XPath("//*[@id='shopify-section-template--16149187035335__main']/div/form/div[2]/div/div/div[1]/div/div/div[2]/a"));

        #endregion
        public void CartMethod()
        {
            #region Cart_Method


            #endregion


            FindElement(Accessories);
            for (int i = 0; i <= 4; i++)
            {
                FindElement(Search_First_Result);
                FindElement(Add_Cart);
                FindElement(Cart_Pop_Up);
            }
            FindElement(Cart_Icon);
            
            for (int i = 0; i <= 4; i++)
            {
                string count = GetElementText(Cart_Count);
                if (count != "0")
                {
                    FindElement(Cart_Delete);
                }
                
            }
            string count1 = GetElementText(Cart_Count);
            AssertEqual("0", count1);

        }

    }
}
