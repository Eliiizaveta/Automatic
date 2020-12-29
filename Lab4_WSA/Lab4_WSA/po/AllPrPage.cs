using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;
using Lab4_WSA.business_objects;

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
        public void ToNewProduct()
        {
            new Actions(driver).MoveToElement(AddProductButton).Click(AddProductButton).Build().Perform();
        }

        public void ToEditProduct(Product product)
        {
            new Actions(driver).MoveToElement(EditProductButton).Click(EditProductButton).Build().Perform();
        }

        public string CloseFormEdit()
        {
            return CloseForm.Text;
        }
        public bool GetCreateNewSelector()
        {
            return IsElementPresent(By.LinkText("Create new"));
        }

    }
}
