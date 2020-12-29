using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using OpenQA.Selenium.Interactions;
namespace Lab4_WSA.po
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement HomePageSelect => driver.FindElement(By.XPath("//h2"));
        private IWebElement AllProductsSelect => driver.FindElement(By.LinkText("All Products"));
        private IWebElement LogoutButton => driver.FindElement(By.LinkText("Logout"));

        public string FindHomePage()
        {
            return HomePageSelect.Text;
        }

        public void ToAllProducts()
        {
            new Actions(driver).MoveToElement(AllProductsSelect).Click(AllProductsSelect).Build().Perform();
        }

        public void ToLogOut()
        {
            new Actions(driver).MoveToElement(LogoutButton).Click(LogoutButton).Build().Perform();
        }
    }
}
