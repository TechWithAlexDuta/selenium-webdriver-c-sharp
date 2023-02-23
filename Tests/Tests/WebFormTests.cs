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
    internal class WebFormTests : TestBase
    {
        [Test]
        public void WriteToTextAreaTest()
        {
            ExtentReporting.Instance.LogInfo("Starting test - submit form");

            var text = Guid.NewGuid().ToString();
            var expectedMessage = "Received!";

            var message =
                 WebForm
                 .WriteTextToTextArea(text)
                 .SubmitForm()
                 .GetMessage();

            Assert.That(message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void WriteToTextAreaNegativeTest()
        {
            ExtentReporting.Instance.LogInfo("Starting negative test - submit form");

            var text = Guid.NewGuid().ToString();
            var expectedMessage = "Received failed!";

            var message =
                 WebForm
                 .WriteTextToTextArea(text)
                 .SubmitForm()
                 .GetMessage();

            Assert.That(message, Is.EqualTo(expectedMessage));
        }
    }
}
