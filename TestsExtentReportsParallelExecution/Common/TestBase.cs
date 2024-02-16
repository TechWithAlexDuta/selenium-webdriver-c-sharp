using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects.PageObjects;
using Utils.Common;
using Utils.Reports.Extent;

namespace TestsExtentReportsParallelExecution.Common
{
    internal class TestBase
    {
        protected WebFormPage WebForm { get; private set; }
        protected Browser Browser { get; private set; }

        [SetUp]
        public void Setup()
        {
            ExtentParallelReporting.Instance.CreateTest(TestContext.CurrentContext.Test.MethodName);

            GetDriver().Manage().Window.Maximize();
            //this can be moved to JSON config
            GetDriver().Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Browser = new Browser(GetDriver());

            WebForm = new WebFormPage(GetDriver());
        }

        [TearDown]
        public void TearDown()
        {
            EndTest();
            ExtentParallelReporting.Instance.EndReporting();

            QuitDriver();
        }

        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Failed:
                    ExtentParallelReporting.Instance.LogFail($"Test has failed {message}");
                    break;
                case TestStatus.Skipped:
                    ExtentParallelReporting.Instance.LogInfo($"Test skipped {message}");
                    break;
                default:
                    break;
            }

            ExtentParallelReporting.Instance.LogScreenshot("Ending test", Browser.GetScreenshot());
        }

        private IWebDriver GetDriver()
        {
            return WebDriverFactory.GetDriver();
        }

        private void QuitDriver()
        {
            WebDriverFactory.QuitDriver();
        }
    }
}
