using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class TestCase3PrijavaIOdjava
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
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
        public void TheCase3PrijavaIOdjavaTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.LinkText("My Account")).Click();
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys("vloboda@etfos.hr");
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys("123456");
            driver.FindElement(By.Id("input-email")).Click();
            driver.FindElement(By.Id("input-email")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | id=input-email | ]]
            driver.FindElement(By.Id("input-password")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/form/div")).Click();
            driver.FindElement(By.Id("input-password")).Click();
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            driver.FindElement(By.XPath("//div[@id='top-links']/ul/li[2]/a/i")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
            driver.FindElement(By.LinkText("Continue")).Click();
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
