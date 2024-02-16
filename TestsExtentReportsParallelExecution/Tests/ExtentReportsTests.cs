using NUnit.Framework;
using TestsExtentReportsParallelExecution.Common;
using Utils.Reports.Extent;

namespace TestsExtentReportsParallelExecution.Tests
{
    [Parallelizable(ParallelScope.All)] 
    internal class ExtentReportsTests : TestBase
    {
        [Test]
        public void WriteToTextAreaTest()
        {
            ExtentParallelReporting.Instance.LogInfo("Starting test - submit form");

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
            ExtentParallelReporting.Instance.LogInfo("Starting negative test - submit form");

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
