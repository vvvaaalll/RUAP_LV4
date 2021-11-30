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
    public class TestCase1Registracija
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        private LoginInfo loginInfo = new LoginInfo("vl@etfos.hr", "123456");


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
        public void TheCase1RegistracijaTest()
        {
            driver.Navigate().GoToUrl("https://demo.opencart.com/");
            driver.FindElement(By.LinkText("My Account")).Click();
            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("input-firstname")).Click();
            driver.FindElement(By.Id("input-firstname")).Click();
            driver.FindElement(By.Id("input-firstname")).Clear();
            driver.FindElement(By.Id("input-firstname")).SendKeys("valentin");
            driver.FindElement(By.Id("input-lastname")).Clear();
            driver.FindElement(By.Id("input-lastname")).SendKeys("Loboda");
            driver.FindElement(By.Id("input-email")).Clear();
            driver.FindElement(By.Id("input-email")).SendKeys(loginInfo.getEmail());
            driver.FindElement(By.Id("input-telephone")).Clear();
            driver.FindElement(By.Id("input-telephone")).SendKeys("123456789");
            driver.FindElement(By.Id("input-telephone")).SendKeys(Keys.Down);
            driver.FindElement(By.Id("input-telephone")).Clear();
            driver.FindElement(By.Id("input-telephone")).SendKeys("123456789");
            driver.FindElement(By.Id("input-password")).Click();
            driver.FindElement(By.Id("input-password")).Clear();
            driver.FindElement(By.Id("input-password")).SendKeys(loginInfo.getPassword());
            driver.FindElement(By.XPath("//div[@id='account-register']/div")).Click();
            driver.FindElement(By.Id("input-confirm")).Click();
            driver.FindElement(By.Id("input-confirm")).Clear();
            driver.FindElement(By.Id("input-confirm")).SendKeys("123456");
            driver.FindElement(By.XPath("//div[@id='content']/form/fieldset[3]/legend")).Click();
            driver.FindElement(By.XPath("//div[@id='content']/form/fieldset[3]/div/div/label[2]/input")).Click();
            driver.FindElement(By.Name("agree")).Click();
            driver.FindElement(By.XPath("//input[@value='Continue']")).Click();
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
