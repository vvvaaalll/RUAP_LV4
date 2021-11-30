using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using RUAP_LV4;

namespace SeleniumTests
{
    [TestFixture]
    public class TestCase5PrijavaKorisnikaIShoppingCart
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private LoginInfo loginInfo = new LoginInfo("vlobodaaa@etfos.hr", "123456");


        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheCase5PrijavaKorisnikaIShoppingCartTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/i")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("vlobodaaa@etfos.hr");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("123456");
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-password")).Click();
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.FindElement(By.LinkText("Phones & PDAs")).Click();
            driver.FindElement(By.XPath("//img[@alt='iPhone']")).Click();
            driver.FindElement(By.Id("button-cart")).Click();
            driver.FindElement(By.Id("cart-total")).Click();
            driver.FindElement(By.XPath("//div[@id='cart']/ul/li[2]/div/p/a/strong")).Click();
            driver.FindElement(By.Name("quantity[790384]")).Click();
            driver.FindElement(By.Name("quantity[790384]")).Clear();
            driver.FindElement(By.Name("quantity[790384]")).SendKeys("3");
            driver.FindElement(By.XPath("//div[@id='content']/form/div/table/tbody/tr/td[4]")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form/div/table/tbody/tr/td[4]/div/span/button/i")).Click();
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
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
