using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework
{
    public class BaseClass
    {

        public static IWebDriver driver;

        public static void InitDriver(string browser)
        {
            if (browser == "chrome")
            {
                driver = new ChromeDriver();
                OpenUrl("https://nishatlinen.com/");
                driver.Manage().Window.Maximize();
            }
            else if (browser == "firefox")
            {
                driver = new FirefoxDriver();
                OpenUrl("https://nishatlinen.com/");
            }
            else if (browser == "edge")
            {
                driver = new EdgeDriver();
                OpenUrl("https://nishatlinen.com/");
            }
        }

        public static void CloseDriver()
        {
            driver.Close();
        }

        #region FindElement
        public void FindElement(By locator, double timeoutInSeconds = 60)
        {
            if (timeoutInSeconds == 0)
            {
                driver.FindElement(locator);
                ClickElement(locator);
            }
            else
            {

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
                ClickElement(locator);
            }

        }
        #endregion

        #region NonVoidFindElement

        //public string FindElementString(By locator, double timeoutInSeconds = 60)
        //{
        //    if (timeoutInSeconds == 0)
        //    {
        //        driver.FindElement(locator).Text;
        //        ClickElement(locator);
        //    }
        //    else
        //    {

        //        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //        wait.Until(ExpectedConditions.ElementIsVisible(locator));
        //        ClickElement(locator);
        //    }
        //    return ("string");
        //}
        

        #endregion

        #region SendKeys
        public void SendKeysWithoutClaer(By locator, string text)
        {
            driver.FindElement(locator).SendKeys(text);
        }
        #endregion


        #region SendKeys
        public void SendKeysMethod(By locator, string text)
        {
            if (driver.FindElement(locator).GetAttribute("value") != " ")
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
            else
            {
                driver.FindElement(locator).SendKeys(text);
            }
        }
        #endregion

        #region SimpleClick
        public void ClickElement(By locator)
        {
            driver.FindElement(locator).Click();
        }
        #endregion

        public void Write(By by, string value)
        {
            driver.FindElement(by).SendKeys(value);
        }

        public void Click(By by)
        {
            driver.FindElement(by).Click();
        }

        public void Clear(By by)
        {
            driver.FindElement(by).Clear();
        }

        public static void OpenUrl(string url)
        {
            driver.Url = url;
        }
        public void AssertEqual(string ex, string actual)
        {
            Assert.AreEqual(ex, actual);
        }

        public bool AssertEquals(string first, string second)
        {
            return Assert.Equals(first, second);
        }
        public string GetAttribute(string type, By loc)
        {
            IWebElement element = driver.FindElement(loc);
            string value = null;
            if (type == "text")
            {
                return value = element.GetAttribute(type).ToString();
            }
            else if (type == "value")
            {
                return value = element.GetAttribute(type).ToString();
            }
            else if (type == "innerHTML")
            {
                return value = element.GetAttribute(type).ToString();
            }
            return value;
        }
        public string GetElementText(By by)
        {
            string text;
            try
            {
                text = driver.FindElement(by).Text;
            }
            catch
            {
                try
                {
                    text = driver.FindElement(by).GetAttribute("value");
                }
                catch
                {
                    text = driver.FindElement(by).GetAttribute("innerHTML");
                }
            }
            return text;
        }

        public string GetElementValue(By by)
        {
            string text = driver.FindElement(by).GetAttribute("value");
            return text;

        }
        public string GetElementState(By by)
        {
            string elementState = driver.FindElement(by).GetAttribute("Disabled"); if (elementState == null)
            {
                elementState = "enabled";
            }
            else if (elementState == "true")
            {
                elementState = "disabled";
            }
            return elementState;
        }

        public static void PlaybackWait(int miliSeconds)
        {
            Thread.Sleep(miliSeconds);
        }

        public static string ExecuteJavaScriptCode(string javascriptCode)
        {
            string value = null;
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver; value = (string)js.ExecuteScript(javascriptCode);
            }
            catch (Exception)
            {
            }
            return value;
        }

        private bool IsElementTextField(By by)
        {
            try
            {
                bool resultText = Convert.ToBoolean(driver.FindElement(by)
                .GetAttribute("type")
                .Equals("text"));
                bool resultPass = Convert.ToBoolean(driver.FindElement(by)
                .GetAttribute("type")
                .Equals("password"));
                if (resultText == true || resultPass == true)
                { return true; }
                else
                { return false; }
            }
            catch
            {
                return false;
            }
        }


        public IWebElement WaitforElement(By by, int timeToReadyElement = 0)
        {
            IWebElement element = null;
            try
            {
                if (timeToReadyElement != 0 && timeToReadyElement.ToString() != null)
                {
                    PlaybackWait(timeToReadyElement * 1000);
                }
                element = driver.FindElement(by);
            }
            catch
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                wait.Until(driver => IsPageReady(driver) == true && IsElementVisible(by) == true && IsClickable(by) == true);
                element = driver.FindElement(by);
            }
            return element;
        }


        private bool IsPageReady(IWebDriver driver)
        {
            return ((IJavaScriptExecutor)driver)
            .ExecuteScript("return document.readyState").Equals("complete");
        }


        private bool IsElementVisible(By by)
        {
            if (driver.FindElement(by)
            .Displayed || driver.FindElement(by).Enabled)
            {
                return true;
            }
            else
            { return false; }
        }


        private bool IsClickable(By by)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }


        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static void NavigateBack()
        {
            driver.Navigate().Back();
        }

        public void ElementSelection(By by)
        {
            FindElement(by);
        }


        public static void Validate(string expected, string actul)
        {
            Assert.AreEqual(expected, actul);
        }

        public static void Hover(By HoverGear)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(HoverGear));

            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }
    }
}
            //IWebDriver Driver = new ChromeDriver();
            //Driver.Url = ("https://nishatlinen.com/");
            //Driver.Manage().Window.Maximize();
            //Thread.Sleep(2000);
            //Actions action = new Actions(Driver);
            //IWebElement Luxury = Driver.FindElement(By.XPath("//a[@href='/collections/luxury']"));
            //action.MoveToElement(Luxury).Perform();
            //Thread.Sleep(1000);
            //IWebElement Luxury_Pret_Embroidered = Driver.FindElement(By.XPath("//a[@href='/collections/luxury-pret-embroidered']"));
            //action.MoveToElement(Luxury_Pret_Embroidered).Perform();
            //Luxury_Pret_Embroidered.Click();
