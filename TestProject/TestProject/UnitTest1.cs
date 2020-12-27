using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProject
{
    public class UnitTest1
    {
        private static IWebDriver driver;
        private WebDriverWait pause;
        private static bool IsElementPresent(By locator)
        {
            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void Login()
        {
            driver.FindElement(By.Id("Name")).SendKeys("user");
            driver.FindElement(By.Id("Password")).SendKeys("user");
            driver.FindElement(By.CssSelector(".btn")).Click();
            driver.FindElement(By.XPath("//li/a[@href=\"/Product\"]")).Click();
        }
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            pause = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            
        }

        [Test]
        public void Autorisation()
        {
            Login();
            bool Element = IsElementPresent(By.XPath("//a[@href=\"/Product/Create\"]"));
            Assert.IsTrue(Element);
        }
        [Test]
       public void AddNewProduct()
        {
            Login();
            driver.FindElement(By.XPath("//a[@href=\"/Product/Create\"]")).Click();
            driver.FindElement(By.Id("ProductName")).SendKeys("NewProduct");
            driver.FindElement(By.XPath("//select[@id=\"CategoryId\"]//option[@value=\"1\"]")).Click();
            driver.FindElement(By.XPath("//select[@id=\"SupplierId\"]//option[@value=\"1\"]")).Click();
            driver.FindElement(By.Id("UnitPrice")).SendKeys("333");
            driver.FindElement(By.Id("QuantityPerUnit")).SendKeys("300");
            driver.FindElement(By.Id("UnitsInStock")).SendKeys("444");
            driver.FindElement(By.Id("UnitsOnOrder")).SendKeys("22");
            driver.FindElement(By.Id("ReorderLevel")).SendKeys("33");
            driver.FindElement(By.CssSelector(".btn")).Click();
            bool Element = IsElementPresent(By.XPath("//a[@href=\"/Product/Create\"]"));
            Assert.IsTrue(Element);

        }
        [Test]
        public void CheckProduct()
        {
            Login();
            driver.FindElement(By.LinkText("NewProduct")).Click();
            Assert.IsNotEmpty(driver.FindElement(By.Id("ProductId")).GetAttribute("value"));
            Assert.AreEqual("NewProduct", driver.FindElement(By.Id("ProductName")).GetAttribute("value"));
            var categoryId = driver.FindElement(By.XPath("//select[@id=\"CategoryId\"]//option[@value=\"1\"]")).GetAttribute("value");
            var supplierId = driver.FindElement(By.XPath("//select[@id=\"SupplierId\"]//option[@value=\"1\"]")).GetAttribute("value");
            Assert.AreEqual("1", categoryId);
            Assert.AreEqual("1", supplierId);
            Assert.AreEqual("333,0000", driver.FindElement(By.Id("UnitPrice")).GetAttribute("value"));
            Assert.AreEqual("300", driver.FindElement(By.Id("QuantityPerUnit")).GetAttribute("value"));
            Assert.AreEqual("444", driver.FindElement(By.Id("UnitsInStock")).GetAttribute("value"));
            Assert.AreEqual("22", driver.FindElement(By.Id("UnitsOnOrder")).GetAttribute("value"));
            Assert.AreEqual("33", driver.FindElement(By.Id("ReorderLevel")).GetAttribute("value"));

        }
        [Test]
          public void Logout()
        {
            Login();
            bool ElementLogout = IsElementPresent(By.XPath("//header//*[@href='/Account/Logout']"));
            Assert.IsTrue(ElementLogout);
            driver.FindElement(By.LinkText("Logout")).Click();
            bool LoginN = IsElementPresent(By.Id("Name"));
            Assert.IsTrue(LoginN);
        }


        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }

    }
}