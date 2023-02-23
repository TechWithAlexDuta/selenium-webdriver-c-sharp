using Allure.Net.Commons;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects.PageObjects;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
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
        protected AllureReporting AllureReport { get; private set; }

        [SetUp]
        public void Setup()
        {
            ExtentReporting.Instance.CreateTest(TestContext.CurrentContext.Test.MethodName);
            AllureReport = new AllureReporting();

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

            //extent report
            ExtentReporting.Instance.LogScreenshot("Ending test", Browser.GetScreenshot());

            //allure 
            var screenshot = Browser.SaveScreenshot();
            TestContext.AddTestAttachment(screenshot);
            AllureLifecycle.Instance.AddAttachment("ending test", "image/png", screenshot);
        }
    }
}
