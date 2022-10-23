using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace NUnitTests.Tests
{
    public class BaseTests
    {
        protected IWebDriver driver;


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://www.skyscrapercenter.com/buildings?list=tallest100-construction");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
