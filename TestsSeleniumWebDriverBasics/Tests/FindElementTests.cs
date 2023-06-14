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
    internal class FindElementTests
    {
        [Test]
        public void LocatorsTest()
        {
            var results = new List<string>();

            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.selenium.dev/");

            Assert.That(driver.Title, Is.EqualTo("Selenium"));

            //FindElement
            var firstH2 = driver.FindElement(By.XPath("//h2"));
            results.Add($"FindElement: {firstH2.Text}");

            //FindElements
            var h2Collection = driver.FindElements(By.XPath("//h2"));
            foreach (var h2 in h2Collection)
            {
                results.Add($"FindElements: {h2.Text}");
            }

            //evaluate a subset of the DOM
            var parentElement = driver.FindElement(By.CssSelector("div[id='main_navbar']"));
            var links = parentElement.FindElements(By.TagName("a"));
            foreach (var link in links)
            {
                var result = link.Text;
                if (!string.IsNullOrEmpty(result))
                {
                    results.Add($"links: {link.Text}");
                }
            }

            File.WriteAllLines("results", results);

            driver.Quit();
        }
    }
}
