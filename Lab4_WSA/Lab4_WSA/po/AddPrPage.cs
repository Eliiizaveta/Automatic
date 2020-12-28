using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;

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

        public void TestNewProduct(string productname, string categoryName, string supplierName, string unitPrice, string quantityPerUnit, string unitsInStock, string unitsOnOrder, string recorderLevel)
        {
            new Actions(driver).SendKeys(ProductNameInput, productname).Build().Perform();
            new Actions(driver).SendKeys(CategoryIdInput, categoryName).Build().Perform();
            new Actions(driver).SendKeys(SupplierIdInput, supplierName).Build().Perform();
            new Actions(driver).SendKeys(UnitPriceInput, unitPrice).Build().Perform();
            new Actions(driver).SendKeys(QuantityPerUnitInput, quantityPerUnit).Build().Perform();
            new Actions(driver).SendKeys(UnitsInStockInput, unitsInStock).Build().Perform();
            new Actions(driver).SendKeys(UnitsOnOrderInput, unitsOnOrder).Build().Perform();
            new Actions(driver).SendKeys(ReorderLevelInput, recorderLevel).Build().Perform();
            new Actions(driver).MoveToElement(AddButton).Click(AddButton).Build().Perform();
        }
    }
}

