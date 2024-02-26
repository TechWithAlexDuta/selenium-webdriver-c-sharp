using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TestsSeleniumWebDriverBasics.Tests;
//
// Summary:
//      Relative locators tests
// Run:
//      dotnet test .\bin\Debug\<net_version>\<project_name>>.dll
internal class RelativeLocatorsTests
{
    [Test]
    public void RelativeLocatorsTest()
    {
        IWebDriver driver = new ChromeDriver();

        driver.Manage().Window.Maximize();

        driver.Navigate().GoToUrl("https://www.selenium.dev/");

        Assert.That(driver.Title, Is.EqualTo("Selenium"));

        var knownXpath = "//h4[text()='Selenium IDE']";

        var rightOfSample = driver.FindElement(RelativeBy.WithLocator(By.TagName("h4")).RightOf(By.XPath(knownXpath))).Text;
        var leftOfSample = driver.FindElement(RelativeBy.WithLocator(By.TagName("h4")).LeftOf(By.XPath(knownXpath))).Text;
        var belowSample = driver.FindElement(RelativeBy.WithLocator(By.TagName("a")).Below(By.XPath(knownXpath))).Text;
        var aboveSample = driver.FindElement(RelativeBy.WithLocator(By.TagName("h2")).Above(By.XPath(knownXpath))).Text;

        var h2webElement = driver.FindElement(RelativeBy.WithLocator(By.TagName("h2")).Above(By.XPath(knownXpath)));

        var chainSample = driver
            .FindElement(RelativeBy.WithLocator(By.TagName("h4"))
            .LeftOf(By.XPath(knownXpath))
            .Below(h2webElement))
            .Text;

        var results = new List<string>() {
                 "[heading] right 'Selenium IDE': " + rightOfSample,
                 "[heading] left 'Selenium IDE': " + leftOfSample,
                 "[link] below 'Selenium IDE': " + belowSample,
                 "[heading] above 'Selenium IDE': " + aboveSample,
                 "[heading] left of 'Selenium IDE' and below 'Getting Started':" + chainSample
             };

        File.WriteAllLines("results", results);

        driver.Quit();
    }
}