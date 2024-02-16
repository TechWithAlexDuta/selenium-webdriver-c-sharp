using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriverProject.Tests
{
    internal class LocatorsTests
    {
        [Test]
        public void LocatorsTest()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.selenium.dev/");

            Assert.That(driver.Title, Is.EqualTo("Selenium"));

            //class name
            //search is not available on landing page (tested on 16.02.2024), you can use another class name like: navbar-brand
            var classNameValidator = driver.FindElement(By.ClassName("DocSearch")).Displayed;
            Assert.That(classNameValidator, Is.EqualTo(true));

            //css selector
            //search is not available on landing page (tested on 16.02.2024), you can use another css selector like .navbar-brand
            var cssSelectorValidator = driver.FindElement(By.CssSelector(".DocSearch")).Displayed;
            Assert.That(cssSelectorValidator, Is.EqualTo(true));

            //id
            var idValidator = driver.FindElement(By.Id("selenium_logo")).Displayed;
            Assert.That(idValidator, Is.EqualTo(true));

            //name
            var nameVlidator = driver.FindElement(By.Name("submit")).Displayed;
            Assert.That(nameVlidator, Is.EqualTo(true));

            //link text
            var linkTextValidator = driver.FindElement(By.LinkText("Documentation")).Displayed;
            Assert.That(linkTextValidator, Is.EqualTo(true));

            //partial link text
            var partialLinkTextValidator = driver.FindElement(By.PartialLinkText("Doc")).Displayed;
            Assert.That(partialLinkTextValidator, Is.EqualTo(true));

            //tag
            var tagValidator = driver.FindElement(By.TagName("nav")).Displayed;
            Assert.That(tagValidator, Is.EqualTo(true));

            //xpath
            var xpathValidator = driver.FindElement(By.XPath("//h1")).Displayed;
            Assert.That(xpathValidator, Is.EqualTo(true));

            driver.Quit();
        }
    }
}
