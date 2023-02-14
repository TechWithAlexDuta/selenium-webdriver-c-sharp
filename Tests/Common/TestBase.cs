using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Common;
using Utils.Reports;

namespace Tests.Common
{
    internal class TestBase
    {
        protected IWebDriver Driver { get; private set; }
        protected WebFormPage WebForm { get; private set; }
        protected Browser Browser { get; private set; }

        [SetUp]
        public void Setup()
        {
            ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);

            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.selenium.dev/selenium/web/web-form.html");
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Browser = new Browser(Driver);

            WebForm = new WebFormPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            EndTest();
            ExtentReporting.EndReporting();
            Driver.Quit();
        }

        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch(testStatus)
            {
                case TestStatus.Failed:
                    ExtentReporting.LogFail($"Test has failed {message}");
                    break;
                case TestStatus.Skipped:
                    ExtentReporting.LogInfo($"Test skipped {message}");
                    break;
                default:
                    break;
            }

            ExtentReporting.LogScreenshot("Ending test", Browser.GetScreenshot());
        }
    }
}
