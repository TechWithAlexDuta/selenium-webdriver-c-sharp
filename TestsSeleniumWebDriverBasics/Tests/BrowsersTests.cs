using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace TestsSeleniumWebDriverBasics.Tests;

//
// Summary:
//      Browsers instantiation tests
// Run:
//      dotnet test .\bin\Debug\<net_version>\<project_name>>.dll
internal class BrowsersTests
{
    [Test]
    public void ChromeBrowser()
    {
        IWebDriver driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://www.selenium.dev/");

        Assert.That(driver.Title, Is.EqualTo("Selenium"));

        driver.Quit();
    }

    [Test]
    public void FirefoxBrowser()
    {
        IWebDriver driver = new FirefoxDriver();

        driver.Navigate().GoToUrl("https://www.selenium.dev/");

        Assert.That(driver.Title, Is.EqualTo("Selenium"));

        driver.Quit();
    }

    [Test]
    public void EdgeBrowser()
    {
        IWebDriver driver = new EdgeDriver();

        driver.Navigate().GoToUrl("https://www.selenium.dev/");

        Assert.That(driver.Title, Is.EqualTo("Selenium"));

        driver.Quit();
    }
}