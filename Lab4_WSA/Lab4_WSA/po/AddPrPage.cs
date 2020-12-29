using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;
using Lab4_WSA.business_objects;

namespace Lab4_WSA.po
{
    class AddPrPage
    {
        private IWebDriver driver;

        public AddPrPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement ProductNameInput => driver.FindElement(By.Id("ProductName"));
        private IWebElement CategoryIdInput => driver.FindElement(By.Id("CategoryId"));
        private IWebElement SupplierIdInput => driver.FindElement(By.Id("SupplierId"));
        private IWebElement UnitPriceInput => driver.FindElement(By.Id("UnitPrice"));
        private IWebElement QuantityPerUnitInput => driver.FindElement(By.Id("QuantityPerUnit"));
        private IWebElement UnitsInStockInput => driver.FindElement(By.Id("UnitsInStock"));
        private IWebElement UnitsOnOrderInput => driver.FindElement(By.Id("UnitsOnOrder"));
        private IWebElement ReorderLevelInput => driver.FindElement(By.Id("ReorderLevel"));
        private IWebElement AddButton => driver.FindElement(By.CssSelector(".btn"));

        public void TestNewProduct(Product product)
        {
            new Actions(driver).SendKeys(ProductNameInput, product.ProductName).Build().Perform();
            new Actions(driver).SendKeys(CategoryIdInput, product.CategoryId).Build().Perform();
            new Actions(driver).SendKeys(SupplierIdInput, product.SupplierId).Build().Perform();
            new Actions(driver).SendKeys(UnitPriceInput, product.UnitPrice).Build().Perform();
            new Actions(driver).SendKeys(QuantityPerUnitInput, product.QuantityPerUnit).Build().Perform();
            new Actions(driver).SendKeys(UnitsInStockInput, product.UnitsOnOrder).Build().Perform();
            new Actions(driver).SendKeys(UnitsOnOrderInput, product.UnitsOnOrder).Build().Perform();
            new Actions(driver).SendKeys(ReorderLevelInput, product.ReorderLevel).Build().Perform();
            new Actions(driver).MoveToElement(AddButton).Click(AddButton).Build().Perform();
        }
    }
}

