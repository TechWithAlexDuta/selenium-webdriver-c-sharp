using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Common;
using Utils.Reports;

namespace Tests.Tests
{
    [AllureNUnit]
    internal class AllureReportTests : TestBase
    {
        [Test]
        [AllureDescription("Write text and submit form")]
        [AllureIssue("Issue-1")]
        [AllureTms("TMS-1")]
        public void AllureReportTest()
        {
            AllureReport.LogStep("submit form test");

            var text = Guid.NewGuid().ToString();
            var expectedMessage = "Received!";

            var message =
                 WebForm
                 .WriteTextToTextArea(text)
                 .SubmitForm()
                 .GetMessage();

            Assert.That(message, Is.EqualTo(expectedMessage));
        }
    }
}
