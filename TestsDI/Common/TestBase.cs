using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects.PageObjects;
using Utils.Common;
using Utils.Reports.Extent;
using Autofac;

namespace TestsDI.Common;

//
// Summary:
//      Setup and teardown methods
internal class TestBase
{
    protected IWebDriver? Driver { get; private set; }
    protected WebFormPage? WebForm { get; private set; }
    protected IBrowser? Browser { get; private set; }

    [SetUp]
    public void Setup()
    {
        var container = ContainerConfig.Configure();

        ExtentReporting.Instance.CreateTest(
            TestContext.CurrentContext.Test.MethodName ??
            $"Test{Environment.CurrentManagedThreadId}"
        );

        Driver = container.Resolve<IWebDriver>();

        Driver.Manage().Window.Maximize();
        //this can be moved to JSON config
        Driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        Browser = container.Resolve<IBrowser>();

        WebForm = container.Resolve<WebFormPage>();
    }

    [TearDown]
    public void TearDown()
    {
        try
        {
            EndTest();
            ExtentReporting.Instance.EndReporting();
        }
        finally
        {
            Driver?.Quit();
        }

    }

    private void EndTest()
    {
        var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        var message = TestContext.CurrentContext.Result.Message;

        switch (testStatus)
        {
            case TestStatus.Failed:
                ExtentReporting.Instance.LogFail($"Test has failed {message}");
                break;
            case TestStatus.Skipped:
                ExtentReporting.Instance.LogInfo($"Test skipped {message}");
                break;
            default:
                break;
        }

        ExtentReporting.Instance.LogScreenshot("Ending test", Browser?.GetScreenshot());
    }
}