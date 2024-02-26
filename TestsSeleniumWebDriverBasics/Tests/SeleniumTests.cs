using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestsSeleniumWebDriverBasics.Tests;
//
// Summary:
//     Selenium hello world tests
// Run:
//      dotnet test .\bin\Debug\<net_version>\<project_name>>.dll
public class SeleniumTests
{
    [Test]
    public void FirstSeleniumTest()
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.selenium.dev/");

        Assert.That(driver.Title, Is.EqualTo("Selenium"));

        driver.Quit();
    }
}