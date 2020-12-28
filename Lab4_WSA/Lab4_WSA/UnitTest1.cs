using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Lab4_WSA.po;

namespace Lab4_WSA
{
    public class UnitTest1
    {
        private IWebDriver driver;
        private WebDriverWait pause;

        private LoginPage loginPage;
        private HomePage homePage;
        private AllPrPage allPrPage;
        private AddPrPage addPrPage;
        private EditPrPage editPrPage;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            pause = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        [Test, Order(1)]
        public void Login()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            loginPage.AutorizationTest("user");
            Assert.AreEqual("Home page", homePage.FindHomePage());
        }

        [Test, Order(2)]
        public void AddNewProduct()
        {
            allPrPage = new AllPrPage(driver);
            addPrPage = new AddPrPage(driver);
            homePage.ToAllProducts();
            allPrPage.ToNewProduct();
            addPrPage.TestNewProduct("NewProduct", "Beverages", "Exotic Liquids", "333", "300", "444", "22", "33");
            Assert.AreNotEqual("editing", allPrPage.CloseFormEdit());
        }

        [Test, Order(3)]
        public void CheckProduct()
        {
            editPrPage = new EditPrPage(driver);
            allPrPage.ToEditProduct();
            Assert.AreEqual("NewProduct", editPrPage.ProductName());
            Assert.AreEqual("Beverages", editPrPage.Category());
            Assert.AreEqual("Exotic Liquids", editPrPage.Supplier());
            Assert.AreEqual("333,0000", editPrPage.UnitPrice());
            Assert.AreEqual("300", editPrPage.QuantityPerUnit());
            Assert.AreEqual("444", editPrPage.UnitsInStock());
            Assert.AreEqual("22", editPrPage.UnitsOnOrder());
            Assert.AreEqual("33", editPrPage.ReorderLevel());

        }
        [Test, Order(4)]

        public void Logout()
        {
            homePage.ToLogOut();
            Assert.AreEqual("Login", loginPage.ToLogInput()); ;
        }

        [OneTimeTearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
    }
}

