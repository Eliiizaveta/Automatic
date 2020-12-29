using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using Lab4_WSA.po;
using Lab4_WSA.business_objects;
using Lab4_WSA.tests;

namespace Lab4_WSA.service.ui
{
     class UserUi
        
    {
       

        public string UserU(User user, IWebDriver driver)
        {
            LoginPage loginPage = new LoginPage(driver);
            HomePage homePage = new HomePage(driver);
            loginPage.AutorizationTest(user);
            return homePage.FindHomePage();
        }
    }
}