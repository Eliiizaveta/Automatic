using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Lab4_WSA.po;
using Lab4_WSA.business_objects;
using Lab4_WSA.tests;
using Lab4_WSA.service.ui;

namespace Lab4_WSA
{
    public class UnitTest1 : BaseTest
    {
      
        private LoginPage loginPage;
        private HomePage homePage;
        private AllPrPage allPrPage;
        private AddPrPage addPrPage;
        private EditPrPage editPrPage;
        private User newUser = new User("user", "user");
        private Product product = new Product("NewProduct", "Beverages", "Exotic Liquids", "333", "300", "444", "22", "33");



        [Test, Order(1)]
        public void Login()
        {
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            loginPage.AutorizationTest(newUser);
            Assert.AreEqual("Home page", homePage.FindHomePage());
        }

        [Test, Order(2)]
        public void AddNewProduct()
        {
            editPrPage = new EditPrPage(driver);
            Assert.AreNotEqual(editPrPage.Close(), ProductUi.NewProduct(product, driver));
        }

        [Test, Order(3)]
        public void CheckProduct()
        {
            allPrPage = new AllPrPage(driver);
            editPrPage = new EditPrPage(driver);
            allPrPage.ToEditProduct(product);

            Assert.Multiple(() => 
            { 
            Assert.AreEqual(product.ProductName, editPrPage.ProductName());
            Assert.AreEqual(product.CategoryId, editPrPage.Category());
            Assert.AreEqual(product.SupplierId, editPrPage.Supplier());
            Assert.AreEqual(product.UnitPrice + ",0000", editPrPage.UnitPrice());
            Assert.AreEqual(product.QuantityPerUnit, editPrPage.QuantityPerUnit());
            Assert.AreEqual(product.UnitsInStock, editPrPage.UnitsInStock());
            Assert.AreEqual(product.UnitsOnOrder, editPrPage.UnitsOnOrder());
            Assert.AreEqual(product.ReorderLevel, editPrPage.ReorderLevel());

        });
        }
    [Test, Order(4)]

        public void Logout()
        {
            homePage.ToLogOut();
            Assert.AreEqual("Login", loginPage.ToLogInput()); ;
        }

       
    }
}

