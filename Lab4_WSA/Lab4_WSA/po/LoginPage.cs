using Lab4_WSA.business_objects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Lab4_WSA.po
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement NameInput => driver.FindElement(By.Id("Name"));
        private IWebElement PasswordInput => driver.FindElement(By.Id("Password"));
        private IWebElement AutorizationButton => driver.FindElement(By.CssSelector(".btn"));
        private IWebElement LogInput => driver.FindElement(By.XPath("//h2"));

        public void AutorizationTest(User user)
        {
            new Actions(driver).SendKeys(NameInput, user.UserName).Build().Perform();
            new Actions(driver).SendKeys(PasswordInput, user.UserPassword).Build().Perform();
            new Actions(driver).MoveToElement(AutorizationButton).Click(AutorizationButton).Build().Perform();
        }

        public string ToLogInput()
        {
            return LogInput.Text;
        }

    }
}
