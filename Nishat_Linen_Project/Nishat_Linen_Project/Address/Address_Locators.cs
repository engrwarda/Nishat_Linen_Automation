using AutomationFramework;
using OpenQA.Selenium;

namespace Nishat_Linen_Project.Address
{
    public class AddressClass:BaseClass
    {
        #region  Address_Locators
        By Address = (By.XPath("//a[@href='/account/addresses']"));
        By Address_Delete = (By.XPath("//*[@id='shopify-section-template--16149187231943__main']/div/div[2]/ul/li/button[2]"));
        By Address_Add = (By.XPath("//button[@aria-controls ='AddAddress']"));
        By First_Name = (By.Id("AddressFirstNameNew"));
        By Last_Name = (By.Id("AddressLastNameNew"));
        By Address_Company = (By.Id("AddressCompanyNew"));
        By Address_New = (By.Id("AddressAddress1New"));
        By Address_City = (By.Id("AddressCityNew"));
        By Address_ZipCode = (By.Id("AddressZipNew"));
        By Address_Phone = (By.Id("AddressPhoneNew"));
        By Address_Default_CheckBox = (By.Id("address_default_address_new"));
        By Add_Adress_Btn = (By.XPath("//button[text() ='Add Address']"));
        By Address_Validator = (By.XPath("//*[@id='shopify-section-template--16149187231943__main']/div/div[1]/nav/ul/li[2]/a"));
        #endregion
        public void AddressMethod()
        {
            #region Address_Method

            FindElement(Address);
            FindElement(Address_Delete);
            driver.SwitchTo().Alert().Accept();
            PlaybackWait(2000);
            string addressText = GetElementText(Address_Validator);
            AssertEqual("Addresses (0)", addressText);
            FindElement(Address_Add);
            SendKeysMethod(First_Name, "Warda");
            SendKeysMethod(Last_Name, "Javed");
            SendKeysMethod(Address_Company, "Contour-Techlift");
            SendKeysMethod(Address_New, "House#92 Rehman Park Multan");
            SendKeysMethod(Address_City, " Multan");
            SendKeysMethod(Address_ZipCode, "54000 ");
            SendKeysMethod(Address_Phone, "03331712423 ");
            FindElement(Address_Default_CheckBox);
            FindElement(Add_Adress_Btn);

            string addressText1 = GetElementText(Address_Validator);
            AssertEqual("Addresses (1)", addressText1);
            #endregion

        }


    }
}
