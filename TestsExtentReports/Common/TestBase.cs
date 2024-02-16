using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using PageObjects.PageObjects;
using Utils.Common;
using Utils.Reports.Extent;

namespace TestsExtentReports.Common
{
    internal class TestBase
    {
        protected IWebDriver Driver { get; private set; }
        protected WebFormPage WebForm { get; private set; }
        protected Browser Browser { get; private set; }

        [SetUp]
        public void Setup()
        {
            ExtentReporting.Instance.CreateTest(TestContext.CurrentContext.Test.MethodName);

            //this can be updated to work for multiple browsers (e.g. based on a value set in JSON config)
            Driver = new ChromeDriver();
            
            Driver.Manage().Window.Maximize();
            //this can be moved to JSON config
            Driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Browser = new Browser(Driver);

            WebForm = new WebFormPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            EndTest();
            ExtentReporting.Instance.EndReporting();

            Driver.Quit();
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

            ExtentReporting.Instance.LogScreenshot("Ending test", Browser.GetScreenshot());
        }
    }
}
