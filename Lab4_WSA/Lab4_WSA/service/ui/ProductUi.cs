using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Lab4_WSA.po;
using Lab4_WSA.business_objects;
using Lab4_WSA.tests;
using Lab4_WSA.service.ui;
namespace Lab4_WSA.service.ui
{
    class ProductUi
    {
        public static string NewProduct(Product product, IWebDriver driver)
        {
            AllPrPage allPrPage = new AllPrPage(driver);
            AddPrPage  addPrPage = new AddPrPage(driver);
            HomePage homepage = new HomePage(driver);
            homepage.ToAllProducts();
            allPrPage.ToNewProduct();
            addPrPage.TestNewProduct(product);
            return allPrPage.CloseFormEdit();
        }
       
    }
}
