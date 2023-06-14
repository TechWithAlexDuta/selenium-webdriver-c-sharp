using Allure.Net.Commons;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using PageObjects.PageObjects;
using Utils.Common;
using Utils.Reports;

namespace TestsAllureReports.Common
{
    internal class TestBase
    {
        protected IWebDriver Driver { get; private set; }
        protected WebFormPage WebForm { get; private set; }
        protected Browser Browser { get; private set; }
        protected AllureReporting AllureReport { get; private set; }

        [SetUp]
        public void Setup()
        {
            AllureReport = new AllureReporting();

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
            Driver.Quit();
        }

        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Failed:
                    AllureReport.LogStep($"Test has failed {message}");
                    break;
                case TestStatus.Skipped:
                    AllureReport.LogStep($"Test skipped {message}");
                    break;
                default:
                    break;
            }

            var screenshot = Browser.SaveScreenshot();
            TestContext.AddTestAttachment(screenshot);
            AllureLifecycle.Instance.AddAttachment("ending test", "image/png", screenshot);
        }
    }
}
