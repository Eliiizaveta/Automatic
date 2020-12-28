using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;

namespace Lab4_WSA.po
{
    class AllPrPage
    {
        private IWebDriver driver;

        public AllPrPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement AddProductButton => driver.FindElement(By.LinkText("Create new"));
        private IWebElement EditProductButton => driver.FindElement(By.LinkText("NewProduct"));
        private IWebElement CloseForm => driver.FindElement(By.XPath("//h2"));

        public void ToNewProduct()
        {
            new Actions(driver).MoveToElement(AddProductButton).Click(AddProductButton).Build().Perform();
        }

        public void ToEditProduct()
        {
            new Actions(driver).MoveToElement(EditProductButton).Click(EditProductButton).Build().Perform();
        }

        public string CloseFormEdit()
        {
            return CloseForm.Text;
        }


    }
}
