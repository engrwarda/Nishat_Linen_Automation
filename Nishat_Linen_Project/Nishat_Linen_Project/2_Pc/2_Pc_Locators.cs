using AutomationFramework;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Nishat_Linen_Project._2_Pc
{

    public class TwoPieceClass : BaseClass
    {
        #region Two_Piece_Locators

        By Search = (By.XPath("//div[@class ='t4s-site-nav__icon t4s-site-nav__search']"));
        By Search_Field = (By.Name("q"));
        By Submit_Btn = (By.XPath("//button[@class = 't4s-mini-search__submit t4s-btn-loading__svg']"));
        By Select_Dress = (By.CssSelector(".t4s-full-width-link"));
        //By Select_Size = (By.XPath("//div[@data-value='M']"));
        By Select_Size = (By.XPath("//*[@id='product-form-7641672876231template--16149187690695__main']/div[1]/div/div/div[3]"));
        By Sold_Out = (By.XPath("//span[@class ='t4s-btn-atc_text']"));
        By Notify_Me = (By.XPath("//div[@class = 'email-me-button email-me-inlineButton']"));
        By Notify_Me_Size = (By.CssSelector(".selected-unavailable-variant option[value='43127143694535']"));
        By Notify_Me_Name = (By.XPath(" //input[@class = 'buyer-name']"));
        By Notify_Me_Email = (By.XPath(" //input[@class = 'buyer-email']"));
        By Notify_Me_Btn = (By.XPath("//div[@class = 'email-me-button email-me-submitButton']"));



        #endregion


        public void TwoPieceMethod()
        {
            #region Two_Piece_Method

            FindElement(Search);
            SendKeysMethod(Search_Field, "2 Piece-Embroidered Suit-PE23-23");
            FindElement(Submit_Btn);
            FindElement(Select_Dress);
            FindElement(Select_Size);
            string soldOut = GetElementText(Sold_Out);
            if (soldOut == "OUT OF STOCK")
            {
                FindElement(Notify_Me);

                //SendKeysWithoutClaer(Notify_Me_Size, "M");
                SendKeysWithoutClaer(Notify_Me_Name, "Warda Javed");
                SendKeysWithoutClaer(Notify_Me_Email, "wardaj@gmail.com");
                FindElement(Notify_Me_Btn);
            }


            #endregion
        }
        public string validation()
        {
            return GetAttribute("text", Sold_Out);
        }
        ////if (Assert.Equals(Sold_Out.Text, "OUT OF STOCK"))
        //Assert.Equals("OUT OF STOCK", Sold_Out.ToString());
        //if (Sold_Out == "OUT OF STOCK") { 

        //     Click(Notify_Me);
        //    Click(Notify_Me_Size);
        //    SendKeysMethod(Notify_Me_Name, "Warda Javed");
        //    SendKeysMethod(Notify_Me_Email, "DrwardaJaved2@gmail.com");
        //    Click(Notify_Me_Btn);
        //}
    }

}

